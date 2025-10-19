using BHS.Components;
using Leopotam.EcsLite;
using static BHS.Constants.GameConstants;

namespace BHS.Systems;

public struct ColorChangeAnimationSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;

    private EcsPool<LinkToSceneObject> _links;
    private EcsPool<ColorAnimationComponent> _animations;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _filter = world.Filter<LinkToSceneObject>().Inc<ColorAnimationComponent>().End();

        _links = world.GetPool<LinkToSceneObject>();
        _animations = world.GetPool<ColorAnimationComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var animation = ref _animations.Get(entity);

            if (animation.CurrentTime <= 0)
                continue;

            animation.CurrentTime -= DeltaTime;

            if (animation.CurrentTime > 0)
                continue;

            var link = _links.Get(entity);
            link.Value.UpdateColor(animation.StartColor);
        }
    }
}