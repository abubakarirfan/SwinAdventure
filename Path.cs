using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _location;

        public Path(string[] id, string name, string desc) : base(id,name,desc)
        {
        }


        public Location Destination
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }


        public void MovePlayer(Player player)
        {
            if (_location != null)
            {
                player.Location = _location;
            }
        }

    }
}
