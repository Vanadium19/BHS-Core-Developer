using System.Numerics;

namespace BHS.Data;

/// <summary>
/// Структура, описывающая параметры шарика для инициализации в ECS-мире.
/// </summary>
/// <remarks>
/// <para>
/// Используется при создании сущностей шаров через <see cref="BHS.Factories.BallFactory"/>.
/// </para>
/// <para>
/// Содержит все основные характеристики — радиус, скорость, начальную позицию и направление.
/// </para>
/// </remarks>
public readonly struct BallData
{
    public required float Radius { get; init; }
    public required float Speed { get; init; }
    public required Vector2 Position { get; init; }
    public required Vector2 Direction { get; init; }

    public float Diameter => 2 * Radius;
}