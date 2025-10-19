using System.Numerics;

namespace BHS.Data;

public readonly struct BallData
{
    public required float Radius { get; init; }
    public required float Speed { get; init; }
    public required Vector2 Position { get; init; }
    public required Vector2 Velocity { get; init; }
}