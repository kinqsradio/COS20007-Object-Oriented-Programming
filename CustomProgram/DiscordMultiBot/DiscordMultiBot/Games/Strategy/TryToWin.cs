using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class TryToWin : GameStrategy
    {
        public override int CounterStrategy(List<Square> gameGrid, Random random)
        {
            if (gameGrid[0].SquareNumber != 1 && gameGrid[1].SquareNumber != 1 && gameGrid[2].SquareNumber != 1)
            {
                if (gameGrid[0].SquareNumber == 0)
                    return 0;
                if (gameGrid[1].SquareNumber == 0)
                    return 1;
                else
                    return 2;
            }

            // Horizontal row 2
            if (gameGrid[3].SquareNumber != 1 && gameGrid[4].SquareNumber != 1 && gameGrid[5].SquareNumber != 1)
            {
                if (gameGrid[3].SquareNumber == 0)
                    return 3;
                if (gameGrid[4].SquareNumber == 0)
                    return 4;
                else
                    return 5;
            }

            // Horizontal row 3
            if (gameGrid[6].SquareNumber != 1 && gameGrid[7].SquareNumber != 1 && gameGrid[8].SquareNumber != 1)
            {
                if (gameGrid[6].SquareNumber == 0)
                    return 6;
                if (gameGrid[7].SquareNumber == 0)
                    return 7;
                else
                    return 8;
            }

            // Vertical row 1
            if (gameGrid[0].SquareNumber != 1 && gameGrid[3].SquareNumber != 1 && gameGrid[6].SquareNumber != 1)
            {
                if (gameGrid[0].SquareNumber == 0)
                    return 0;
                if (gameGrid[3].SquareNumber == 0)
                    return 3;
                else
                    return 6;
            }

            // Vertical row 2
            if (gameGrid[1].SquareNumber != 1 && gameGrid[4].SquareNumber != 1 && gameGrid[7].SquareNumber != 1)
            {
                if (gameGrid[1].SquareNumber == 0)
                    return 1;
                if (gameGrid[4].SquareNumber == 0)
                    return 4;
                else
                    return 7;
            }

            // Vertical row 3
            if (gameGrid[2].SquareNumber != 1 && gameGrid[5].SquareNumber != 1 && gameGrid[8].SquareNumber != 1)
            {
                if (gameGrid[2].SquareNumber == 0)
                    return 2;
                if (gameGrid[5].SquareNumber == 0)
                    return 5;
                else
                    return 8;
            }

            // Diagonal row 1
            if (gameGrid[0].SquareNumber != 1 && gameGrid[4].SquareNumber != 1 && gameGrid[8].SquareNumber != 1)
            {
                if (gameGrid[0].SquareNumber == 0)
                    return 0;
                if (gameGrid[4].SquareNumber == 0)
                    return 4;
                else
                    return 8;
            }

            // Diagonal row 2
            if (gameGrid[2].SquareNumber != 1 && gameGrid[4].SquareNumber != 1 && gameGrid[6].SquareNumber != 1)
            {
                if (gameGrid[2].SquareNumber == 0)
                    return 2;
                if (gameGrid[4].SquareNumber == 0)
                    return 4;
                else
                    return 6;
            }

            return -1;
        }
    }
}
