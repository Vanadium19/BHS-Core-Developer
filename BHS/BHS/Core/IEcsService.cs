namespace BHS.Core;

/// <summary>
/// Интерфейс для сервисов управления ECS-миром.
/// </summary>
/// <remarks>
/// Определяет базовые методы жизненного цикла ECS:
/// инициализацию, обновление и освобождение ресурсов.
/// </remarks>
public interface IEcsService
{
    /// <summary>
    /// Инициализирует ECS-мир и регистрирует системы.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Выполняет один цикл обновления ECS-систем.
    /// </summary>
    void Run();

    /// <summary>
    /// Освобождает ресурсы ECS и уничтожает мир.
    /// </summary>
    void Dispose();
}