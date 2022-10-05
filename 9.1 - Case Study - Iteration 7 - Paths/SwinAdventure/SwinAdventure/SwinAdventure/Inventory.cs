using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

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

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item takeitem = this.Fetch(id);
            _items.Remove(takeitem);
            return takeitem;

            //foreach (Item i in _items)
            //{
            //    if (i.AreYou(id))
            //    {
            //        Item Found = i;
            //        _items.Remove(i);
            //        return Found;

            //    }
            //}
            //return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string listitm = "";
                foreach (Item i in _items)
                {
                    listitm = listitm + i.ShortDescription + "\n";
                }
                return listitm;
            }
        }

		public int Count
		{
			get { return _items.Count; }
		}
	}
}

