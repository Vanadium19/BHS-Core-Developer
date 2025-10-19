using System.Numerics;
using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

public struct CollisionHandlingSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<DirectionComponent> _directions;
    private EcsPool<CollisionEvent> _collisions;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<DirectionComponent>().Inc<CollisionEvent>().End();

        _directions = world.GetPool<DirectionComponent>();
        _collisions = world.GetPool<CollisionEvent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var collisionEvent = ref _collisions.Get(entity);
            ref var direction = ref _directions.Get(entity);

            direction.Value -= 2 * Vector2.Dot(direction.Value, collisionEvent.Normal) * collisionEvent.Normal;
            _collisions.Del(entity);
        }
    }
}