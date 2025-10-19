using System.Numerics;
using Avalonia;
using Avalonia.Controls.Shapes;

namespace BHS.View;

public sealed class Wall : SceneObject
{
    private readonly Vector2 _start;
    private readonly Vector2 _end;
    
    public Wall(int id,
        Vector2 position,
        Vector2 start,
        Vector2 end)
        : base(id, position)
    {
        _start = start;
        _end = end;
        
        Shape = new Line
        {
            StartPoint = new Point(_start.X, _start.Y),
            EndPoint = new Point(_end.X, _end.Y),
            Stroke = Avalonia.Media.Brushes.Gray,
            StrokeThickness = 4
        };
    }

    public override Shape Shape { get; }

    public override void Render()
    {

    }
}