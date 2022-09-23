using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        private string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public virtual string FullDesciption
        {
            get
            {
                return _description;
            }
        }

        public virtual string ShortDescription
        {
            get
            {
                return $"{_name} ({FirstID})";
            }
        }

    }
}

