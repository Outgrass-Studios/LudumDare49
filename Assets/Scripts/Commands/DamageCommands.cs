using System.Collections.Generic;
using qASIC.Console.Commands;
using Entity;

namespace Commands
{
    public class HurtCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "hurt";
        public override string Description { get; } = "Hurt player";
        public override string Help { get; } = "Hurt player: hurt <hurtpoints>";
        public override string[] Aliases { get; } = new string[] { "" };

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
    public class HealCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "heal";
        public override string Description { get; } = "Heal player";
        public override string Help { get; } = "Heal player: hurt <hurtpoints>";
        public override string[] Aliases { get; } = new string[] { "" };

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
    public class KillCommand : GameConsoleCommand
    {
        public override string CommandName { get; } = "kill";
        public override string Description { get; } = "Kill player";
        public override string Help { get; } = "Kill player";
        public override string[] Aliases { get; } = new string[] { "" };

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 0)) return;
            Player.PlayerReference.Singleton.damage.Kill();
        }
    }
}