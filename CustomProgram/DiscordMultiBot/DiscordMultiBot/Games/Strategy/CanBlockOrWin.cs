using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Strategy
{
    public class CanBlockOrWin : GameStrateCase1
    {
        // Checks if it can either block the player or win the game going through a series of checks.
        // I'm sure this can be optimized in some way
        public override int BlockOrWin(List<Square> square, int num)
        {
            // Horizontal row 1
            if (square[0].SquareNumber == num && square[1].SquareNumber == num && square[2].SquareNumber == 0 ||
                square[0].SquareNumber == num && square[1].SquareNumber == 0 && square[2].SquareNumber == num ||
                square[0].SquareNumber == 0 && square[1].SquareNumber == num && square[2].SquareNumber == num)
            {
                if (square[0].SquareNumber == 0)
                    return 0;
                else if (square[1].SquareNumber == 0)
                    return 1;
                else
                    return 2;
            }

            // Horizontal row 2
            if (square[3].SquareNumber == num && square[4].SquareNumber == num && square[5].SquareNumber == 0 ||
                square[3].SquareNumber == num && square[4].SquareNumber == 0 && square[5].SquareNumber == num ||
                square[3].SquareNumber == 0 && square[4].SquareNumber == num && square[5].SquareNumber == num)
            {
                if (square[3].SquareNumber == 0)
                    return 3;
                else if (square[4].SquareNumber == 0)
                    return 4;
                else
                    return 5;
            }

            // Horizontal row 3
            if (square[6].SquareNumber == num && square[7].SquareNumber == num && square[8].SquareNumber == 0 ||
                square[6].SquareNumber == num && square[7].SquareNumber == 0 && square[8].SquareNumber == num ||
                square[6].SquareNumber == 0 && square[7].SquareNumber == num && square[8].SquareNumber == num)
            {
                if (square[6].SquareNumber == 0)
                    return 6;
                else if (square[7].SquareNumber == 0)
                    return 7;
                else
                    return 8;
            }

            // Vertical row 1
            if (square[0].SquareNumber == num && square[3].SquareNumber == num && square[6].SquareNumber == 0 ||
                square[0].SquareNumber == num && square[3].SquareNumber == 0 && square[6].SquareNumber == num ||
                square[0].SquareNumber == 0 && square[3].SquareNumber == num && square[6].SquareNumber == num)
            {
                if (square[0].SquareNumber == 0)
                    return 0;
                else if (square[3].SquareNumber == 0)
                    return 3;
                else
                    return 6;
            }

            // Vertical row 2
            if (square[1].SquareNumber == num && square[4].SquareNumber == num && square[7].SquareNumber == 0 ||
                square[1].SquareNumber == num && square[4].SquareNumber == 0 && square[7].SquareNumber == num ||
                square[1].SquareNumber == 0 && square[4].SquareNumber == num && square[7].SquareNumber == num)
            {
                if (square[1].SquareNumber == 0)
                    return 1;
                else if (square[4].SquareNumber == 0)
                    return 4;
                else
                    return 7;
            }

            // Vertical row 3
            if (square[2].SquareNumber == num && square[5].SquareNumber == num && square[8].SquareNumber == 0 ||
                square[2].SquareNumber == num && square[5].SquareNumber == 0 && square[8].SquareNumber == num ||
                square[2].SquareNumber == 0 && square[5].SquareNumber == num && square[8].SquareNumber == num)
            {
                if (square[2].SquareNumber == 0)
                    return 2;
                else if (square[5].SquareNumber == 0)
                    return 5;
                else
                    return 8;
            }

            // Diagonal row 1
            if (square[0].SquareNumber == num && square[4].SquareNumber == num && square[8].SquareNumber == 0 ||
                square[0].SquareNumber == num && square[4].SquareNumber == 0 && square[8].SquareNumber == num ||
                square[0].SquareNumber == 0 && square[4].SquareNumber == num && square[8].SquareNumber == num)
            {
                if (square[0].SquareNumber == 0)
                    return 0;
                else if (square[4].SquareNumber == 0)
                    return 4;
                else
                    return 8;
            }

            // Diagonal row 2
            if (square[2].SquareNumber == num && square[4].SquareNumber == num && square[6].SquareNumber == 0 ||
                square[2].SquareNumber == num && square[4].SquareNumber == 0 && square[6].SquareNumber == num ||
                square[2].SquareNumber == 0 && square[4].SquareNumber == num && square[6].SquareNumber == num)
            {
                if (square[2].SquareNumber == 0)
                    return 2;
                else if (square[4].SquareNumber == 0)
                    return 4;
                else
                    return 6;
            }

            return -1;
        }
    }
}
