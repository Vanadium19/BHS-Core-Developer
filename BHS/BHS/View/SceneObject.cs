using System.Numerics;
using Avalonia.Controls.Shapes;

namespace BHS.View;

public abstract class SceneObject
{
    protected SceneObject(int id, Vector2 position)
    {
        Id = id;
        Position = position;
    }

    public int Id { get; }
    public abstract Shape Shape { get; }
    public Vector2 Position { get; private set; }

    public void SetPosition(Vector2 value)
    {
        Position = value;
    }

    public virtual void Render()
    {
    }
}