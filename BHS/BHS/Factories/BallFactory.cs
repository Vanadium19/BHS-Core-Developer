using BHS.Components;
using BHS.Data;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS.Factories;

public class BallFactory
{
    private readonly ISceneService _scene;
    private readonly EcsWorld _world;

    public BallFactory(ISceneService scene, EcsWorld world)
    {
        _scene = scene;
        _world = world;
    }

    public Ball Create(BallData data)
    {
        var entity = _world.NewEntity();

        var positions = _world.GetPool<PositionComponent>();
        var position = positions.Add(entity).Value = data.Position;

        var speeds = _world.GetPool<SpeedComponent>();
        speeds.Add(entity).Value = data.Speed;

        var velocities = _world.GetPool<VelocityComponent>();
        velocities.Add(entity).Value = data.Velocity;

        var radius = _world.GetPool<RadiusComponent>();
        radius.Add(entity).Value = data.Radius;

        var ball = new Ball(entity, position);

        var links = _world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = ball;
        _scene.Add(ball);

        return ball;
    }
}