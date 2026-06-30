namespace PrTracker.Core;

/// <summary>
/// CRUD access to the personal-record log. Implemented in-memory for the demo;
/// every UI app in this repo talks to this same interface.
/// </summary>
public interface IRecordService
{
    IReadOnlyList<PersonalRecord> GetAll();
    PersonalRecord? Get(int id);

    /// <summary>Adds a record, assigning a new <see cref="PersonalRecord.Id"/>.</summary>
    PersonalRecord Add(PersonalRecord record);

    void Update(PersonalRecord record);
    void Delete(int id);
}
