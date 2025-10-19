using System.Numerics;

namespace BHS.Components;

public struct EdgeComponent
{
    public Vector2 Start;
    public Vector2 End;

    public Vector2 GetNormal()
    {
        var edgeVector = End - Start;
        edgeVector = Vector2.Normalize(edgeVector);
        return new Vector2(-edgeVector.Y, edgeVector.X);
    }
}