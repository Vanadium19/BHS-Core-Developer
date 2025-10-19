using System.Numerics;
using BHS.Components;
using BHS.Core;
using BHS.Data;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS.Factories;

public class BallFactory
{
    public Ball Create(Scene scene, EcsWorld world, BallData data)
    {
        var entity = world.NewEntity();

        var positions = world.GetPool<PositionComponent>();
        var position = positions.Add(entity).Value = new Vector2(400, 300);

        var speeds = world.GetPool<SpeedComponent>();
        speeds.Add(entity).Value = data.Speed;

        var velocities = world.GetPool<VelocityComponent>();
        velocities.Add(entity).Value = data.Velocity;

        var radius = world.GetPool<RadiusComponent>();
        radius.Add(entity).Value = data.Radius;

        var ball = new Ball(entity, position);

        var links = world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = ball;
        scene.Add(ball);

        return ball;
    }
}