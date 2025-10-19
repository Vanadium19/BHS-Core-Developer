using System.Numerics;
using BHS.Data;
using BHS.Factories;
using BHS.Systems;
using BHS.View;
using Leopotam.EcsLite;

namespace BHS.Core;

public class EcsStartup
{
    private readonly Scene _scene;

    private EcsWorld _world;
    private EcsSystems _systems;

    public EcsStartup(Scene scene)
    {
        _scene = scene;
    }

    public EcsSystems Create()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.Add(new MoveSystem())
            .Add(new HitSystem())
            .Add(new PositionSyncSystem())
            .Init();

        CreateBall();
        CreateWalls();

        return _systems;
    }

    public void Dispose()
    {
        _systems.Destroy();
        _world.Destroy();
    }

    private void CreateWalls()
    {
        var factory = new WallFactory();
        // var edges = new (Vector2 start, Vector2 end)[4]
        // {
        //     (new Vector2(-5, 5), new Vector2(5, 5)),
        //     (new Vector2(5, 5), new Vector2(5, -5)),
        //     (new Vector2(5, -5), new Vector2(-5, -5)),
        //     (new Vector2(-5, -5), new Vector2(-5, 5)),
        // 
        var edges = new (Vector2 start, Vector2 end)[4]
        {
            (new Vector2(100, 500), new Vector2(700, 500)),
            (new Vector2(700, 500), new Vector2(700, 100)),
            (new Vector2(700, 100), new Vector2(100, 100)),
            (new Vector2(100, 100), new Vector2(100, 500)),
        };

        foreach (var edge in edges)
            factory.Create(_scene, _world, edge.start, edge.end);
    }

    private void CreateBall()
    {
        var factory = new BallFactory();
        var data = new BallData(20, 25, new Vector2(1, 0.2f));
        factory.Create(_scene, _world, data);
    }
}