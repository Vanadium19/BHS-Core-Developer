using BHS.View.SceneObjects;

namespace BHS.View;

/// <summary>
/// Интерфейс сервиса управления визуальной сценой.
/// </summary>
/// <remarks>
/// <para>
/// Определяет базовые операции для добавления, отображения и удаления
/// объектов сцены (<see cref="SceneObject"/>).
/// </para>
/// <para>
/// Реализация интерфейса обеспечивает взаимодействие ECS-механизма
/// с визуальным представлением в Avalonia.
/// </para>
/// </remarks>
public interface ISceneService
{
    /// <summary>
    /// Добавляет визуальный объект на сцену.
    /// </summary>
    /// <param name="sceneObject">Экземпляр объекта сцены, который необходимо добавить.</param>
    void Add(SceneObject sceneObject);
    
    /// <summary>
    /// Выполняет отрисовку всех объектов, добавленных на сцену.
    /// </summary>
    void Render();
    
    /// <summary>
    /// Удаляет все объекты сцены и освобождает связанные ресурсы.
    /// </summary>
    void Dispose();
}