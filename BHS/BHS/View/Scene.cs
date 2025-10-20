using System;
using System.Collections.Generic;
using Avalonia.Threading;
using BHS.View.SceneObjects;

namespace BHS.View;

/// <summary>
/// Сцена, содержащая визуальные объекты и управляющая их отрисовкой.
/// </summary>
/// <remarks>
/// <para>
/// Класс <see cref="Scene"/> реализует интерфейс <see cref="ISceneService"/> и отвечает
/// за управление жизненным циклом визуальных объектов сцены — их добавлением,
/// отображением и удалением.
/// </para>
/// <para>
/// Все операции визуального обновления выполняются в UI-потоке Avalonia через
/// <see cref="Dispatcher.UIThread"/> для обеспечения потокобезопасности.
/// </para>
/// </remarks>
public class Scene : ISceneService
{
    private readonly List<SceneObject> _objects = new();
    private readonly MainWindow _window;

    public Scene(MainWindow window)
    {
        _window = window;
    }

    /// <summary>
    /// Добавляет объект на сцену и регистрирует его визуальное представление в окне.
    /// </summary>
    /// <param name="sceneObject">Объект сцены, который необходимо добавить.</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если попытаться добавить объект, который уже присутствует на сцене.
    /// </exception>
    public void Add(SceneObject sceneObject)
    {
        if (_objects.Contains(sceneObject))
            throw new ArgumentException("Scene already contains this object.");

        _objects.Add(sceneObject);
        _window.Controls.Add(sceneObject.Shape);
    }

    /// <summary>
    /// Выполняет отрисовку всех объектов сцены.
    /// </summary>
    /// <remarks>
    /// Метод вызывает <see cref="SceneObject.Render"/> для каждого объекта,
    /// помещая вызовы в очередь UI-потока Avalonia.
    /// </remarks>
    public void Render()
    {
        foreach (var sceneObject in _objects)
            Dispatcher.UIThread.Post(() => sceneObject.Render());
    }

    /// <summary>
    /// Удаляет все объекты сцены из окна и освобождает ресурсы.
    /// </summary>
    public void Dispose()
    {
        foreach (var sceneObject in _objects)
            _window.Controls.Remove(sceneObject.Shape);

        _objects.Clear();
    }
}