using System;
using System.Collections.Generic;
using System.Linq;
using BHS.Core;

namespace BHS.View;

public class Scene
{
    private readonly List<SceneObject> _objects = new();

    public IEnumerable<SceneObject> Objects => _objects;

    public void Add(SceneObject sceneObject)
    {
        if (_objects.Contains(sceneObject))
            throw new ArgumentException("Scene already contains this object.");

        _objects.Add(sceneObject);
    }

    public T GetFirst<T>() where T : SceneObject
    {
        return _objects.FirstOrDefault(sceneObject => sceneObject is T) as T ?? throw new Exception("Object not found.");
    }
}