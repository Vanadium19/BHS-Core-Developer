using Avalonia.Media;

namespace BHS.Data;

/// <summary>
/// Данные для анимации цвета стен.
/// </summary>
/// <remarks>
/// <para>
/// Содержит параметры цветовой анимации, применяемой при столкновении
/// шарика со стеной: начальный цвет, целевой цвет и длительность перехода.
/// </para>
/// </remarks>
public struct WallAnimationData
{
    /// <summary>
    /// Продолжительность анимации в секундах.
    /// </summary>
    public required float Time { get; init; }

    /// <summary>
    /// Начальный цвет стены до анимации.
    /// </summary>
    public required IImmutableSolidColorBrush StartColor { get; init; }

    /// <summary>
    /// Цвет, в который меняется стена при столкновении.
    /// </summary>
    public required IImmutableSolidColorBrush TargetColor { get; init; }
}