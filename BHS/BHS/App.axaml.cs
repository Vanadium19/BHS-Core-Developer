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

public partial class App : Application
{
    private readonly CancellationTokenSource _tokenSource = new();

    private IEcsService _ecsService;
    private ISceneService _sceneService;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

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

        GameLoop();

        base.OnFrameworkInitializationCompleted();
    }

    private async void GameLoop()
    {
        while (true)
        {
            _ecsService.Run();
            _sceneService.Render();

            await Task.Delay(GameConstants.SleepTime, _tokenSource.Token);
        }
    }

    private void Dispose()
    {
        _ecsService!.Dispose();
        _sceneService!.Dispose();
    }
}