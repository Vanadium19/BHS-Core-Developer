using BHS.Data;
using BHS.Factories;

namespace BHS.Core;

/// <summary>
/// Класс, выполняющий инициализацию сцены и создание игровых объектов.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="SceneStartup"/> отвечает за построение начального состояния сцены —
/// создаёт все стены и один шарик с параметрами из <see cref="ObjectsData"/>.
/// </para>
/// <para>
/// Использует фабрики <see cref="WallFactory"/> и <see cref="BallFactory"/> для добавления
/// соответствующих ECS-сущностей и их визуальных представлений на сцену.
/// </para>
/// </remarks>
public class SceneStartup
{
    private readonly WallFactory _wallFactory;
    private readonly BallFactory _ballFactory;

    public SceneStartup(WallFactory wallFactory, BallFactory ballFactory)
    {
        _wallFactory = wallFactory;
        _ballFactory = ballFactory;
    }

    /// <summary>
    /// Инициализирует сцену, создавая шарик и стены.
    /// </summary>
    /// <remarks>
    /// Последовательно вызывает методы <see cref="CreateBall"/> и <see cref="CreateWalls"/>,
    /// которые создают все игровые объекты.
    /// </remarks>
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