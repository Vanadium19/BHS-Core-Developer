using System.Numerics;

namespace BHS.Events;

/// <summary>
/// Событие столкновения, содержащее информацию о нормали контакта.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="CollisionEvent"/> создаётся при обнаружении пересечения шарика со стеной.
/// </para>
/// <para>
/// Поле <see cref="Normal"/> хранит нормаль поверхности в точке контакта
/// и используется для расчёта отражения направления движения.
/// </para>
/// </remarks>
public struct CollisionEvent
{
    public Vector2 Normal;
}