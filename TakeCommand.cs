using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "take" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text[0] != "take")
            {
                return "Cannot take like this";
            }
            if(text.Length != 2)
            {
                return "I don't know how to take like this";
            }
            else
            {
                Item item = p.Location.Inventory.Fetch(text[1]);

                if(item != null)
                {
                    p.Inventory.Put(item);
                    p.Location.Inventory.Take(text[1]);
                    return "Item " + item.FirstId +" successfully taken into inventory";
                }
                else
                {
                    return "Could not find the item.";
                }
            }
        }
    }
}
