using System.Collections.Generic;
using Entity;
using qASIC.Console.Commands;

namespace Commands
{
    public class AICommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "ailevel";
        public override string Description { get; } = "changes current AI level";
        public override string Help { get; } = "Use ailevel; ailevel <value>";
        public override string[] Aliases { get; } = new string[] { "ai" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0, 1)) return;
            switch (args.Count)
            {
                case 2:
                    if (!int.TryParse(args[1], out int value))
                    {
                        ParseException(args[1], "int");
                        return;
                    }

                    EntityController.AILevel = value;
                    Log($"Changed AI level to {value}", "entity");
                    break;
                default:
                    Log($"Currenty AI level: {EntityController.AILevel}", "entity");
                    break;
            }
        }
    }
}