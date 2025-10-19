using System.Numerics;
using Avalonia;
using Avalonia.Controls.Shapes;

namespace BHS.View.SceneObjects;

public sealed class Wall : SceneObject
{
    private const float Thickness = 4;

    public Wall(Vector2 position, Vector2 start, Vector2 end) : base(position)
    {
        Shape = new Line
        {
            StartPoint = new Point(start.X, start.Y),
            EndPoint = new Point(end.X, end.Y),
            Stroke = Avalonia.Media.Brushes.Gray,
            StrokeThickness = Thickness,
        };
    }

    public override Shape Shape { get; }
}