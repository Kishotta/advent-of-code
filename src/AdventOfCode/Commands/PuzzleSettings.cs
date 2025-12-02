using System.ComponentModel;
using Spectre.Console.Cli;

namespace AdventOfCode.Commands;

/// <summary>
/// Settings for puzzle commands.
/// </summary>
public class PuzzleSettings : CommandSettings
{
    [CommandOption("-i|--input <FILE>")]
    [Description("Path to the input file for the puzzle")]
    public string? InputFile { get; set; }
}
