using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PrTracker.Core;

namespace PrTracker.WinUI;

/// <summary>
/// Master/detail view model over <see cref="IRecordService"/>. Exposes an
/// observable list of <see cref="PersonalRecord"/> plus editable fields for the
/// currently selected (or new) record, and Add / Save / Delete commands.
/// </summary>
public sealed class MainViewModel : INotifyPropertyChanged
{
    private readonly IRecordService _service;

    private PersonalRecord? _selectedRecord;
    private string _exercise = string.Empty;
    private double _weightKg;
    private int _reps;
    private DateTimeOffset _date = DateTimeOffset.Now;

    public MainViewModel() : this(new InMemoryRecordService())
    {
    }

    public MainViewModel(IRecordService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));

        Records = new ObservableCollection<PersonalRecord>(_service.GetAll());

        AddCommand = new RelayCommand(Add);
        SaveCommand = new RelayCommand(Save, () => SelectedRecord is not null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedRecord is not null);

        SelectedRecord = Records.FirstOrDefault();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<PersonalRecord> Records { get; }

    public RelayCommand AddCommand { get; }
    public RelayCommand SaveCommand { get; }
    public RelayCommand DeleteCommand { get; }

    /// <summary>
    /// The record currently selected in the list. Setting it copies its values
    /// into the editable detail fields.
    /// </summary>
    public PersonalRecord? SelectedRecord
    {
        get => _selectedRecord;
        set
        {
            if (SetField(ref _selectedRecord, value))
            {
                if (value is not null)
                {
                    LoadFields(value);
                }

                SaveCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string Exercise
    {
        get => _exercise;
        set => SetField(ref _exercise, value);
    }

    public double WeightKg
    {
        get => _weightKg;
        set => SetField(ref _weightKg, value);
    }

    public int Reps
    {
        get => _reps;
        set => SetField(ref _reps, value);
    }

    public DateTimeOffset Date
    {
        get => _date;
        set => SetField(ref _date, value);
    }

    private void Add()
    {
        var created = _service.Add(
            new PersonalRecord(0, "New Exercise", 0, 1, DateOnly.FromDateTime(DateTime.Today)));

        Records.Add(created);
        SelectedRecord = created;
    }

    private void Save()
    {
        if (SelectedRecord is null)
        {
            return;
        }

        var updated = SelectedRecord with
        {
            Exercise = Exercise,
            WeightKg = WeightKg,
            Reps = Reps,
            Date = DateOnly.FromDateTime(Date.Date),
        };

        _service.Update(updated);

        var index = Records.IndexOf(SelectedRecord);
        if (index >= 0)
        {
            Records[index] = updated;
        }

        // Keep selection on the freshly-saved instance.
        _selectedRecord = updated;
        OnPropertyChanged(nameof(SelectedRecord));
    }

    private void Delete()
    {
        if (SelectedRecord is null)
        {
            return;
        }

        var toRemove = SelectedRecord;
        _service.Delete(toRemove.Id);
        Records.Remove(toRemove);

        SelectedRecord = Records.FirstOrDefault();
    }

    private void LoadFields(PersonalRecord record)
    {
        Exercise = record.Exercise;
        WeightKg = record.WeightKg;
        Reps = record.Reps;
        Date = new DateTimeOffset(record.Date.ToDateTime(TimeOnly.MinValue));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
