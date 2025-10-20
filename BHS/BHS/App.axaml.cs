using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BHS.Constants;
using BHS.Core;
using BHS.View;
using Microsoft.Extensions.DependencyInjection;

namespace BHS;

/// <summary>
/// Главный класс приложения, отвечающий за инициализацию и запуск игрового цикла.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="App"/> наследуется от <see cref="Application"/> Avalonia и управляет
/// жизненным циклом всего приложения. В процессе запуска создаёт контейнер зависимостей,
/// регистрирует все сервисы через <see cref="AppStartup"/> и инициализирует ECS-мир
/// и визуальную сцену.
/// </para>
/// <para>
/// После инициализации запускается асинхронный игровой цикл, который выполняет:
/// <list type="bullet">
/// <item>обновление логики ECS через <see cref="IEcsService"/>;</item>
/// <item>отрисовку объектов сцены через <see cref="ISceneService"/>;</item>
/// <item>задержку между кадрами, определяемую <see cref="GameConstants.SleepTime"/>.</item>
/// </list>
/// </para>
/// </remarks>
public partial class App : Application
{
    private readonly CancellationTokenSource _tokenSource = new();

    private IEcsService _ecsService;
    private ISceneService _sceneService;

    /// <summary>
    /// Загружает ресурсы XAML и инициализирует базовое состояние Avalonia-приложения.
    /// </summary>
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Выполняет инициализацию инфраструктуры приложения после загрузки Avalonia-фреймворка.
    /// </summary>
    /// <remarks>
    /// Создаёт контейнер зависимостей, получает сервисы <see cref="IEcsService"/>,
    /// <see cref="ISceneService"/> и запускает инициализацию сцены и ECS.
    /// </remarks>
    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        var startup = new AppStartup();

        startup.ConfigureServices(services);

        var provider = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = provider.GetService<MainWindow>();
            desktop.Exit += (_, _) => Dispose();
        }

        _ecsService = provider.GetService<IEcsService>()!;
        _sceneService = provider.GetService<ISceneService>()!;

        _ecsService.Initialize();

        var sceneStartup = provider.GetService<SceneStartup>();
        sceneStartup!.Initialize();

        StartGameLoop();

        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    /// Запускает основной игровой цикл приложения.
    /// </summary>
    /// <remarks>
    /// Выполняет обновление ECS и отрисовку сцены с фиксированным интервалом времени.
    /// </remarks>
    private async void StartGameLoop()
    {
        while (true)
        {
            _ecsService.Run();
            _sceneService.Render();

            await Task.Delay(GameConstants.SleepTime, _tokenSource.Token);
        }
    }

    /// <summary>
    /// Освобождает все ресурсы и корректно завершает работу ECS и сцены.
    /// </summary>
    private void Dispose()
    {
        _ecsService!.Dispose();
        _sceneService!.Dispose();
    }
}