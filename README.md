# 🧩 BHS — Ball & Wall Simulation

## 🎯 Описание проекта

**BHS** — учебный проект, демонстрирующий архитектуру **Entity Component System (ECS)**  
на базе библиотеки [LeoEcsLite](https://github.com/Leopotam/ecslite)  
с визуализацией в **Avalonia UI**.

Проект моделирует движение шарика внутри ограниченной коробки из стен,  
с обработкой столкновений и анимацией изменения цвета при ударе.

---

## 🏗️ Архитектура проекта

### **Core**
> Управляет инициализацией, зависимостями и игровым циклом.
- `App` — точка входа приложения и основной игровой цикл.  
- `AppStartup` — регистрация сервисов через Dependency Injection.  
- `EcsStartup` — настройка ECS-миров и систем.  
- `SceneStartup` — создание шарика и стен.

### **View**
> Визуальный слой на Avalonia.
- `Scene` / `ISceneService` — управление объектами на сцене.  
- `SceneObject` — базовый класс визуальных элементов.  
- `Ball`, `Wall` — конкретные реализации.

### **Components**
> Хранят состояние сущностей ECS.
- `PositionComponent`, `DirectionComponent`, `SpeedComponent`, `RadiusComponent`  
- `EdgeComponent`, `ColorAnimationComponent`, `LinkToSceneObject`

### **Systems**
> Игровая логика.
- `MoveSystem` — перемещение сущностей.  
- `CheckCollisionSystem` — проверка столкновений.  
- `CollisionHandlingSystem` — отражение направления.  
- `ColorChangeEventHandlingSystem` — реакция на столкновение.  
- `ColorChangeAnimationSystem` — возврат цвета.  
- `PositionSyncSystem` — синхронизация ECS с визуальным миром.

### **Factories**
> Создают сущности ECS и их визуальные представления.
- `BallFactory` — создание шарика.  
- `WallFactory` — создание стен.

### **Data**
> Исходные данные объектов.
- `BallData`, `WallAnimationData`, `ObjectsData`

### **Constants**
> Глобальные параметры.
- `GameConstants` — фиксированные значения таймингов и дельты времени.

---

## ⚙️ Игровой цикл

Игровой цикл выполняется в классе `App` и состоит из трёх фаз:

1. **ECS Update** — обновление всех систем.  
2. **Render** — синхронизация с UI и отрисовка.  
3. **Delay** — пауза между кадрами.

```
ECS → Logic Update → Render → Sleep → Repeat
```

---

## 💡 Технологии

| Технология | Назначение |
|-------------|-------------|
| **C# 12 / .NET 8** | Язык и платформа |
| **Avalonia UI** | Отрисовка и интерфейс |
| **LeoEcsLite** | Архитектура ECS |
| **Microsoft.Extensions.DependencyInjection** | Внедрение зависимостей |
| **Doxygen** | Генерация документации |

---

## 📁 Структура проекта

```
BHS/
├── Core/           # Основная логика
├── View/           # Визуальный слой
├── Systems/        # ECS-системы
├── Components/     # ECS-компоненты
├── Factories/      # Фабрики объектов
├── Data/           # Исходные данные
├── Constants/      # Константы
└── App.axaml       # Разметка Avalonia
```

---

## 📘 Документация

Сгенерировать документацию Doxygen:

```bash
doxygen Doxyfile
```

Результат:  
`Output/html/index.html`

---

## 👨‍💻 Автор

**BHS Core Developer**  
Проект создан для учебной практики и демонстрации архитектуры ECS в .NET.