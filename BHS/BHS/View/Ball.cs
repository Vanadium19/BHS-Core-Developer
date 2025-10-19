using System.Numerics;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using BHS.Core;

namespace BHS.View;

public sealed class Ball : SceneObject
{
    public Ball(int id, Vector2 position) : base(id, position)
    {
        Shape = new Ellipse
        {
            Width = 40,
            Height = 40,
            Fill = Brushes.DeepSkyBlue,
        };
    }

    public override Shape Shape { get; }

    public override void Render()
    {
        Canvas.SetLeft(Shape, Position.X - 20);
        Canvas.SetTop(Shape, Position.Y - 20);
    }
}