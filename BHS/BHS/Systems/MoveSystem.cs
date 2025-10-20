using BHS.Components;
using Leopotam.EcsLite;
using static BHS.Constants.GameConstants;

namespace BHS.Systems;

/// <summary>
/// Система ECS, отвечающая за обновление позиции сущностей во времени.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="MoveSystem"/> проходит по всем сущностям, у которых есть
/// компоненты <see cref="PositionComponent"/>, <see cref="SpeedComponent"/>
/// и <see cref="DirectionComponent"/>.
/// </para>
/// <para>
/// На каждом кадре обновляет позицию сущности по формуле:
/// <c>position += direction * speed * DeltaTime</c>,
/// перемещая объекты в соответствии с их направлением, скоростью и временем кадра.
/// </para>
/// </remarks>
public struct MoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<SpeedComponent> _speeds;
    private EcsPool<DirectionComponent> _directions;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<PositionComponent>().Inc<SpeedComponent>().Inc<DirectionComponent>().End();
        _positions = world.GetPool<PositionComponent>();
        _speeds = world.GetPool<SpeedComponent>();
        _directions = world.GetPool<DirectionComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var positon = ref _positions.Get(entity);
            ref var speed = ref _speeds.Get(entity);
            ref var direction = ref _directions.Get(entity);

            positon.Value += direction.Value * speed.Value * DeltaTime;
        }
    }
}