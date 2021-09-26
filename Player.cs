using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
            _location = null;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if(_location != null)
            {
                return _location.Locate(id);
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return "You are carrying a: " + _inventory.ItemList; 
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
            }
        }

        public Location Location
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
    }
}
