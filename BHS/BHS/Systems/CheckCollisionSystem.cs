using System;
using System.Numerics;
using BHS.Components;
using BHS.Events;
using Leopotam.EcsLite;

namespace BHS.Systems;

/// <summary>
/// Система проверки столкновений между шариками и стенами в ECS-мире.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="CheckCollisionSystem"/> определяет факт столкновения каждого шарика
/// (сущности с компонентами <see cref="PositionComponent"/> и <see cref="RadiusComponent"/>) 
/// со всеми стенами (сущностями, содержащими <see cref="EdgeComponent"/>).
/// </para>
/// <para>
/// При обнаружении пересечения создаётся событие <see cref="CollisionEvent"/> для шарика
/// и <see cref="ColorChangeEvent"/> для стены.
/// </para>
/// </remarks>
public struct CheckCollisionSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _balls;
    private EcsFilter _walls;

    private EcsPool<EdgeComponent> _edges;
    private EcsPool<CollisionEvent> _collisions;
    private EcsPool<ColorChangeEvent> _colorEvents;

    private EcsPool<PositionComponent> _positions;
    private EcsPool<RadiusComponent> _radii;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _balls = world.Filter<PositionComponent>().Inc<RadiusComponent>().End();
        _walls = world.Filter<EdgeComponent>().End();

        _positions = world.GetPool<PositionComponent>();
        _radii = world.GetPool<RadiusComponent>();

        _edges = world.GetPool<EdgeComponent>();
        _collisions = world.GetPool<CollisionEvent>();
        _colorEvents = world.GetPool<ColorChangeEvent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var ball in _balls)
        {
            ref var position = ref _positions.Get(ball);
            ref var radius = ref _radii.Get(ball);

            foreach (var wall in _walls)
            {
                ref var edge = ref _edges.Get(wall);

                var distance = CalculateDistance(position.Value, edge);

                if (distance > radius.Value)
                    continue;

                var normal = edge.GetNormal();
                _collisions.Add(ball).Normal = normal;
                _colorEvents.Add(wall);
                break;
            }
        }
    }

    /// <summary>
    /// Вычисляет кратчайшее расстояние от точки до отрезка.
    /// </summary>
    /// <param name="point">Позиция центра шарика.</param>
    /// <param name="edge">Компонент, описывающий стену (отрезок с началом и концом).</param>
    /// <returns>Расстояние от центра шарика до ближайшей точки стены.</returns>
    /// <remarks>
    /// Используется формула для нахождения расстояния от точки до прямой:
    /// <c>distance = |(edgeVector × pointToEdge)| / |edgeVector|</c>.
    /// </remarks>
    private float CalculateDistance(Vector2 point, EdgeComponent edge)
    {
        var edgeVector = edge.End - edge.Start;
        var pointToEdge = point - edge.Start;

        var cross = MathF.Abs(edgeVector.X * pointToEdge.Y - edgeVector.Y * pointToEdge.X);
        var distance = cross / edgeVector.Length();

        return distance;
    }
}