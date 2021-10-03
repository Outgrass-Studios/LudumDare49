using System.Collections.Generic;
using qASIC.Console.Commands;

namespace Commands
{
    public class HurtCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "hurt";
        public override string Description { get; } = "removes health";
        public override string Help { get; } = "hurt <ammount>";

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 1)) return;
            if (!int.TryParse(args[1], out int value))
            {
                ParseException(args[1], "int");
                return;
            }
            Player.PlayerReference.Singleton.damage.Hurt(value);
        }
    }
}