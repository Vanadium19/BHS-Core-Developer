using BHS.Components;
using BHS.Data;
using BHS.View;
using BHS.View.SceneObjects;
using Leopotam.EcsLite;

namespace BHS.Factories;

/// <summary>
/// Фабрика для создания сущностей шариков в ECS-мире и их визуальных представлений.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="BallFactory"/> отвечает за инициализацию всех необходимых компонентов
/// ECS-сущности, представляющей шарик, а также за создание связанного
/// визуального объекта <see cref="Ball"/> в сцене.
/// </para>
/// <para>
/// Компоненты, добавляемые при создании:
/// <list type="bullet">
/// <item><see cref="PositionComponent"/> — позиция шарика;</item>
/// <item><see cref="SpeedComponent"/> — скорость движения;</item>
/// <item><see cref="DirectionComponent"/> — направление движения;</item>
/// <item><see cref="RadiusComponent"/> — радиус шарика;</item>
/// <item><see cref="LinkToSceneObject"/> — ссылка на визуальный объект сцены.</item>
/// </list>
/// </para>
/// </remarks>
public class BallFactory
{
    private readonly ISceneService _scene;
    private readonly EcsWorld _world;

    public BallFactory(ISceneService scene, EcsWorld world)
    {
        _scene = scene;
        _world = world;
    }

    /// <summary>
    /// Создаёт новую сущность шарика и соответствующий объект сцены.
    /// </summary>
    /// <param name="data">Данные и параметры шарика, включая позицию, радиус и скорость.</param>
    /// <returns>Созданный объект <see cref="Ball"/>.</returns>
    /// <remarks>
    /// Метод создаёт новую ECS-сущность, добавляет к ней все необходимые компоненты
    /// и связывает с визуальным объектом <see cref="Ball"/>, который добавляется на сцену.
    /// </remarks>
    public Ball Create(BallData data)
    {
        var entity = _world.NewEntity();

        var positions = _world.GetPool<PositionComponent>();
        var position = positions.Add(entity).Value = data.Position;

        var speeds = _world.GetPool<SpeedComponent>();
        speeds.Add(entity).Value = data.Speed;

        var directions = _world.GetPool<DirectionComponent>();
        directions.Add(entity).Value = data.Direction;

        var radius = _world.GetPool<RadiusComponent>();
        radius.Add(entity).Value = data.Radius;

        var ball = new Ball(position);

        var links = _world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = ball;
        _scene.Add(ball);

        return ball;
    }
}