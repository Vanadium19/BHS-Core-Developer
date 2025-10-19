using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Threading;
using BHS.Core;
using BHS.View;

namespace BHS;

public partial class MainWindow : Window
{
    private readonly IEnumerable<SceneObject> _objects;

    public MainWindow(IEnumerable<SceneObject> objects)
    {
        _objects = objects;

        InitializeComponent();

        foreach (var sceneObject in _objects)
            CanvasRoot.Children.Add(sceneObject.Shape);
    }

    public void Render()
    {
        Dispatcher.UIThread.Post(Draw);
    }

    private void Draw()
    {
        foreach (var sceneObject in _objects)
            sceneObject.Render();
    }
}