using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class Strat2 : GameStrategy
    {
        private List<int> templateList;

        /* Checks if user tries to trap the ai, by placing x in a corner and then in the corner across from it:
            _X_|___|___
            ___|_O_|___
               |   | x
        */


        public override int CounterStrategy(List<Square> square, Random random)
        {
            templateList = new List<int>();

            for (int i = 0; i < square.Count; i++)
            {
                if (square[i].SquareNumber == 1)
                {
                    templateList.Add(i);
                }
            }

            if (templateList.SequenceEqual(new List<int> { 0, 8 }))
            {
                return random.Next(0, 2) == 0 ? 3 : 7;
            }
            else if (templateList.SequenceEqual(new List<int> { 2, 6 }))
            {
                return random.Next(0, 2) == 0 ? 1 : 5;
            }

            return -1;
        }

    }
}
