// See https://aka.ms/new-console-template for more information

using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp<ElfInventoryCommand>();
return app.Run(args);

internal sealed class ElfInventoryCommand : Command<ElfInventoryCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var file = File.ReadAllLines("./input.txt");

        var inventories = new List<int>();
        var total = 0;
        foreach (var line in file)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                inventories.Add(total);
                total = 0;
                continue;
            }

            total += int.Parse(line);
        }

        var table = new Table
        {
            ShowFooters = true
        };
        table.AddColumn("Amount");

        var topThreeTotal = 0;
        foreach (var inventory in inventories.OrderByDescending(i => i).Take(3))
        {
            topThreeTotal += inventory;
            table.AddRow($"{inventory}");
        }

        table.Columns.First()!.Footer($"{topThreeTotal}");
        AnsiConsole.Write(table);
        return 0;
    }
}