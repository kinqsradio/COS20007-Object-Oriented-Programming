using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public abstract class GameStrategy
    {
        public abstract int CounterStrategy(List<Square> square, Random random);   //Games Strategy

    }

    public abstract class GameStrateCase1
    {
        public abstract int BlockOrWin(List<Square> square, int num);   //Games Strategy

    }
}
