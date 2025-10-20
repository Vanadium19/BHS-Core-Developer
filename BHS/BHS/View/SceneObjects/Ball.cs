using System.Numerics;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using BHS.Data;

namespace BHS.View.SceneObjects;

/// <summary>
/// Визуальное представление шарика на сцене.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="Ball"/> наследуется от <see cref="SceneObject"/> и отображается в виде круга
/// (<see cref="Ellipse"/>). Параметры радиуса и цвета берутся из данных
/// <see cref="ObjectsData.Ball"/>.
/// </para>
/// <para>
/// Отрисовка выполняется в координатах сцены, а цвет может динамически изменяться
/// при событиях столкновения или взаимодействия с системами ECS.
/// </para>
/// </remarks>
public sealed class Ball : SceneObject
{
    public Ball(Vector2 position) : base(position)
    {
        var diameter = ObjectsData.Ball.Diameter;

        Shape = new Ellipse
        {
            Width = diameter,
            Height = diameter,
            Fill = Brushes.DeepSkyBlue,
        };
    }

    /// <summary>
    /// Фигура Avalonia, представляющая шар (эллипс).
    /// </summary>
    public override Shape Shape { get; }

    /// <summary>
    /// Выполняет позиционирование шарика на сцене.
    /// </summary>
    /// <remarks>
    /// Центр фигуры совмещается с координатой позиции сущности ECS.
    /// </remarks>
    public override void Render()
    {
        Canvas.SetLeft(Shape, Position.X - ObjectsData.Ball.Radius);
        Canvas.SetTop(Shape, Position.Y - ObjectsData.Ball.Radius);
    }

    protected override void UpdateColorInternal(IImmutableSolidColorBrush value)
    {
        Shape.Fill = value;
    }
}