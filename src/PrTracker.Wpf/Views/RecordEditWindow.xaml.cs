using System.Windows;
using PrTracker.Wpf.ViewModels;

namespace PrTracker.Wpf.Views;

/// <summary>
/// Modal detail editor for a single record. The view owns only the dialog
/// mechanics (validation + <see cref="Window.DialogResult"/>); all data lives
/// on the bound <see cref="RecordEditViewModel"/>.
/// </summary>
public partial class RecordEditWindow : Window
{
    public RecordEditWindow()
    {
        InitializeComponent();
    }

    private void OnSaveClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not RecordEditViewModel vm)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(vm.Exercise))
        {
            MessageBox.Show(this, "Exercise is required.", "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (vm.WeightKg < 0)
        {
            MessageBox.Show(this, "Weight cannot be negative.", "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (vm.Reps < 1)
        {
            MessageBox.Show(this, "Reps must be at least 1.", "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
    }
}
