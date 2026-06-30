using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PrTracker.Core;
using PrTracker.Wpf.Views;

namespace PrTracker.Wpf.ViewModels;

/// <summary>
/// Main list view-model: owns the observable collection of records and the
/// Add/Edit/Delete commands. All mutations round-trip through <see cref="IRecordService"/>
/// and then refresh the list.
/// </summary>
public partial class RecordsViewModel : ObservableObject
{
    private readonly IRecordService _service;

    public RecordsViewModel(IRecordService service)
    {
        _service = service;
        Records = new ObservableCollection<PersonalRecord>();
        Reload();
    }

    public ObservableCollection<PersonalRecord> Records { get; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
    private PersonalRecord? _selectedRecord;

    private bool HasSelection => SelectedRecord is not null;

    /// <summary>Re-reads the full list from the service into the observable collection.</summary>
    private void Reload()
    {
        var previousId = SelectedRecord?.Id;

        Records.Clear();
        foreach (var record in _service.GetAll())
        {
            Records.Add(record);
        }

        SelectedRecord = previousId is { } id
            ? Records.FirstOrDefault(r => r.Id == id)
            : null;
    }

    [RelayCommand]
    private void Add()
    {
        var editVm = App.Current.Services.GetRequiredService<RecordEditViewModel>();
        editVm.LoadNew();

        if (ShowEditor(editVm))
        {
            var created = _service.Add(editVm.ToRecord());
            Reload();
            SelectedRecord = Records.FirstOrDefault(r => r.Id == created.Id);
        }
    }

    [RelayCommand(CanExecute = nameof(HasSelection))]
    private void Edit()
    {
        if (SelectedRecord is null)
        {
            return;
        }

        var editVm = App.Current.Services.GetRequiredService<RecordEditViewModel>();
        editVm.Load(SelectedRecord);

        if (ShowEditor(editVm))
        {
            _service.Update(editVm.ToRecord());
            Reload();
        }
    }

    [RelayCommand(CanExecute = nameof(HasSelection))]
    private void Delete()
    {
        if (SelectedRecord is null)
        {
            return;
        }

        _service.Delete(SelectedRecord.Id);
        Reload();
    }

    /// <summary>Shows the modal edit window and returns true if the user saved.</summary>
    private static bool ShowEditor(RecordEditViewModel editVm)
    {
        var window = new RecordEditWindow
        {
            DataContext = editVm,
            Owner = App.Current.MainWindow,
        };

        return window.ShowDialog() == true;
    }
}
