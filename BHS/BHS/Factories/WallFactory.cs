using System.Numerics;
using BHS.Components;
using BHS.Data;
using BHS.View;
using BHS.View.SceneObjects;
using Leopotam.EcsLite;

namespace BHS.Factories;

/// <summary>
/// Фабрика для создания стен в ECS-мире и их визуальных представлений в сцене.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="WallFactory"/> инициализирует ECS-сущность, описывающую стену, —
/// добавляет компонент <see cref="EdgeComponent"/> с координатами начала и конца отрезка,
/// а также компонент <see cref="ColorAnimationComponent"/> для обработки анимации цвета.
/// </para>
/// <para>
/// После создания ECS-компонентов фабрика создаёт визуальный объект <see cref="Wall"/>,
/// связывает его с сущностью через <see cref="LinkToSceneObject"/> и добавляет на сцену.
/// </para>
/// </remarks>
public sealed class WallFactory
{
    private const float CenterLerp = 0.5f;

    private readonly ISceneService _scene;
    private readonly EcsWorld _world;

    public WallFactory(ISceneService scene, EcsWorld world)
    {
        _scene = scene;
        _world = world;
    }

    /// <summary>
    /// Создаёт новую стену на основе координат начала и конца.
    /// </summary>
    /// <param name="start">Координаты начала стены.</param>
    /// <param name="end">Координаты конца стены.</param>
    /// <returns>Созданный визуальный объект <see cref="Wall"/>.</returns>
    /// <remarks>
    /// Метод добавляет в ECS-мир сущность с компонентами:
    /// <list type="bullet">
    /// <item><see cref="EdgeComponent"/> — геометрическое описание стены;</item>
    /// <item><see cref="ColorAnimationComponent"/> — данные для цветовой анимации;</item>
    /// <item><see cref="LinkToSceneObject"/> — связь с объектом сцены.</item>
    /// </list>
    /// Также вычисляет центр стены для корректного позиционирования визуального объекта.
    /// </remarks>
    public Wall Create(Vector2 start, Vector2 end)
    {
        var entity = _world.NewEntity();

        var edges = _world.GetPool<EdgeComponent>();
        ref var edge = ref edges.Add(entity);
        edge.Start = start;
        edge.End = end;

        var animations = _world.GetPool<ColorAnimationComponent>();
        ref var animation = ref animations.Add(entity);
        animation.StartColor = ObjectsData.WallAnimationData.StartColor;
        animation.TargetColor = ObjectsData.WallAnimationData.TargetColor;
        animation.Time = ObjectsData.WallAnimationData.Time;

        var center = Vector2.Lerp(start, end, CenterLerp);
        var wall = new Wall(center, start, end);

        var links = _world.GetPool<LinkToSceneObject>();
        links.Add(entity).Value = wall;
        _scene.Add(wall);

        return wall;
    }
}