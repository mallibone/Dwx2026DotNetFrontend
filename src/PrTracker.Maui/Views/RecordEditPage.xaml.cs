using PrTracker.Maui.ViewModels;

namespace PrTracker.Maui.Views;

public partial class RecordEditPage : ContentPage
{
    public RecordEditPage(RecordEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
