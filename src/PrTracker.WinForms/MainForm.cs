using System.ComponentModel;
using PrTracker.Core;

namespace PrTracker.WinForms;

/// <summary>
/// Main window: lists every <see cref="PersonalRecord"/> in a grid and lets the
/// user add, edit, or delete entries. All persistence goes through the injected
/// <see cref="IRecordService"/>; the <see cref="BindingList{T}"/> is kept in sync
/// with the service after every mutation.
/// </summary>
public partial class MainForm : Form
{
    private readonly IRecordService _service;
    private readonly BindingList<PersonalRecord> _records = new();

    public MainForm(IRecordService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));

        InitializeComponent();

        _grid.DataSource = _records;
        ReloadRecords();
    }

    /// <summary>Re-reads all records from the service into the binding list.</summary>
    private void ReloadRecords()
    {
        _records.RaiseListChangedEvents = false;
        _records.Clear();
        foreach (var record in _service.GetAll())
        {
            _records.Add(record);
        }
        _records.RaiseListChangedEvents = true;
        _records.ResetBindings();
    }

    private PersonalRecord? SelectedRecord =>
        _grid.CurrentRow?.DataBoundItem as PersonalRecord;

    private void OnAddClicked(object? sender, EventArgs e)
    {
        using var dialog = new EditForm();
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _service.Add(dialog.Record);
            ReloadRecords();
        }
    }

    private void OnEditClicked(object? sender, EventArgs e)
    {
        var selected = SelectedRecord;
        if (selected is null)
        {
            return;
        }

        using var dialog = new EditForm(selected);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _service.Update(dialog.Record);
            ReloadRecords();
        }
    }

    private void OnDeleteClicked(object? sender, EventArgs e)
    {
        var selected = SelectedRecord;
        if (selected is null)
        {
            return;
        }

        var confirm = MessageBox.Show(
            this,
            $"Delete the {selected.Exercise} record?",
            "Confirm delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            _service.Delete(selected.Id);
            ReloadRecords();
        }
    }
}
