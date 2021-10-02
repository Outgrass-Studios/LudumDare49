using System.Collections.Generic;
using qASIC.Console.Commands;

namespace Commands
{
    public class TaskCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "remainingtasks";
        public override string Description { get; } = "changes remaining tasks ammount";
        public override string Help { get; } = "Use remainingtasks; remainingtasks <value>";
        public override string[] Aliases { get; } = new string[] { "tasks" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0, 1)) return;

            if (CartController.Singleton == null)
            {
                LogError("Cart is not assigned!");
                return;
            }

            switch (args.Count)
            {
                case 2:
                    if (!int.TryParse(args[1], out int ammount))
                    {
                        ParseException(args[1], "int");
                        return;
                    }

                    CartController.Singleton.remainingTasks = ammount;
                    Log($"Changed remaining tasks to {ammount}", "cheat");
                    break;
                default:
                    Log($"Remaining tasks: {CartController.Singleton.remainingTasks}", "cheat");
                    break;
            }
        }
    }
}