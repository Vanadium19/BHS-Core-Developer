using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

/// <summary>
/// Система обработки событий изменения цвета у объектов сцены.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="ColorChangeEventHandlingSystem"/> реагирует на события
/// <see cref="ColorChangeEvent"/>, обновляя визуальное состояние
/// объектов сцены, связанных через компонент <see cref="LinkToSceneObject"/>.
/// </para>
/// <para>
/// При получении события система применяет цветовую анимацию,
/// устанавливает целевой цвет из <see cref="ColorAnimationComponent"/>
/// и удаляет обработанное событие из ECS-мира.
/// </para>
/// </remarks>
public struct ColorChangeEventHandlingSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<LinkToSceneObject> _links;
    private EcsPool<ColorChangeEvent> _events;
    private EcsPool<ColorAnimationComponent> _animations;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<LinkToSceneObject>().Inc<ColorChangeEvent>().Inc<ColorAnimationComponent>().End();

        _links = world.GetPool<LinkToSceneObject>();
        _events = world.GetPool<ColorChangeEvent>();
        _animations = world.GetPool<ColorAnimationComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var link = ref _links.Get(entity);
            ref var animation = ref _animations.Get(entity);

            animation.CurrentTime = animation.Time;
            link.Value.UpdateColor(animation.TargetColor);
            _events.Del(entity);
        }
    }
}