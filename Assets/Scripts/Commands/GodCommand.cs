using System.Collections.Generic;
using qASIC.Console.Commands;

public class GodCommand : GameConsoleCommand
{
    public override string CommandName { get; } = "god";
    public override string Description { get; } = "enables god mode";
    public override string Help { get; } = "Use god; god <value>";
    
    public override void Run(List<string> args)
    {
        if (!CheckForArgumentCount(args, 0, 1)) return;

        bool value;
        switch (args.Count)
        {
            case 2:
                if (bool.TryParse(args[1], out value)) break;
                ParseException(args[1], "bool");
                return;
            default:
                value = !PlayerDamage.IsGod;
                break;
        }

        PlayerDamage.IsGod = value;
        Log($"God mode has been {(value ? "activated" : "disabled")}", "cheat");
    }
}
