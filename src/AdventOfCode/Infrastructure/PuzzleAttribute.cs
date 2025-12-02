namespace AdventOfCode.Infrastructure;

/// <summary>
/// Attribute to mark a command as an Advent of Code puzzle command.
/// Used for auto-registration and command routing.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class PuzzleAttribute : Attribute
{
    public int Year { get; }
    public string Name { get; }

    public PuzzleAttribute(int year, string name)
    {
        Year = year;
        Name = name;
    }
}
