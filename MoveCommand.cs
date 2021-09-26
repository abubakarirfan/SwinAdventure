using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            Location location = player.Location;
            if (text.Length != 2)
            {
                return "Cannot move like this.";
            }

            if(text[0] != "move" && text[0] != "go" && text[0] != "head" && text[0] != "leave")
            {
                return "I cannot move like this.";
            }

            string y = text[1];
            Path x = location.FindPath(y);

            if(x == null)
            {
                return "I cannot move the player to " + y;
            }
            else
            {
                x.MovePlayer(player);
                return "Player moved to " + x.FirstId;
            }
        }


    }
}
