using DiscordMultiBot.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class GameAnalyzer
    {
        private GameStrategy _gameStrategy;
        private GameStrateCase1 _gameStrateCase1;
        public GameAnalyzer(string gameStrategy)
        {
            _gameStrategy = Factory.Instance().GameStrategy(gameStrategy);
            _gameStrateCase1 = Factory.Instance().InstantiateCanBlockOrWin();
        }

        public GameAnalyzer()
        {
            _gameStrateCase1 = Factory.Instance().InstantiateCanBlockOrWin();
        }

        public int UsingStrate(List<Square> gameGrid, Random random)
        {
            int result =_gameStrategy.CounterStrategy(gameGrid, random);
            return result;
        }

        public int CanBlockOrWin(List<Square> gameGrid,int num)
        {
            int result = _gameStrateCase1.BlockOrWin(gameGrid, num);
            return result;
        }
    }
}
