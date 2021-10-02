using System.Collections.Generic;
using qASIC.Console.Commands;
using Entity;

namespace Commands
{
    public class ResetEntityCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "resetentity";
        public override string Description { get; } = "Resets all entities";
        public override string Help { get; } = "Resets all entities";
        public override string[] Aliases { get; } = new string[] { "re" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0)) return;
            int listenerNumber = 0;
            if (EntityController.OnEntityReset != null)
            {
                listenerNumber = EntityController.OnEntityReset.GetInvocationList().Length;
                EntityController.OnEntityReset.Invoke();
            }

            Log($"Invoked entity reset on {listenerNumber} entities", "entity");
        }
    }
}