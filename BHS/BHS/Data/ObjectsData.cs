using System.Numerics;
using Avalonia.Media;

namespace BHS.Data;

/// <summary>
/// Статический класс, содержащий исходные данные для инициализации объектов сцены.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="ObjectsData"/> используется при создании начальной конфигурации сцены:
/// шарика и стен. Все значения фиксированы и задаются на этапе инициализации приложения.
/// </para>
/// </remarks>
public static class ObjectsData
{
    /// <summary>
    /// Массив координат, определяющих стены в сцене.
    /// </summary>
    public static readonly (Vector2 start, Vector2 end)[] Walls =
    [
        (new Vector2(100, 500), new Vector2(700, 500)),
        (new Vector2(700, 500), new Vector2(700, 100)),
        (new Vector2(700, 100), new Vector2(100, 100)),
        (new Vector2(100, 100), new Vector2(100, 500))
    ];

    /// <summary>
    /// Параметры анимации цвета для стен.
    /// </summary>
    public static readonly WallAnimationData WallAnimationData = new()
    {
        StartColor = Brushes.Gray,
        TargetColor = Brushes.Red,
        Time = 0.5f,
    };

    /// <summary>
    /// Исходные параметры шарика.
    /// </summary>
    public static readonly BallData Ball = new()
    {
        Radius = 20,
        Speed = 25,
        Direction = new Vector2(1, 0.2f),
        Position = new Vector2(400, 300),
    };
}