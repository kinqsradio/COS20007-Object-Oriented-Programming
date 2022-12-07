using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class Strat3 : GameStrategy
    {
        private List<int> templateList;

        /* Checks if user tries to trap the ai, by placing x in two center blocks that are next to eachother:
           ___|_x_|___
           _x_|_O_|___
              |   | 
       */
        public override int CounterStrategy(List<Square> square, Random random)
        {
            templateList = new List<int>();

            for (int i = 0; i < square.Count; i++)
            {
                if (square[i].SquareNumber == 1)
                    templateList.Add(i);
            }

            if (templateList.SequenceEqual(new List<int> { 1, 3 }))
            {
                return 0;
            }

            else if (templateList.SequenceEqual(new List<int> { 1, 5 }))
            {
                return 2;
            }

            else if (templateList.SequenceEqual(new List<int> { 3, 7 }))
            {
                return 6;
            }

            else if (templateList.SequenceEqual(new List<int> { 5, 7 }))
            {
                return 8;
            }

            return -1;
        }

    }
}
