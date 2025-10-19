using System;
using System.Numerics;
using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

public struct CheckCollisionSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _balls;
    private EcsFilter _walls;

    private EcsPool<EdgeComponent> _edges;
    private EcsPool<CollisionEvent> _collisions;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<RadiusComponent> _radii;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _balls = world.Filter<PositionComponent>().Inc<RadiusComponent>().End();
        _walls = world.Filter<EdgeComponent>().End();

        _positions = world.GetPool<PositionComponent>();
        _radii = world.GetPool<RadiusComponent>();

        _edges = world.GetPool<EdgeComponent>();
        _collisions = world.GetPool<CollisionEvent>();
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

                var normal = edge.GetNormal();
                _collisions.Add(ball).Normal = normal;
                break;
            }
        }
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