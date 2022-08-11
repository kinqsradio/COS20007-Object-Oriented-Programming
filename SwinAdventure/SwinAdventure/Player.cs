using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }return _inventory.Fetch(id);
        }

        public override string FullDesciption
        {
            get
            {
                return $"{Name}, you are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }
}

