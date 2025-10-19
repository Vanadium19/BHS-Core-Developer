using System;
using System.Numerics;
using BHS.Components;
using Leopotam.EcsLite;

namespace BHS.Systems;

public struct HitSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _balls;
    private EcsFilter _walls;

    private EcsPool<EdgeComponent> _edges;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<RadiusComponent> _radii;
    private EcsPool<VelocityComponent> _velocities;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _balls = world.Filter<PositionComponent>().Inc<RadiusComponent>().Inc<VelocityComponent>().End();
        _walls = world.Filter<EdgeComponent>().End();

        _positions = world.GetPool<PositionComponent>();
        _radii = world.GetPool<RadiusComponent>();
        _velocities = world.GetPool<VelocityComponent>();

        _edges = world.GetPool<EdgeComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var ball in _balls)
        {
            ref var position = ref _positions.Get(ball);
            ref var radius = ref _radii.Get(ball);

            foreach (var wall in _walls)
            {
                ref var edge = ref _edges.Get(wall);

                var distance = CalculateDistance(position.Value, edge);

                if (distance > radius.Value)
                    continue;

                var normal = GetNormal(edge);

                ref var velocity = ref _velocities.Get(ball);
                // velocity.Value -= 2 * Vector2.Dot(velocity.Value, normal) * normal;
                velocity.Value = Vector2.Zero;
                break;
            }
        }
    }

    private Vector2 GetNormal(EdgeComponent edge)
    {
        var edgeVector = edge.End - edge.Start;
        edgeVector = Vector2.Normalize(edgeVector);
        return new Vector2(-edgeVector.Y, edgeVector.X);
    }

    private float CalculateDistance(Vector2 point, EdgeComponent edge)
    {
        var edgeVector = edge.End - edge.Start;
        var pointToEdge = point - edge.Start;

        var cross = MathF.Abs(edgeVector.X * pointToEdge.Y - edgeVector.Y * pointToEdge.X);
        var distance = cross / edgeVector.Length();

        return distance;
    }
}