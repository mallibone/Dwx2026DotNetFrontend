using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace PrTracker.WinUI;

/// <summary>
/// Converts a non-null value to <see cref="Visibility.Visible"/> and a null
/// value to <see cref="Visibility.Collapsed"/>. Used to hide the detail/edit
/// pane when no record is selected.
/// </summary>
public sealed class NullToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is null ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotSupportedException();
}
