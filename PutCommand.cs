using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if(text[0] != "put")
            {
                return "Cannot execute put command like this";
            }
            if (text.Length != 2)
            {
                return "I don't know how to put in this way";
            }
            else
            {
                Location loc = p.Location;
                Item item = p.Inventory.Fetch(text[1]);

                if (item != null)
                {
                    loc.Inventory.Put(item);
                    p.Inventory.Take(text[1]);
                    return "Item " + item.FirstId + " put at " + loc.FirstId;
                }
                else
                {
                    return "Item " + item.FirstId +" not found";
                }
            }
        }
    }
}
