using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrTracker.Core;

namespace PrTracker.Maui.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecordEditViewModel : ObservableObject
{
    private readonly IRecordService _service;

    public RecordEditViewModel(IRecordService service)
    {
        _service = service;
        Date = DateTime.Today;
    }

    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string exercise = string.Empty;

    [ObservableProperty]
    private double weightKg;

    [ObservableProperty]
    private int reps;

    [ObservableProperty]
    private DateTime date;

    [ObservableProperty]
    private string title = "Add record";

    partial void OnIdChanged(int value)
    {
        if (value <= 0)
        {
            return;
        }

        var existing = _service.Get(value);
        if (existing is null)
        {
            return;
        }

        Title = "Edit record";
        Exercise = existing.Exercise;
        WeightKg = existing.WeightKg;
        Reps = existing.Reps;
        Date = existing.Date.ToDateTime(TimeOnly.MinValue);
    }

    [RelayCommand]
    private async Task Save()
    {
        var date = DateOnly.FromDateTime(Date);
        if (Id <= 0)
        {
            _service.Add(new PersonalRecord(0, Exercise, WeightKg, Reps, date));
        }
        else
        {
            _service.Update(new PersonalRecord(Id, Exercise, WeightKg, Reps, date));
        }

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private Task Cancel() => Shell.Current.GoToAsync("..");
}
