using BHS.Data;
using BHS.Factories;

namespace BHS.Core;

public class SceneStartup
{
    private readonly WallFactory _wallFactory;
    private readonly BallFactory _ballFactory;

    public SceneStartup(WallFactory wallFactory, BallFactory ballFactory)
    {
        _wallFactory = wallFactory;
        _ballFactory = ballFactory;
    }

    public void Initialize()
    {
        CreateBall();
        CreateWalls();
    }

    private void CreateWalls()
    {
        foreach (var wall in ObjectsData.Walls)
            _wallFactory.Create(wall.start, wall.end);
    }

    private void CreateBall()
    {
        _ballFactory.Create(ObjectsData.Ball);
    }
}