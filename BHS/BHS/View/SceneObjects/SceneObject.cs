using System.Numerics;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Threading;

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

    public void UpdateColor(IImmutableSolidColorBrush value)
    {
        Dispatcher.UIThread.Post(() => UpdateColorInternal(value));
    }

    public virtual void Render()
    {
    }

    protected abstract void UpdateColorInternal(IImmutableSolidColorBrush value);
}