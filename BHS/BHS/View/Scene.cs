using System;
using System.Collections.Generic;
using Avalonia.Threading;
using BHS.View.SceneObjects;

namespace BHS.View;

public class Scene : ISceneService
{
    private readonly List<SceneObject> _objects = new();
    private readonly MainWindow _window;

    public Scene(MainWindow window)
    {
        _window = window;
    }

    public void Add(SceneObject sceneObject)
    {
        if (_objects.Contains(sceneObject))
            throw new ArgumentException("Scene already contains this object.");

        _objects.Add(sceneObject);
        _window.Controls.Add(sceneObject.Shape);
    }

    public void Render()
    {
        foreach (var sceneObject in _objects)
            Dispatcher.UIThread.Post(() => sceneObject.Render());
    }

    public void Dispose()
    {
        foreach (var sceneObject in _objects)
            _window.Controls.Remove(sceneObject.Shape);
    }
}