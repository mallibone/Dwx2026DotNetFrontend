using System.Windows;
using PrTracker.Wpf.ViewModels;

namespace PrTracker.Wpf;

public partial class MainWindow : Window
{
    public MainWindow(RecordsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
