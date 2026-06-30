namespace PrTracker.Core;

/// <summary>
/// A single strength-training personal record (one logged lift).
/// </summary>
public record PersonalRecord(int Id, string Exercise, double WeightKg, int Reps, DateOnly Date);
