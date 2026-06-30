using PrTracker.Core;

namespace PrTracker.WinForms;

partial class MainForm
{
    /// <summary>Required designer variable.</summary>
    private System.ComponentModel.IContainer components = null!;

    private System.Windows.Forms.DataGridView _grid;
    private System.Windows.Forms.Panel _buttonPanel;
    private System.Windows.Forms.Button _addButton;
    private System.Windows.Forms.Button _editButton;
    private System.Windows.Forms.Button _deleteButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn _exerciseColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _weightColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _repsColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _dateColumn;

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
        _grid = new System.Windows.Forms.DataGridView();
        _exerciseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        _weightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        _repsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        _dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        _buttonPanel = new System.Windows.Forms.Panel();
        _addButton = new System.Windows.Forms.Button();
        _editButton = new System.Windows.Forms.Button();
        _deleteButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _buttonPanel.SuspendLayout();
        SuspendLayout();
        //
        // _grid
        //
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoGenerateColumns = false;
        _grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
        {
            _exerciseColumn,
            _weightColumn,
            _repsColumn,
            _dateColumn
        });
        _grid.Dock = System.Windows.Forms.DockStyle.Fill;
        _grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        _grid.Location = new System.Drawing.Point(0, 0);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(640, 360);
        _grid.TabIndex = 0;
        //
        // _exerciseColumn
        //
        _exerciseColumn.DataPropertyName = "Exercise";
        _exerciseColumn.HeaderText = "Exercise";
        _exerciseColumn.Name = "_exerciseColumn";
        _exerciseColumn.ReadOnly = true;
        //
        // _weightColumn
        //
        _weightColumn.DataPropertyName = "WeightKg";
        _weightColumn.HeaderText = "Weight (kg)";
        _weightColumn.Name = "_weightColumn";
        _weightColumn.ReadOnly = true;
        //
        // _repsColumn
        //
        _repsColumn.DataPropertyName = "Reps";
        _repsColumn.HeaderText = "Reps";
        _repsColumn.Name = "_repsColumn";
        _repsColumn.ReadOnly = true;
        //
        // _dateColumn
        //
        _dateColumn.DataPropertyName = "Date";
        _dateColumn.HeaderText = "Date";
        _dateColumn.Name = "_dateColumn";
        _dateColumn.ReadOnly = true;
        //
        // _buttonPanel
        //
        _buttonPanel.Controls.Add(_addButton);
        _buttonPanel.Controls.Add(_editButton);
        _buttonPanel.Controls.Add(_deleteButton);
        _buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        _buttonPanel.Location = new System.Drawing.Point(0, 360);
        _buttonPanel.Name = "_buttonPanel";
        _buttonPanel.Padding = new System.Windows.Forms.Padding(8);
        _buttonPanel.Size = new System.Drawing.Size(640, 52);
        _buttonPanel.TabIndex = 1;
        //
        // _addButton
        //
        _addButton.Location = new System.Drawing.Point(8, 12);
        _addButton.Name = "_addButton";
        _addButton.Size = new System.Drawing.Size(90, 30);
        _addButton.TabIndex = 0;
        _addButton.Text = "Add";
        _addButton.UseVisualStyleBackColor = true;
        _addButton.Click += OnAddClicked;
        //
        // _editButton
        //
        _editButton.Location = new System.Drawing.Point(104, 12);
        _editButton.Name = "_editButton";
        _editButton.Size = new System.Drawing.Size(90, 30);
        _editButton.TabIndex = 1;
        _editButton.Text = "Edit";
        _editButton.UseVisualStyleBackColor = true;
        _editButton.Click += OnEditClicked;
        //
        // _deleteButton
        //
        _deleteButton.Location = new System.Drawing.Point(200, 12);
        _deleteButton.Name = "_deleteButton";
        _deleteButton.Size = new System.Drawing.Size(90, 30);
        _deleteButton.TabIndex = 2;
        _deleteButton.Text = "Delete";
        _deleteButton.UseVisualStyleBackColor = true;
        _deleteButton.Click += OnDeleteClicked;
        //
        // MainForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(640, 412);
        Controls.Add(_grid);
        Controls.Add(_buttonPanel);
        MinimumSize = new System.Drawing.Size(480, 320);
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "PR Tracker";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _buttonPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
}
