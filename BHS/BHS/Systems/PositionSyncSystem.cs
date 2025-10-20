using BHS.Components;
using Leopotam.EcsLite;

namespace BHS.Systems;

/// <summary>
/// Система синхронизации позиции ECS-сущностей с объектами сцены.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="PositionSyncSystem"/> обновляет положение визуальных или игровых объектов сцены
/// на основе текущих данных из ECS-компонентов <see cref="PositionComponent"/>.
/// </para>
/// <para>
/// Связь между ECS-сущностью и объектом сцены осуществляется через компонент
/// <see cref="LinkToSceneObject"/>, который предоставляет метод <c>SetPosition()</c>.
/// </para>
/// </remarks>
public struct PositionSyncSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<LinkToSceneObject> _links;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<PositionComponent>().Inc<LinkToSceneObject>().Inc<SpeedComponent>().End();

        _positions = world.GetPool<PositionComponent>();
        _links = world.GetPool<LinkToSceneObject>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var position = ref _positions.Get(entity);
            ref var link = ref _links.Get(entity);

            link.Value.SetPosition(position.Value);
        }
    }
}