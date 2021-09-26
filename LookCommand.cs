using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look"})
        {  
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5 && text.Length != 1)
            {
                return "I don't know how to look like this";
            }
            if (text.Length == 1)
            {
                return p.Location.FullDescription;
            }
            else
            {
                if(text[0] != "look")
                {
                    return "Error in look input";
                }
                else
                {
                    if(text[1] != "at")
                    {
                        return "What do you want to look at?";
                    }
                    else
                    {
                        if (text.Length == 5)
                        {
                            if (text[3] != "in")
                            {
                                return "What do you want to look in?";
                            }
                            IHaveInventory x = FetchContainer(p, text[4]);
                            if (x == null)
                            {
                                return "I cannot find the " + text[4];
                            }
                            return LookAtIn(text[2], x);
                        }
                        else
                        {
                            return LookAtIn(text[2], p);
                        }

                    }
                }
            }
        }


        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }


        public string LookAtIn(string thingId, IHaveInventory container)
        {    
            if (container.Locate(thingId) == null)
            {
                return "I cannot find the " + thingId + " in the " + container.Name;
            }
            else
            {
                return container.Locate(thingId).FullDescription;
            }
        }
    }
}
