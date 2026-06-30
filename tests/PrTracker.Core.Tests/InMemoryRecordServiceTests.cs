using PrTracker.Core;
using Xunit;

namespace PrTracker.Core.Tests;

public class InMemoryRecordServiceTests
{
    [Fact]
    public void GetAll_ReturnsEightSeededRecords()
    {
        var service = new InMemoryRecordService();

        Assert.Equal(8, service.GetAll().Count);
    }

    [Fact]
    public void Add_AssignsNewId_AndAppearsInGetAll()
    {
        var service = new InMemoryRecordService();

        var added = service.Add(new PersonalRecord(0, "Overhead Squat", 80, 3, new DateOnly(2026, 6, 1)));

        Assert.True(added.Id > 0);
        Assert.Equal(9, service.GetAll().Count);
        Assert.Contains(service.GetAll(), r => r.Id == added.Id && r.Exercise == "Overhead Squat");
    }

    [Fact]
    public void Update_ReplacesExistingRecord()
    {
        var service = new InMemoryRecordService();

        service.Update(new PersonalRecord(1, "Back Squat", 145, 2, new DateOnly(2026, 6, 7)));

        var updated = service.Get(1);
        Assert.NotNull(updated);
        Assert.Equal(145, updated!.WeightKg);
        Assert.Equal(2, updated.Reps);
    }

    [Fact]
    public void Delete_RemovesRecord()
    {
        var service = new InMemoryRecordService();

        service.Delete(1);

        Assert.Null(service.Get(1));
        Assert.Equal(7, service.GetAll().Count);
    }
}
