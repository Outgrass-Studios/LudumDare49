using qASIC.Console.Commands;
using System.Collections.Generic;

namespace Commands
{
    public class HealCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "heal";
        public override string Description { get; } = "adds health";
        public override string Help { get; } = "heal <ammount>";

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 1)) return;
            if (!int.TryParse(args[1], out int value))
            {
                ParseException(args[1], "int");
                return;
            }
            Player.PlayerReference.Singleton.damage.Heal(value);
        }
    }
}