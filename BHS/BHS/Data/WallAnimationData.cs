using Avalonia.Media;

namespace BHS.Data;

public struct WallAnimationData
{
    public required float Time { get; init; }
    public required IImmutableSolidColorBrush StartColor { get; init; }
    public required IImmutableSolidColorBrush TargetColor { get; init; }
}