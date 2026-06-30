# PR Tracker — WinForms

Personal-records list + add/edit, built with **Windows Forms** on `net10.0-windows`.
`DataGridView` bound to a `BindingList<PersonalRecord>`, with an `EditForm` dialog.
Service (`IRecordService`) is constructed directly in `Program.cs` (no DI).

> **Verify on Windows.** This project targets `net10.0-windows` and was scaffolded on
> macOS; it cannot compile on a Mac.

## Run (on Windows)

```bash
dotnet run --project src/PrTracker.WinForms
```

## Demo

- Start branch: `demo1-winforms-start` (MainForm is a stub; the service is already injected).
- Done branch: `demo1-winforms-done` (full app — the safety net).

### Live Copilot prompt

> In `MainForm`, build a personal-records screen. Add a read-only `DataGridView` docked to
> fill the form, bound to a `BindingList<PersonalRecord>` populated from the injected
> `IRecordService.GetAll()`, with columns Exercise, Weight (kg), Reps and Date. Add a bottom
> panel with **Add**, **Edit** and **Delete** buttons. Add opens a modal `EditForm` (TextBox
> for Exercise, NumericUpDowns for Weight and Reps, a DateTimePicker for Date, OK/Cancel) for
> a new record; Edit opens it for the selected row; Delete confirms then removes via the
> service. After every change, reload the binding list from the service so the grid stays in sync.

**Gotcha:** Copilot can't see `MainForm.Designer.cs`, so the generated layout drifts from
the designer-defined controls.
