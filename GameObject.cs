using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids,string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                //returns short description of the game object
                return _name;
            }
        }
        public string ShortDescription
        {
            get
            {
                //returns name and first id of game object
                return _name + " " + FirstId;
            }
        }
        public virtual string FullDescription => _description;
    }
}
