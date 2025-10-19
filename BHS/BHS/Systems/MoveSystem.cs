using BHS.Components;
using Leopotam.EcsLite;
using static BHS.Constants.GameConstants;

namespace BHS.Systems;

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