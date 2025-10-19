using BHS.Systems;
using Leopotam.EcsLite;

namespace BHS.Core;

public class EcsStartup : IEcsService
{
    private readonly EcsWorld _world;

    private EcsSystems _systems;

    public EcsStartup(EcsWorld world)
    {
        _world = world;
    }

    public void Initialize()
    {
        _systems = new EcsSystems(_world);

        _systems.Add(new MoveSystem())
            .Add(new CheckCollisionSystem())
            .Add(new CollisionHandlingSystem())
            .Add(new PositionSyncSystem())
            .Init();
    }

    public void Run()
    {
        _systems.Run();
    }

    public void Dispose()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}