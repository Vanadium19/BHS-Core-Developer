using System.Numerics;
using BHS.Components;
using BHS.Core;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS.Factories;

public class WallFactory
{
    public Wall Create(Scene scene, EcsWorld world, Vector2 start, Vector2 end)
    {
        var edges = world.GetPool<EdgeComponent>();

        var entity = world.NewEntity();

        ref var edge = ref edges.Add(entity);
        edge.Start = start;
        edge.End = end;

        var center = Vector2.Lerp(start, end, 0.5f);
        var wall = new Wall(entity, center, start, end);
        scene.Add(wall);

        var links = world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = wall;

        return wall;
    }
}