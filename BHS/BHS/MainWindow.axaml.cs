using Avalonia.Controls;

namespace BHS;

/// <summary>
/// Главное окно приложения, содержащее визуальные элементы сцены.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="MainWindow"/> является корневым контейнером пользовательского интерфейса Avalonia
/// и содержит область сцены (<c>CanvasRoot</c>), где располагаются визуальные объекты —
/// <see cref="BHS.View.SceneObjects.Ball"/> и <see cref="BHS.View.SceneObjects.Wall"/>.
/// </para>
/// <para>
/// Предоставляет доступ к коллекции элементов управления через свойство
/// <see cref="Controls"/>, используемое сценой (<see cref="BHS.View.Scene"/>)
/// для добавления и удаления объектов.
/// </para>
/// </remarks>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Коллекция визуальных элементов, размещённых на сцене.
    /// </summary>
    /// <remarks>
    /// Возвращает коллекцию элементов <see cref="CanvasRoot.Children"/>,
    /// используемую для управления объектами сцены.
    /// </remarks>
    public Controls Controls => CanvasRoot.Children;
}