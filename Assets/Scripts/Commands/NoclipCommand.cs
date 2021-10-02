using System.Collections.Generic;
using qASIC.Console.Commands;
using UnityEngine;
using Player;

namespace Commands
{
    public class NoclipCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "noclip";
        public override string Description { get; } = "enables noclip";
        public override string Help { get; } = "Use noclip; noclip <value>";
        public override string[] Aliases { get; } = new string[] { "nc" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0, 1)) return;
            bool value;
            switch(args.Count)
            {
                case 2:
                    if (bool.TryParse(args[1], out value)) break;
                    ParseException(args[1], "bool");
                    return;
                default:
                    value = !PlayerMovementController.Noclip;
                    break;
            }

            PlayerMovementController.Noclip = value;

            ChangeCollisionState(value);

            Log($"Noclip has been {(value ? "enabled" : "disabled")}", "cheat");
        }

        void ChangeCollisionState(bool state)
        {
            for (int i = 0; i < 32; i++)
            {
                if (string.IsNullOrWhiteSpace(LayerMask.LayerToName(i))) continue;
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), i, state);
            }
        }
    }
}