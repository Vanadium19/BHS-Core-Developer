using System.Numerics;

namespace BHS.Components;

/// <summary>
/// Компонент, определяющий направление движения сущности.
/// </summary>
/// <remarks>
/// Используется системами перемещения для вычисления изменения позиции.
/// </remarks>
public struct DirectionComponent
{
    public Vector2 Value;
}