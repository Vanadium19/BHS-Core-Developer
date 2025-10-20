using System.Numerics;

namespace BHS.Components;

/// <summary>
/// Компонент, описывающий геометрию стены в виде отрезка.
/// </summary>
/// <remarks>
/// <para>
/// Хранит координаты начала (<c>Start</c>) и конца (<c>End</c>) отрезка,
/// определяющего положение стены на сцене.
/// </para>
/// <para>
/// Также предоставляет метод <see cref="GetNormal"/> для вычисления нормали
/// к поверхности стены, используемой при расчёте отражений.
/// </para>
/// </remarks>
public struct EdgeComponent
{
    public Vector2 Start;
    public Vector2 End;

    /// <summary>
    /// Вычисляет нормаль к стене (перпендикуляр к направлению отрезка).
    /// </summary>
    /// <returns>Нормализованный вектор нормали к поверхности стены.</returns>
    public Vector2 GetNormal()
    {
        var edgeVector = End - Start;
        edgeVector = Vector2.Normalize(edgeVector);
        return new Vector2(-edgeVector.Y, edgeVector.X);
    }
}