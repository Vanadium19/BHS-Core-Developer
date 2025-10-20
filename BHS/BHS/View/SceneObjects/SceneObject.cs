using System.Numerics;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Threading;

namespace BHS.View.SceneObjects;

/// <summary>
/// Абстрактный базовый класс визуального объекта сцены.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="SceneObject"/> определяет общие свойства и поведение всех визуальных элементов,
/// отображаемых на сцене — таких как <see cref="Ball"/> и <see cref="Wall"/>.
/// </para>
/// <para>
/// Содержит информацию о позиции, форму для отображения, а также методы для обновления цвета
/// и визуализации. Обновления цвета выполняются в UI-потоке Avalonia через
/// <see cref="Dispatcher.UIThread"/>.
/// </para>
/// </remarks>
public abstract class SceneObject
{
    protected SceneObject(Vector2 position)
    {
        Position = position;
    }

    /// <summary>
    /// Фигура Avalonia, представляющая визуальную форму объекта.
    /// </summary>
    public abstract Shape Shape { get; }

    /// <summary>
    /// Текущая позиция объекта на сцене.
    /// </summary>
    public Vector2 Position { get; private set; }

    /// <summary>
    /// Устанавливает новую позицию объекта.
    /// </summary>
    /// <param name="value">Координаты новой позиции.</param>
    public void SetPosition(Vector2 value)
    {
        Position = value;
    }

    /// <summary>
    /// Обновляет цвет объекта.
    /// </summary>
    /// <param name="value">Новый цвет в виде неизменяемой кисти.</param>
    /// <remarks>
    /// Вызов выполняется в UI-потоке через <see cref="Dispatcher.UIThread"/>,
    /// чтобы гарантировать корректное обновление интерфейса.
    /// </remarks>
    public void UpdateColor(IImmutableSolidColorBrush value)
    {
        Dispatcher.UIThread.Post(() => UpdateColorInternal(value));
    }

    /// <summary>
    /// Отрисовывает объект на сцене.
    /// </summary>
    /// <remarks>
    /// Может быть переопределён наследниками для реализации пользовательской логики отрисовки.
    /// </remarks>
    public virtual void Render()
    {
    }

    /// <summary>
    /// Абстрактный метод для непосредственного изменения цвета фигуры.
    /// </summary>
    /// <param name="value">Цвет, который должен быть установлен.</param>
    protected abstract void UpdateColorInternal(IImmutableSolidColorBrush value);
}