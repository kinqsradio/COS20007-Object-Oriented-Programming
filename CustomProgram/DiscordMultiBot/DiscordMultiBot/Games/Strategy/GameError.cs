using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class GameError : GameStrategy
    {
        public override int CounterStrategy(List<Square> square, Random random)
        {
            return -1;
        }

    }
}
