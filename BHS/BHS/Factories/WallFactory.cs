using System.Numerics;
using BHS.Components;
using BHS.Core;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS.Factories;

public class WallFactory
{
    private readonly ISceneService _scene;
    private readonly EcsWorld _world;

    public WallFactory(ISceneService scene, EcsWorld world)
    {
        _scene = scene;
        _world = world;
    }

    public Wall Create(Vector2 start, Vector2 end)
    {
        var edges = _world.GetPool<EdgeComponent>();

        var entity = _world.NewEntity();

        ref var edge = ref edges.Add(entity);
        edge.Start = start;
        edge.End = end;

        var center = Vector2.Lerp(start, end, 0.5f);
        var wall = new Wall(entity, center, start, end);
        _scene.Add(wall);

        var links = _world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = wall;

        return wall;
    }
}