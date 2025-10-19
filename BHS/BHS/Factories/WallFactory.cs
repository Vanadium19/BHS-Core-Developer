using System.Numerics;
using BHS.Components;
using BHS.Data;
using BHS.View;
using BHS.View.SceneObjects;
using Leopotam.EcsLite;

namespace BHS.Factories;

public class WallFactory
{
    private const float CenterLerp = 0.5f;

    private readonly ISceneService _scene;
    private readonly EcsWorld _world;

    public WallFactory(ISceneService scene, EcsWorld world)
    {
        _scene = scene;
        _world = world;
    }

    public Wall Create(Vector2 start, Vector2 end)
    {
        var entity = _world.NewEntity();

        var edges = _world.GetPool<EdgeComponent>();
        ref var edge = ref edges.Add(entity);
        edge.Start = start;
        edge.End = end;

        var animations = _world.GetPool<ColorAnimationComponent>();
        ref var animation = ref animations.Add(entity);
        animation.StartColor = ObjectsData.WallAnimationData.StartColor;
        animation.TargetColor = ObjectsData.WallAnimationData.TargetColor;
        animation.Time = ObjectsData.WallAnimationData.Time;

        var center = Vector2.Lerp(start, end, CenterLerp);
        var wall = new Wall(center, start, end);

        var links = _world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = wall;
        _scene.Add(wall);

        return wall;
    }
}