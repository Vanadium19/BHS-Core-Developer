using System.Numerics;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace BHS.View.SceneObjects;

/// <summary>
/// Визуальное представление стены на сцене.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="Wall"/> наследуется от <see cref="SceneObject"/> и отображается в виде линии
/// (<see cref="Line"/>), определяемой точками начала и конца.
/// </para>
/// <para>
/// Стена используется для взаимодействия с шариком — система столкновений
/// (<see cref="BHS.Systems.CheckCollisionSystem"/>) вычисляет нормали и отскоки на её основе.
/// </para>
/// </remarks>
public sealed class Wall : SceneObject
{
    private const float Thickness = 4;

    public Wall(Vector2 position, Vector2 start, Vector2 end) : base(position)
    {
        Shape = new Line
        {
            StartPoint = new Point(start.X, start.Y),
            EndPoint = new Point(end.X, end.Y),
            Stroke = Brushes.Gray,
            StrokeThickness = Thickness,
        };
    }

    /// <summary>
    /// Фигура Avalonia, представляющая линию стены.
    /// </summary>
    public override Shape Shape { get; }

    protected override void UpdateColorInternal(IImmutableSolidColorBrush value)
    {
        Shape.Stroke = value;
    }
}