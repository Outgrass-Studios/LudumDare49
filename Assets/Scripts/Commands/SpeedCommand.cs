using System.Collections.Generic;
using Player;
using qASIC.Console.Commands;

namespace Commands
{
    public class SpeedCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "speed";
        public override string Description { get; } = "changes player speed";
        public override string Help { get; } = "Use speed; speed <value>";
        public override string[] Aliases { get; } = new string[] { "sd" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0, 1)) return;
            switch (args.Count)
            {
                case 2:
                    if (!float.TryParse(args[1], out float speed))
                    {
                        ParseException(args[1], "float");
                        return;
                    }

                    PlayerMovementController.Speed = speed;
                    Log($"Changed player speed to {speed}", "cheat");
                    break;
                default:
                    Log($"Current player speed: {PlayerMovementController.Speed}", "cheat");
                    break;
            }
        }
    }
}