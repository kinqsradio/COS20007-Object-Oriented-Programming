using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace SwinAdventure
{
    public class Move : Command
    {
        public Move() : base(new string[] { "move" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string error = "Error in move input.";
            string _moveDirection;

            switch (text.Length)
            {
                case 1:
                    return "Move where?";

                case 2:
                    _moveDirection = text[1].ToLower();
                    break;

                case 3:
                    _moveDirection = text[2].ToLower();
                    break;

                default:
                    return error;
            }

            GameObject _path = p.Location.Locate(_moveDirection);
            if (_path != null)
            {
                if (_path.GetType() != typeof(Path))
                {
                    return "Could not find the " + _path.Name;
                }
                p.Move((Path)_path);
                return "You have moved " + _path.FirstID + " through a " + _path.Name + " to the " + p.Location.Name + ".\r\n\n" + p.Location.FullDesciption;
            }
            else
            {
                return error;
            }
        }
    }
}
