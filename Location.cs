using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location : GameObject
    {
        private Inventory _inventory;
        private List<Path> _path;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _path = new List<Path>();
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {   
            if (this.AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;

        }

        public Path FindPath(string id)
        {
            foreach (Path path in _path)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return null;
        }

        public void AddPath(Path path)
        {
            _path.Add(path);
        }
        

        public override string FullDescription
        {
            get
            {
                return "You see: " + _inventory.ItemList;
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

    }
}
