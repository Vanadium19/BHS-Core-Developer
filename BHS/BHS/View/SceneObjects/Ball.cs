using System.Numerics;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using BHS.Data;

namespace BHS.View.SceneObjects;

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

    public override Shape Shape { get; }

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