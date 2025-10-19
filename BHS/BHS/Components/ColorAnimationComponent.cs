using Avalonia.Media;

namespace BHS.Components;

public struct ColorAnimationComponent
{
    public IImmutableSolidColorBrush StartColor;
    public IImmutableSolidColorBrush TargetColor;

    public float Time;
    public float CurrentTime;
}