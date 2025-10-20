\mainpage BHS — Ball & Wall Simulation
\tableofcontents

\section intro Введение

**BHS** — учебный проект, демонстрирующий реализацию архитектуры  
**Entity Component System (ECS)** на базе библиотеки [LeoEcsLite](https://github.com/Leopotam/ecslite)  
с использованием **Avalonia UI** для визуализации.

Проект моделирует движение шарика в ограниченной коробке,  
обработку столкновений и анимацию изменения цвета при ударах.

---

\section architecture Архитектура проекта

\subsection core Core
Управляет инициализацией, зависимостями и игровым циклом:
- `App` — главный игровой цикл.
- `AppStartup` — регистрация зависимостей (DI).
- `EcsStartup` — настройка ECS и систем.
- `SceneStartup` — создание объектов сцены.

\subsection view View
Визуальный слой Avalonia:
- `Scene`, `ISceneService` — управление объектами сцены.
- `SceneObject` — базовый класс визуальных объектов.
- `Ball`, `Wall` — конкретные реализации.

\subsection components Components
Минимальные ECS-компоненты:
- `PositionComponent`, `DirectionComponent`, `SpeedComponent`, `RadiusComponent`
- `EdgeComponent`, `ColorAnimationComponent`, `LinkToSceneObject`

\subsection systems Systems
Игровая логика:
- `MoveSystem` — перемещение сущностей.
- `CheckCollisionSystem` — проверка столкновений.
- `CollisionHandlingSystem` — отражение движения.
- `ColorChangeEventHandlingSystem` — реакция на столкновение.
- `ColorChangeAnimationSystem` — возврат цвета.
- `PositionSyncSystem` — синхронизация ECS и визуального слоя.

\subsection factories Factories
Создание объектов:
- `BallFactory` — шарик.
- `WallFactory` — стена.

\subsection data Data
Исходные параметры объектов:
- `BallData`, `WallAnimationData`, `ObjectsData`.

\subsection constants Constants
Глобальные параметры симуляции:
- `GameConstants` — фиксированные тайминги и шаг времени.

---

\section loop Игровой цикл

Главный игровой цикл:
\code{.cs}
while (true)
{
    _ecsService.Run();
    _sceneService.Render();
    await Task.Delay(GameConstants.SleepTime);
}
\endcode

Последовательность:
1. Обновление ECS.
2. Синхронизация и отрисовка.
3. Пауза между кадрами.

---

\section tech Технологии

| Технология | Назначение |
|-------------|-------------|
| **C# 12 / .NET 8** | Язык и платформа |
| **Avalonia UI** | Графика и интерфейс |
| **LeoEcsLite** | ECS-фреймворк |
| **Microsoft.Extensions.DependencyInjection** | Внедрение зависимостей |
| **Doxygen** | Автоматическая документация |

---

\section build Сборка и документация

Сгенерировать HTML-документацию:
\code{.bash}
doxygen Doxyfile
\endcode

Результат:  
`Output/html/index.html`

---

\section author Автор

**BHS Core Developer**  
Проект создан в рамках учебной практики.
