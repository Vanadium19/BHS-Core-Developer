using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BHS.Constants;
using BHS.Core;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var scene = new Scene();
        var ecsStartup = new EcsStartup(scene);

        var systems = ecsStartup.Create();
        var tokenSource = new CancellationTokenSource();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new MainWindow(scene.Objects);
            desktop.MainWindow = window;

            GameLoop(systems, window, tokenSource);

            desktop.Exit += (_, _) =>
            {
                tokenSource.Cancel();
                ecsStartup.Dispose();
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void GameLoop(EcsSystems systems, MainWindow mainWindow, CancellationTokenSource tokenSource)
    {
        while (true)
        {
            systems.Run();
            mainWindow.Render();
            await Task.Delay(GameConstants.SleepTime, tokenSource.Token);
        }
    }
}