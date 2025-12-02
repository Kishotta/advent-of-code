using AdventOfCode.Commands;
using AdventOfCode.Infrastructure;
using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode.Puzzles.Year2025;

/// <summary>
/// Example puzzle command for demonstrating the command structure.
/// </summary>
[Puzzle(2025, "secret-entrance")]
public class SecretEntranceCommand : AsyncCommand<PuzzleSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, PuzzleSettings settings, CancellationToken cancellationToken)
    {
        AnsiConsole.MarkupLine("[bold blue]Advent of Code 2025 - Secret Entrance[/]");
        
        if (settings.InputFile is not null)
        {
            AnsiConsole.MarkupLine($"[green]Input file:[/] {settings.InputFile}");
            
            if (File.Exists(settings.InputFile))
            {
                var content = await File.ReadAllTextAsync(settings.InputFile, cancellationToken);
                AnsiConsole.MarkupLine("[yellow]Input content:[/]");
                AnsiConsole.WriteLine(content);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Input file not found![/]");
                return 1;
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[yellow]No input file specified. Use --input <file> to provide input.[/]");
        }

        // Placeholder for puzzle solution
        AnsiConsole.MarkupLine("[dim]Puzzle solution not yet implemented.[/]");
        
        return 0;
    }
}
