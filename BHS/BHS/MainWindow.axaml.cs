using Avalonia.Controls;

namespace BHS;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public Controls Controls => CanvasRoot.Children;
}