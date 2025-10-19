using System.Numerics;

namespace BHS.Data;

public readonly struct BallData(float radius, float speed, Vector2 velocity)
{
    public readonly float Radius = radius;
    public readonly float Speed = speed;
    public readonly Vector2 Velocity = velocity;
}