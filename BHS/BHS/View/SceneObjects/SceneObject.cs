using System.Numerics;
using Avalonia.Controls.Shapes;

namespace BHS.View.SceneObjects;

public abstract class SceneObject
{
    protected SceneObject(Vector2 position)
    {
        Position = position;
    }

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