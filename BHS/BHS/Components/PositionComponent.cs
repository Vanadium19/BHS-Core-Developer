using System.Numerics;

namespace BHS.Components;

/// <summary>
/// Компонент, хранящий текущую позицию сущности в мировых координатах.
/// </summary>
/// <remarks>
/// Применяется для позиционирования и синхронизации объектов сцены.
/// </remarks>
public struct PositionComponent
{
    public Vector2 Value;
}