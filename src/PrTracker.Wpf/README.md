# PR Tracker — WPF

Personal-records list + add/edit, built with **WPF** (MVVM) on `net10.0-windows`.
Uses **CommunityToolkit.Mvvm** source generators and a small
`Microsoft.Extensions.DependencyInjection` container set up in `App.xaml.cs`.
`DataGrid` + a modal `RecordEditWindow`.

> **Verify on Windows.** Targets `net10.0-windows`; scaffolded on macOS, cannot compile there.

## Run (on Windows)

```bash
dotnet run --project src/PrTracker.Wpf
```

## Demo

- Start branch: `demo2-wpf-start` (MainWindow is a stub; `IRecordService` registered in DI).
- Done branch: `demo2-wpf-done` (full app — the safety net).

### Live Copilot prompt

> Build a personal-records screen with MVVM using CommunityToolkit.Mvvm. Create a
> `RecordsViewModel` (`ObservableObject`) exposing an `ObservableCollection<PersonalRecord>`
> loaded from `IRecordService`, a `SelectedRecord`, and `[RelayCommand]` Add/Edit/Delete
> (Edit/Delete disabled when nothing is selected). In `MainWindow.xaml` bind a read-only
> `DataGrid` with columns Exercise, Weight (kg), Reps, Date and Add/Edit/Delete buttons. Add a
> modal `RecordEditWindow` with a `RecordEditViewModel` (Exercise, WeightKg, Reps, Date) and
> Save/Cancel. Register the view-models in the DI container in `App.xaml.cs`. Route all changes
> through `IRecordService`.

**Gotcha:** Copilot reaches for dated patterns / code-behind instead of clean MVVM with the
toolkit source generators.
