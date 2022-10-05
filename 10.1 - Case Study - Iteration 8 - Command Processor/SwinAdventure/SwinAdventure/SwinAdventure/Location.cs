using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private string _name, _desc;
        List<Path> _paths;

        public Location(string name, string desc) : base(new string[] { "location"}, name, desc)
        {
            _inventory = new Inventory();
           // _name = name;
           // _desc = desc;
            _paths = new List<Path>();
        }

        public Location(string name, string desc, List<Path> paths) : this(name, desc)
        {
            _paths = paths;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
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

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

    }
}