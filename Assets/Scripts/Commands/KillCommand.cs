using qASIC.Console.Commands;
using System.Collections.Generic;

namespace Commands
{
    public class KillCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "kill";
        public override string Description { get; } = "kills player";
        public override string Help { get; } = "Kills player";

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0)) return;
            Player.PlayerReference.Singleton.damage.Kill();
        }
    }
}