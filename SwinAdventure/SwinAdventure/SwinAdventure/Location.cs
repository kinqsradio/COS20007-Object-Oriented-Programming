using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private string _name,_desc;

        public Location(string name, string desc) : base(new string[] { "location"}, name, desc)
        {
            _inventory = new Inventory();
            _name = name;
            _desc = desc;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDesciption
        {
            get
            {
                return $"\nYou are at {_name}\nRoom Description: {_desc}\n\nItems at this location:\n{Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }
}