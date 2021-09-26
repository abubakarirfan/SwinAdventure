using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        {

        }

        abstract public string Execute(Player p, string[] text); 
    }
}
