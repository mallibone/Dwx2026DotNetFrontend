using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrTracker.Core;
using PrTracker.Maui.Views;

namespace PrTracker.Maui.ViewModels;

public partial class RecordsViewModel : ObservableObject
{
    private readonly IRecordService _service;

    public RecordsViewModel(IRecordService service)
    {
        _service = service;
    }

    public ObservableCollection<PersonalRecord> Records { get; } = new();

    public void Load()
    {
        Records.Clear();
        foreach (var record in _service.GetAll())
        {
            Records.Add(record);
        }
    }

    [RelayCommand]
    private Task Add() => Shell.Current.GoToAsync(nameof(RecordEditPage));

    [RelayCommand]
    private Task Edit(PersonalRecord record) =>
        Shell.Current.GoToAsync($"{nameof(RecordEditPage)}?Id={record.Id}");

    [RelayCommand]
    private void Delete(PersonalRecord record)
    {
        _service.Delete(record.Id);
        Records.Remove(record);
    }
}
