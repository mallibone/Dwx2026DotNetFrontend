namespace PrTracker.WinForms;

partial class EditForm
{
    /// <summary>Required designer variable.</summary>
    private System.ComponentModel.IContainer components = null!;

    private System.Windows.Forms.Label _exerciseLabel;
    private System.Windows.Forms.TextBox _exerciseTextBox;
    private System.Windows.Forms.Label _weightLabel;
    private System.Windows.Forms.NumericUpDown _weightUpDown;
    private System.Windows.Forms.Label _repsLabel;
    private System.Windows.Forms.NumericUpDown _repsUpDown;
    private System.Windows.Forms.Label _dateLabel;
    private System.Windows.Forms.DateTimePicker _datePicker;
    private System.Windows.Forms.Button _okButton;
    private System.Windows.Forms.Button _cancelButton;

    /// <summary>Clean up any resources being used.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _exerciseLabel = new System.Windows.Forms.Label();
        _exerciseTextBox = new System.Windows.Forms.TextBox();
        _weightLabel = new System.Windows.Forms.Label();
        _weightUpDown = new System.Windows.Forms.NumericUpDown();
        _repsLabel = new System.Windows.Forms.Label();
        _repsUpDown = new System.Windows.Forms.NumericUpDown();
        _dateLabel = new System.Windows.Forms.Label();
        _datePicker = new System.Windows.Forms.DateTimePicker();
        _okButton = new System.Windows.Forms.Button();
        _cancelButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)_weightUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_repsUpDown).BeginInit();
        SuspendLayout();
        //
        // _exerciseLabel
        //
        _exerciseLabel.AutoSize = true;
        _exerciseLabel.Location = new System.Drawing.Point(16, 19);
        _exerciseLabel.Name = "_exerciseLabel";
        _exerciseLabel.Size = new System.Drawing.Size(56, 15);
        _exerciseLabel.TabIndex = 0;
        _exerciseLabel.Text = "Exercise:";
        //
        // _exerciseTextBox
        //
        _exerciseTextBox.Location = new System.Drawing.Point(120, 16);
        _exerciseTextBox.Name = "_exerciseTextBox";
        _exerciseTextBox.Size = new System.Drawing.Size(220, 23);
        _exerciseTextBox.TabIndex = 1;
        //
        // _weightLabel
        //
        _weightLabel.AutoSize = true;
        _weightLabel.Location = new System.Drawing.Point(16, 51);
        _weightLabel.Name = "_weightLabel";
        _weightLabel.Size = new System.Drawing.Size(71, 15);
        _weightLabel.TabIndex = 2;
        _weightLabel.Text = "Weight (kg):";
        //
        // _weightUpDown
        //
        _weightUpDown.DecimalPlaces = 1;
        _weightUpDown.Increment = new decimal(new int[] { 25, 0, 0, 65536 });
        _weightUpDown.Location = new System.Drawing.Point(120, 49);
        _weightUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        _weightUpDown.Name = "_weightUpDown";
        _weightUpDown.Size = new System.Drawing.Size(120, 23);
        _weightUpDown.TabIndex = 3;
        //
        // _repsLabel
        //
        _repsLabel.AutoSize = true;
        _repsLabel.Location = new System.Drawing.Point(16, 83);
        _repsLabel.Name = "_repsLabel";
        _repsLabel.Size = new System.Drawing.Size(36, 15);
        _repsLabel.TabIndex = 4;
        _repsLabel.Text = "Reps:";
        //
        // _repsUpDown
        //
        _repsUpDown.Location = new System.Drawing.Point(120, 81);
        _repsUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        _repsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        _repsUpDown.Name = "_repsUpDown";
        _repsUpDown.Size = new System.Drawing.Size(120, 23);
        _repsUpDown.TabIndex = 5;
        _repsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // _dateLabel
        //
        _dateLabel.AutoSize = true;
        _dateLabel.Location = new System.Drawing.Point(16, 115);
        _dateLabel.Name = "_dateLabel";
        _dateLabel.Size = new System.Drawing.Size(34, 15);
        _dateLabel.TabIndex = 6;
        _dateLabel.Text = "Date:";
        //
        // _datePicker
        //
        _datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        _datePicker.Location = new System.Drawing.Point(120, 111);
        _datePicker.Name = "_datePicker";
        _datePicker.Size = new System.Drawing.Size(160, 23);
        _datePicker.TabIndex = 7;
        //
        // _okButton
        //
        _okButton.Location = new System.Drawing.Point(184, 156);
        _okButton.Name = "_okButton";
        _okButton.Size = new System.Drawing.Size(75, 28);
        _okButton.TabIndex = 8;
        _okButton.Text = "OK";
        _okButton.UseVisualStyleBackColor = true;
        _okButton.Click += OnOkClicked;
        //
        // _cancelButton
        //
        _cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        _cancelButton.Location = new System.Drawing.Point(265, 156);
        _cancelButton.Name = "_cancelButton";
        _cancelButton.Size = new System.Drawing.Size(75, 28);
        _cancelButton.TabIndex = 9;
        _cancelButton.Text = "Cancel";
        _cancelButton.UseVisualStyleBackColor = true;
        //
        // EditForm
        //
        AcceptButton = _okButton;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        CancelButton = _cancelButton;
        ClientSize = new System.Drawing.Size(356, 200);
        Controls.Add(_exerciseLabel);
        Controls.Add(_exerciseTextBox);
        Controls.Add(_weightLabel);
        Controls.Add(_weightUpDown);
        Controls.Add(_repsLabel);
        Controls.Add(_repsUpDown);
        Controls.Add(_dateLabel);
        Controls.Add(_datePicker);
        Controls.Add(_okButton);
        Controls.Add(_cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EditForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Edit Record";
        ((System.ComponentModel.ISupportInitialize)_weightUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)_repsUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
