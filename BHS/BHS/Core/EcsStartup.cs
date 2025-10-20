using BHS.Systems;
using Leopotam.EcsLite;

namespace BHS.Core;

/// <summary>
/// Класс инициализации и управления ECS-миром.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="EcsStartup"/> создаёт ECS-мир (<see cref="EcsWorld"/>)
/// и регистрирует все игровые системы, управляющие логикой симуляции.
/// </para>
/// <para>
/// После инициализации через метод <see cref="Initialize"/> выполняет обновление систем
/// в игровом цикле методом <see cref="Run"/>, а при завершении — освобождает ресурсы.
/// </para>
/// </remarks>
public class EcsStartup : IEcsService
{
    private readonly EcsWorld _world;

    private EcsSystems _systems;

    public EcsStartup(EcsWorld world)
    {
        _world = world;
    }

    /// <summary>
    /// Инициализирует ECS-мир и регистрирует все игровые системы.
    /// </summary>
    /// <remarks>
    /// Список добавляемых систем:
    /// <list type="bullet">
    /// <item><see cref="MoveSystem"/> — перемещение сущностей;</item>
    /// <item><see cref="CheckCollisionSystem"/> — проверка столкновений;</item>
    /// <item><see cref="CollisionHandlingSystem"/> — обработка отражений;</item>
    /// <item><see cref="ColorChangeEventHandlingSystem"/> — реакция на изменение цвета;</item>
    /// <item><see cref="ColorChangeAnimationSystem"/> — анимация возврата цвета;</item>
    /// <item><see cref="PositionSyncSystem"/> — синхронизация ECS с визуальной сценой.</item>
    /// </list>
    /// </remarks>
    public void Initialize()
    {
        _systems = new EcsSystems(_world);

        _systems.Add(new MoveSystem())
            .Add(new CheckCollisionSystem())
            .Add(new CollisionHandlingSystem())
            .Add(new ColorChangeEventHandlingSystem())
            .Add(new ColorChangeAnimationSystem())
            .Add(new PositionSyncSystem())
            .Init();
    }

    /// <summary>
    /// Выполняет один цикл обновления всех активных ECS-систем.
    /// </summary>
    public void Run()
    {
        _systems.Run();
    }

    /// <summary>
    /// Уничтожает ECS-мир и освобождает все ресурсы.
    /// </summary>
    public void Dispose()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}