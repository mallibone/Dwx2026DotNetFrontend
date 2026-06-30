# PR Tracker — .NET MAUI

Personal-records list + add/edit, built with **.NET MAUI** (Shell + MVVM) on
`net10.0-android;net10.0-ios;net10.0-maccatalyst`. `RecordsPage` (`CollectionView`,
swipe-to-delete, tap-to-edit) + `RecordEditPage`, **CommunityToolkit.Mvvm** view-models,
Shell route navigation, `IRecordService` registered in `MauiProgram`.

Builds/runs on **macOS** (Mac Catalyst) and other MAUI targets.

## Run

```bash
# Mac Catalyst
dotnet build src/PrTracker.Maui -f net10.0-maccatalyst
# Android / iOS: launch from your IDE onto an emulator/simulator
```

## Demo

- Start branch: `demo4-maui-start` (RecordsPage/RecordEditPage stubbed; VMs + service wired).
- Done branch: `demo4-maui-done` (full app — the safety net). Also on `main`.

### Live Copilot prompt

> Build the records UI. In `RecordsPage.xaml` bind a `CollectionView` to the
> `RecordsViewModel.Records` collection (already wired to `IRecordService`), showing Exercise,
> weight and date per item, with an **Add** toolbar item, swipe-to-delete and tap-to-edit. In
> `RecordEditPage.xaml` bind Entry/DatePicker controls and Save/Cancel buttons to
> `RecordEditViewModel` (Exercise, WeightKg, Reps, Date). Use Shell navigation and
> CommunityToolkit.Mvvm. Don't use Xamarin.Forms-era APIs.

**Gotcha:** Copilot reaches for Xamarin.Forms-era APIs and namespaces.

---

## MauiReactor variant (slides 30–31)

Branch **`demo4b-maui-reactor-done`** has `src/PrTracker.Maui.Reactor` — the same app in
**MauiReactor** (MVU, pure C#, **no XAML**). It's a 60-second "same app, zero XAML" show.

```bash
git checkout demo4b-maui-reactor-done
dotnet build src/PrTracker.Maui.Reactor -f net10.0-maccatalyst
```

---

## DevFlow agent (slide: "DevFlow")

[DevFlow](https://github.com/dotnet/maui-labs/tree/main/src/DevFlow) (dotnet/maui-labs)
lets an AI agent read the **live visual tree** of the running app. It's wired into this
project **behind an opt-in flag** so the repo restores cleanly without the DevFlow feed.

**Wiring (already in the project):**

```xml
<!-- PrTracker.Maui.csproj — Debug + EnableDevFlow only -->
<PackageReference Include="Microsoft.Maui.DevFlow.Agent" />
```
```csharp
// MauiProgram.cs
#if DEVFLOW
    builder.AddMauiDevFlowAgent();
#endif
```

**Enable + run the agent:**

```bash
# 1. install the CLI tool (once)
dotnet tool install -g Microsoft.Maui.Cli --prerelease

# 2. install the DevFlow agent skills into .claude/skills/
maui devflow init

# 3. build & run the app with DevFlow turned on
dotnet build src/PrTracker.Maui -f net10.0-maccatalyst -p:EnableDevFlow=true
#    (then launch it)

# 4. with the app running, let the agent read the live UI
maui devflow ui tree          # dump the live visual tree
maui devflow mcp              # start the MCP server for the AI agent
```

> The `Microsoft.Maui.DevFlow.Agent` package is **not on the public nuget.org feed** this
> repo pins. It's already installed on the demo machine; on a clean machine, add the
> maui-labs / DevFlow feed before building with `-p:EnableDevFlow=true`. Without the flag
> the app builds and runs normally.
