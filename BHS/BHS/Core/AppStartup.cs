using BHS.Factories;
using BHS.View;
using Leopotam.EcsLite;
using Microsoft.Extensions.DependencyInjection;

namespace BHS.Core;

public class AppStartup
{
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