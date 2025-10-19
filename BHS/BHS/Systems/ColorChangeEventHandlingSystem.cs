using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

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