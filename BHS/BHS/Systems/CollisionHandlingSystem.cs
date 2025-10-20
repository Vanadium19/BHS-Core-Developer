using System.Numerics;
using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

/// <summary>
/// Система обработки столкновений, изменяющая направление движения сущностей после удара.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="CollisionHandlingSystem"/> реагирует на события столкновения (<see cref="CollisionEvent"/>)  
/// и обновляет направление движения сущностей с компонентом <see cref="DirectionComponent"/>.
/// </para>
/// <para>
/// Новое направление вычисляется путём отражения вектора скорости от нормали поверхности по формуле:
/// <c>v' = v - 2 * (v ⋅ n) * n</c>,
/// где <c>v</c> — текущий вектор направления, <c>n</c> — нормаль к стене.
/// </para>
/// После обработки событие столкновения удаляется из мира ECS.
/// </remarks>
public struct CollisionHandlingSystem : IEcsInitSystem, IEcsRunSystem
{
    private const int ReflectionFactor = 2;

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

            direction.Value -= ReflectionFactor * Vector2.Dot(direction.Value, collisionEvent.Normal) * collisionEvent.Normal;
            _collisions.Del(entity);
        }
    }
}