using System;
using BHS.Components;
using Leopotam.EcsLite;
using static BHS.Constants.GameConstants;

namespace BHS.Systems;

public struct MoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<SpeedComponent> _speeds;
    private EcsPool<VelocityComponent> _velocities;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<PositionComponent>().Inc<SpeedComponent>().Inc<VelocityComponent>().End();
        _positions = world.GetPool<PositionComponent>();
        _speeds = world.GetPool<SpeedComponent>();
        _velocities = world.GetPool<VelocityComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var positon = ref _positions.Get(entity);
            ref var speed = ref _speeds.Get(entity);
            ref var velocity = ref _velocities.Get(entity);

            positon.Value += velocity.Value * speed.Value * DeltaTime;
        }
    }
}