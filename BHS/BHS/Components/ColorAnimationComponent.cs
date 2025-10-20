using Avalonia.Media;

namespace BHS.Components;

/// <summary>
/// Компонент, описывающий параметры анимации изменения цвета объекта.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="ColorAnimationComponent"/> используется системами 
/// <see cref="BHS.Systems.ColorChangeAnimationSystem"/> и 
/// <see cref="BHS.Systems.ColorChangeEventHandlingSystem"/> 
/// для управления плавным изменением цвета визуальных объектов.
/// </para>
/// <para>
/// Содержит начальный и целевой цвета, а также параметры времени анимации.
/// </para>
/// </remarks>
public struct ColorAnimationComponent
{
    /// <summary>
    /// Начальный цвет объекта до начала анимации.
    /// </summary>
    public IImmutableSolidColorBrush StartColor;

    /// <summary>
    /// Целевой цвет, в который должен измениться объект в ходе анимации.
    /// </summary>
    public IImmutableSolidColorBrush TargetColor;

    /// <summary>
    /// Полная длительность анимации в секундах.
    /// </summary>
    public float Time;

    /// <summary>
    /// Оставшееся время до завершения текущей анимации (в секундах).
    /// </summary>
    public float CurrentTime;
}