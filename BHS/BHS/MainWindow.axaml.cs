using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Threading;
using BHS.View;

namespace BHS;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public Controls Controls => CanvasRoot.Children;
}