using PrTracker.Core;

namespace PrTracker.WinForms;

/// <summary>
/// Modal editor for a single <see cref="PersonalRecord"/>. Used for both
/// creating (pass <c>null</c>) and editing (pass the existing record).
/// On OK the dialog exposes the edited value via <see cref="Record"/>;
/// the caller is responsible for persisting it through the service.
/// </summary>
public partial class EditForm : Form
{
    private readonly int _id;

    /// <summary>
    /// Creates the editor. When <paramref name="existing"/> is <c>null</c> the
    /// dialog produces a new record (Id 0); otherwise it edits the given record.
    /// </summary>
    public EditForm(PersonalRecord? existing = null)
    {
        InitializeComponent();

        if (existing is null)
        {
            _id = 0;
            Text = "Add Record";
            _datePicker.Value = DateTime.Today;
        }
        else
        {
            _id = existing.Id;
            Text = "Edit Record";
            _exerciseTextBox.Text = existing.Exercise;
            _weightUpDown.Value = (decimal)existing.WeightKg;
            _repsUpDown.Value = existing.Reps;
            _datePicker.Value = existing.Date.ToDateTime(TimeOnly.MinValue);
        }
    }

    /// <summary>
    /// The record described by the current input values. Id is 0 for a new
    /// record, or the original Id when editing an existing one.
    /// </summary>
    public PersonalRecord Record => new(
        _id,
        _exerciseTextBox.Text.Trim(),
        (double)_weightUpDown.Value,
        (int)_repsUpDown.Value,
        DateOnly.FromDateTime(_datePicker.Value));

    private void OnOkClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_exerciseTextBox.Text))
        {
            MessageBox.Show(
                this,
                "Please enter an exercise name.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            _exerciseTextBox.Focus();
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
