namespace PrTracker.Core;

/// <summary>
/// Thread-safe, dependency-free in-memory implementation of <see cref="IRecordService"/>.
/// Seeded with a year's worth of lifting PRs so every demo shows the same data.
/// </summary>
public sealed class InMemoryRecordService : IRecordService
{
    private readonly object _gate = new();
    private readonly List<PersonalRecord> _records;
    private int _nextId;

    public InMemoryRecordService()
    {
        _records = new List<PersonalRecord>
        {
            new(1, "Back Squat",    140, 3, new DateOnly(2025, 7, 12)),
            new(2, "Deadlift",      180, 1, new DateOnly(2025, 9, 3)),
            new(3, "Bench Press",   100, 5, new DateOnly(2025, 10, 21)),
            new(4, "Strict Press",   60, 3, new DateOnly(2025, 11, 18)),
            new(5, "Clean & Jerk",   95, 2, new DateOnly(2026, 1, 9)),
            new(6, "Pull-up (+kg)",  40, 5, new DateOnly(2026, 2, 14)),
            new(7, "Front Squat",   120, 3, new DateOnly(2026, 3, 30)),
            new(8, "Snatch",         75, 2, new DateOnly(2026, 5, 5)),
        };
        _nextId = _records.Count + 1;
    }

    public IReadOnlyList<PersonalRecord> GetAll()
    {
        lock (_gate)
        {
            return _records.ToList();
        }
    }

    public PersonalRecord? Get(int id)
    {
        lock (_gate)
        {
            return _records.FirstOrDefault(r => r.Id == id);
        }
    }

    public PersonalRecord Add(PersonalRecord record)
    {
        lock (_gate)
        {
            var created = record with { Id = _nextId++ };
            _records.Add(created);
            return created;
        }
    }

    public void Update(PersonalRecord record)
    {
        lock (_gate)
        {
            var index = _records.FindIndex(r => r.Id == record.Id);
            if (index >= 0)
            {
                _records[index] = record;
            }
        }
    }

    public void Delete(int id)
    {
        lock (_gate)
        {
            _records.RemoveAll(r => r.Id == id);
        }
    }
}
