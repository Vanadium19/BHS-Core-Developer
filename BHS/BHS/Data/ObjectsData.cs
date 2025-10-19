using System.Numerics;

namespace BHS.Data;

public static class ObjectsData
{
    public static readonly (Vector2 start, Vector2 end)[] Walls =
    [
        (new Vector2(100, 500), new Vector2(700, 500)),
        (new Vector2(700, 500), new Vector2(700, 100)),
        (new Vector2(700, 100), new Vector2(100, 100)),
        (new Vector2(100, 100), new Vector2(100, 500))
    ];

    public static readonly BallData Ball = new()
    {
        Radius = 20,
        Speed = 25,
        Direction = new Vector2(1, 0.2f),
        Position = new Vector2(400, 300),
    };
}