using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class Strat1 : GameStrategy
    {
        public List<int> templateList;

        /* Checks if user tries to trap the ai, by placing x in a corner and then in center across from it. for:
            _X_|___|___
            ___|_O_|___
               | X |
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

            if (templateList.SequenceEqual(new List<int> { 3, 8 }) || templateList.SequenceEqual(new List<int> { 0, 7 }))
            {
                return 6;
            }

            else if(templateList.SequenceEqual(new List<int> { 2, 3 }) || templateList.SequenceEqual(new List<int> { 1, 6 }))
            {
                return 0;
            }

            else if(templateList.SequenceEqual(new List<int> { 0, 5 }) || templateList.SequenceEqual(new List<int> { 1, 8 }))
            {
                return 2;
            }

            else if(templateList.SequenceEqual(new List<int> { 5, 6 }) || templateList.SequenceEqual(new List<int> { 2, 7 }))
            {
                return 8;
            }

            return -1;
        }
    }
}
