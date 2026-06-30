# PR Tracker — One App, Five .NET Frontends

Demo code for the talk **".NET Frontends in 2026"** (DWX 2026).

The same little app — a **Personal Record tracker** for strength-training lifts (log an
exercise, its weight, reps and date; list / add / edit / delete) — built **five times** on
top of one shared domain library, once per .NET UI framework:

| Project | Framework | Style | Runs on |
|---|---|---|---|
| [`PrTracker.WinForms`](src/PrTracker.WinForms) | Windows Forms | `DataGridView` + dialog, no DI | Windows |
| [`PrTracker.Wpf`](src/PrTracker.Wpf) | WPF | MVVM, CommunityToolkit.Mvvm + DI | Windows |
| [`PrTracker.WinUI`](src/PrTracker.WinUI) | WinUI 3 / Windows App SDK | master-detail, compiled `x:Bind` | Windows |
| [`PrTracker.Maui`](src/PrTracker.Maui) | .NET MAUI | Shell + MVVM (+ MauiReactor variant) | Android / iOS / Mac Catalyst |
| [`PrTracker.Blazor`](src/PrTracker.Blazor) | Blazor Web App (Interactive Auto) | server + WASM client | any OS |

Every UI talks to the **same interface**, so you can compare the frameworks side by side
without the business logic getting in the way.

## The shared core

[`PrTracker.Core`](src/PrTracker.Core) (`net10.0`) holds the entire "app" the UIs share:

```csharp
public record PersonalRecord(int Id, string Exercise, double WeightKg, int Reps, DateOnly Date);

public interface IRecordService
{
    IReadOnlyList<PersonalRecord> GetAll();
    PersonalRecord? Get(int id);
    PersonalRecord Add(PersonalRecord record);   // assigns a new Id
    void Update(PersonalRecord record);
    void Delete(int id);
}
```

It ships with an in-memory `InteractiveServer` implementation (`InMemoryRecordService`) and a
small test project under [`tests/`](tests). No database, no network — the point is the UI.

## Prerequisites

- **.NET 10 SDK** ([download](https://dotnet.microsoft.com/download))
- Per framework:
  - **WinForms / WPF / WinUI 3** → Windows (WinUI also needs the Windows App SDK workload)
  - **MAUI** → `dotnet workload install maui`, plus a target (Mac Catalyst / iOS / Android)
  - **Blazor** → nothing extra; runs anywhere

> The repo pins **only** the public nuget.org feed (see [`nuget.config`](nuget.config)) so it
> restores cleanly on any machine.

## Run it

```bash
# Blazor — any OS, easiest place to start
dotnet run --project src/PrTracker.Blazor/PrTracker.Blazor

# MAUI on macOS (Mac Catalyst)
dotnet build src/PrTracker.Maui -f net10.0-maccatalyst

# WinForms / WPF (Windows)
dotnet run --project src/PrTracker.WinForms
dotnet run --project src/PrTracker.Wpf

# WinUI 3 (Windows)
dotnet run --project src/PrTracker.WinUI -f net10.0-windows10.0.19041.0
```

The Windows-only projects were scaffolded on macOS and **cannot compile on a Mac** — that's
expected. Each project has its own `README.md` with details, the exact Copilot prompt used in
the talk, and the "gotcha" to watch for with that framework.

## Slides

The slide deck is in this repo: [`202607_DotNetFrontends.pdf`](202607_DotNetFrontends.pdf).

## Repo layout

```
PrTracker.slnx                 solution
src/
  PrTracker.Core/              shared domain (PersonalRecord + IRecordService)
  PrTracker.WinForms/          Windows Forms UI
  PrTracker.Wpf/               WPF UI
  PrTracker.WinUI/             WinUI 3 UI
  PrTracker.Maui/              .NET MAUI UI
  PrTracker.Blazor/            Blazor Web App (server + WASM client)
tests/
  PrTracker.Core.Tests/        tests for the in-memory service
```

`main` contains the **finished** version of every app. The talk was live-coded — each
framework has `demoN-<fw>-start` / `demoN-<fw>-done` branches (see each project's README) that
you can check out to follow along from a stub.

## License

- **Code** — [MIT License](LICENSE)
- **Slides** ([`202607_DotNetFrontends.pdf`](202607_DotNetFrontends.pdf)) — [CC BY 4.0](LICENSE-slides.md)

---

Built for DWX 2026. Questions? Find me at [github.com/mallibone](https://github.com/mallibone).
