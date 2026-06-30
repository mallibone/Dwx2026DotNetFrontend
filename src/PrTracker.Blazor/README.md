# PR Tracker — Blazor

Personal-records list + add/edit, built as a **Blazor Web App (Interactive Auto)** on
`net10.0`. Solution has the server (`PrTracker.Blazor`) and WebAssembly client
(`PrTracker.Blazor.Client`) projects. `Records.razor` (list) + `RecordEdit.razor`
(add/edit) live in the server project and use `@rendermode InteractiveServer`, talking to
a singleton `IRecordService` registered in `Program.cs`.

Builds and runs on **any OS**.

## Run

```bash
dotnet run --project src/PrTracker.Blazor/PrTracker.Blazor
# open the printed http://localhost:catch URL
```

## Demo

- Start branch: `demo5-blazor-start` (Records/RecordEdit are stubs; service injected).
- Done branch: `demo5-blazor-done` (full app — the safety net). Also on `main`.

### Live Copilot prompt

> Build the records UI in this Blazor Web App. In `Records.razor` inject `IRecordService`,
> load `GetAll()` in `OnInitialized`, and render a Bootstrap table (Exercise, Weight (kg),
> Reps, Date) with an **Add record** button (navigates to `/records/new`) and per-row Edit
> (`/records/{id}`) and Delete buttons. In `RecordEdit.razor` build an `EditForm` bound to a
> model (Exercise, WeightKg, Reps, Date) that loads an existing record by `Id`, and on submit
> calls `Add`/`Update` then navigates back to `/records`. Keep the `InteractiveServer` render
> mode that's already on the components.

**Gotcha:** render-mode confusion — Copilot mixes up Server / WebAssembly / Auto, and
interactivity silently doesn't work.
