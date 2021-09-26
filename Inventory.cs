using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;
        
        public Inventory()
        {
            _items = new List<Item>();
        }


        //checks if item is present
       public bool HasItem(string id)
       {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
       }

        //Items can be added using Put
        public void Put(Item itm)
        {
            _items.Add(itm);
        }


        //Items can be removed by id using Take
        public Item Take(string id)
        {
            foreach(Item x in _items)
            {
                if (x.AreYou(id))
                {
                    _items.Remove(x);
                    return x;
                }
            }
            return null;
        }


        //locates an item by id (using AreYou) and returns it
        public Item Fetch(string id)
        {
            foreach (Item y in _items)
            {
                if (y.AreYou(id))
                {
                    return y;
                }
            }
            return null;
        }

        public string ItemList
        {
            //fix this.
            get
            {
                string x = "";
                
                foreach(Item i in _items)
                {
                    x += i.ShortDescription + " \n ";
                }

                return x;
            }
        }

    }
}
