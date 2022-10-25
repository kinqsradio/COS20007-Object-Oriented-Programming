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

		public string PathList
		{
			get
			{
				string list = string.Empty + "\n";

				if (_paths.Count == 1)
				{
					return "There is an exit " + _paths[0].FirstID + ".";
				}

				list = list + "There are exits to the ";

				for (int i = 0; i < _paths.Count; i++)
				{
					if (i == _paths.Count - 1)
					{
						list = list + "and " + _paths[i].FirstID + ".";
					}
					else
					{
						list = list + _paths[i].FirstID + ", ";
					}
				}

				return list;
			}
		}

		public string ItemList
		{
			get
			{
				if (_inventory.Count == 0)
				{
					return string.Empty;
				}
				return "In the room you see:\n" + Inventory.ItemList;
			}
		}

		public override string ShortDescription
		{
			get
			{
				return "You are in a " + Name;
			}
		}

		public override string FullDesciption
        {
            get
			{
                return $"You are at: {base.ShortDescription}\n\nItems at this location:\n{ItemList} {PathList}\n";
				//return base.FullDesciption + "\n" + ItemList + PathList;

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