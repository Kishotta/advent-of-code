using System.Reflection;
using AdventOfCode.Commands;
using Spectre.Console.Cli;

namespace AdventOfCode.Infrastructure;

/// <summary>
/// Extension methods for auto-registration of puzzle commands.
/// </summary>
public static class CommandRegistrationExtensions
{
    /// <summary>
    /// Auto-registers all puzzle commands found in the current assembly.
    /// Commands must be decorated with <see cref="PuzzleAttribute"/> and inherit from <see cref="AsyncCommand{TSettings}"/>
    /// where TSettings inherits from <see cref="PuzzleSettings"/>.
    /// </summary>
    public static IConfigurator RegisterPuzzleCommands(this IConfigurator configurator)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var puzzleCommands = assembly.GetTypes()
            .Where(type => type.GetCustomAttribute<PuzzleAttribute>() is not null)
            .Where(type => typeof(ICommand).IsAssignableFrom(type))
            .Select(type => new
            {
                Type = type,
                Attribute = type.GetCustomAttribute<PuzzleAttribute>()!
            })
            .GroupBy(x => x.Attribute.Year)
            .OrderBy(g => g.Key);

        foreach (var yearGroup in puzzleCommands)
        {
            configurator.AddBranch(yearGroup.Key.ToString(), year =>
            {
                foreach (var puzzle in yearGroup.OrderBy(p => p.Attribute.Name))
                {
                    var addCommandMethod = typeof(IConfigurator<CommandSettings>)
                        .GetMethod("AddCommand")
                        ?.MakeGenericMethod(puzzle.Type);

                    if (addCommandMethod is not null)
                    {
                        var commandConfigurator = addCommandMethod.Invoke(year, [puzzle.Attribute.Name]);
                    }
                }
            });
        }

        return configurator;
    }
}
