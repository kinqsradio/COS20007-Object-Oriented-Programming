using System;
using System.Collections.Generic;
using System.Text;
using SwinAdventure;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        Location _source, _destination;
        bool _isBlocked;

        public Path(string[] idents, string name, string desc, Location source, Location destination) : base(idents, name, desc)
        {
            _source = source;
            _destination = destination;
            _isBlocked = false;

            AddIdentifier("path");
            foreach(string s in name.Split(" "))
            {
                AddIdentifier(s);
            }
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public override string ShortDescription
        {
            get => Name;
        }


        public bool IsBlocked
        {
            get { return _isBlocked; }
            set { _isBlocked = value; }
        }
    }
}
