using CommunityToolkit.Mvvm.ComponentModel;
using PrTracker.Core;

namespace PrTracker.Wpf.ViewModels;

/// <summary>
/// Editable representation of a single <see cref="PersonalRecord"/>, used by the
/// detail editor for both "add" and "edit" flows.
/// </summary>
public partial class RecordEditViewModel : ObservableObject
{
    /// <summary>The id of the record being edited; 0 means a brand-new record.</summary>
    public int Id { get; private set; }

    [ObservableProperty]
    private string _title = "Add Record";

    [ObservableProperty]
    private string _exercise = string.Empty;

    [ObservableProperty]
    private double _weightKg;

    [ObservableProperty]
    private int _reps = 1;

    [ObservableProperty]
    private DateTime _date = DateTime.Today;

    /// <summary>Resets the form for creating a new record.</summary>
    public void LoadNew()
    {
        Id = 0;
        Title = "Add Record";
        Exercise = string.Empty;
        WeightKg = 0;
        Reps = 1;
        Date = DateTime.Today;
    }

    /// <summary>Populates the form from an existing record.</summary>
    public void Load(PersonalRecord record)
    {
        Id = record.Id;
        Title = "Edit Record";
        Exercise = record.Exercise;
        WeightKg = record.WeightKg;
        Reps = record.Reps;
        Date = record.Date.ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>Materialises the current form state into an immutable record.</summary>
    public PersonalRecord ToRecord() =>
        new(Id, Exercise.Trim(), WeightKg, Reps, DateOnly.FromDateTime(Date));
}
