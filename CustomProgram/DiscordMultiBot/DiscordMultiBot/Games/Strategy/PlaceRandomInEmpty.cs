using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class PlaceRandomInEmpty : GameStrategy
    {
        public override int CounterStrategy(List<Square> square, Random random)
        {
            int selection;
            do
            {
                selection = random.Next(square.Count);
            } while (square[selection].SquareNumber != 0);


            return selection;
        }
    }
}
