using BHS.Factories;
using BHS.View;
using Leopotam.EcsLite;
using Microsoft.Extensions.DependencyInjection;

namespace BHS.Core;

/// <summary>
/// Класс, выполняющий регистрацию всех сервисов и фабрик приложения.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="AppStartup"/> конфигурирует контейнер зависимостей
/// с помощью библиотеки <see cref="Microsoft.Extensions.DependencyInjection"/>.
/// </para>
/// <para>
/// В рамках инициализации регистрируются:
/// <list type="bullet">
/// <item><see cref="MainWindow"/> — главное окно приложения;</item>
/// <item><see cref="EcsWorld"/> — ECS-мир;</item>
/// <item><see cref="ISceneService"/> (реализация <see cref="Scene"/>) — сервис управления сценой;</item>
/// <item><see cref="IEcsService"/> (реализация <see cref="EcsStartup"/>) — управление ECS-системами;</item>
/// <item><see cref="BallFactory"/> и <see cref="WallFactory"/> — фабрики для создания объектов;</item>
/// <item><see cref="SceneStartup"/> — инициализация стартовой сцены.</item>
/// </list>
/// </para>
/// </remarks>
public sealed class AppStartup
{
    /// <summary>
    /// Регистрирует все сервисы, фабрики и основные классы приложения в контейнере зависимостей.
    /// </summary>
    /// <param name="services">
    /// Коллекция сервисов <see cref="IServiceCollection"/>, используемая для конфигурации DI-контейнера.
    /// </param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<EcsWorld>();

        services.AddSingleton<ISceneService, Scene>();
        services.AddSingleton<IEcsService, EcsStartup>();

        services.AddSingleton<BallFactory>();
        services.AddSingleton<WallFactory>();

        services.AddSingleton<SceneStartup>();
    }
}