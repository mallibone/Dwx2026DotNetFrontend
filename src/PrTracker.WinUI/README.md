# PR Tracker — WinUI 3

Personal-records master/detail, built with **WinUI 3 / Windows App SDK** on
`net10.0-windows10.0.19041.0` (unpackaged). `ListView` + detail pane with compiled
`x:Bind`, Fluent default styling, a hand-rolled `MainViewModel` over `IRecordService`.

> **Verify on Windows.** Targets `net10.0-windows10.0.19041.0` and needs the Windows App SDK
> workload; scaffolded on macOS, cannot compile there.

## Run (on Windows)

```bash
dotnet run --project src/PrTracker.WinUI -f net10.0-windows10.0.19041.0
```

## Demo

- Start branch: `demo3-winui-start` (MainWindow hosts a stub `MainPage`; the service is instantiated).
- Done branch: `demo3-winui-done` (full app — the safety net).

### Live Copilot prompt

> Build a master/detail personal-records screen using WinUI 3 (Windows App SDK,
> `Microsoft.UI.Xaml`). Host the UI in a `MainPage` (a `Page`) and set it as the window
> content from `MainWindow` (`Content = new MainPage();`). In `MainPage.xaml` add a `ListView`
> on the left bound with compiled `x:Bind` to a view-model's `ObservableCollection<PersonalRecord>`
> (template shows Exercise plus weight/reps/date), and a detail pane on the right with a `TextBox`
> (Exercise), two `NumberBox` (Weight, Reps), a `DatePicker` (Date) and Add/Save/Delete buttons.
> Hide the detail pane when nothing is selected via a `NullToVisibilityConverter` registered in
> `App.xaml`. Back it with a `MainViewModel` over `IRecordService`. Use Fluent default styling.
> Do not use any UWP (`Windows.UI.Xaml`) namespaces.

**Gotcha:** Copilot mixes up UWP and WinUI 3 namespaces / APIs.
