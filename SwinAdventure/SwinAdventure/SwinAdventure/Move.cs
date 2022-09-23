using System;

namespace SwinAdventure
{
    public class Move : Command
    {
        public Move() : base(new string[] { "move", "go", "head" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string _moveLocation;
            string error = "Error in move input.";

            switch (text.Length)
            {
                case 1:
                    return "Where do you want to move to?";

                case 2:
                    _moveLocation = text[1].ToLower();
                    break;

                case 3:
                    _moveLocation = text[2].ToLower();
                    break;

                default:
                    return error;
            }

            GameObject _path = p.Location.Locate(_moveLocation);
            if(_path != null)
            {
                p.Move((Path) _path);
            }

            return null;
        }
    }
}

