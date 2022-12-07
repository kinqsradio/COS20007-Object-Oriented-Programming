using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class Board
    {
        public List<Square> GameBoard = new List<Square>();

        public Board(DiscordEmoji squareEmoji)
        {

            GameBoard.AddRange(new List<Square>
            {
                new Square(squareEmoji, 0), new Square(squareEmoji, 0), new Square(squareEmoji, 0),
                new Square(squareEmoji, 0), new Square(squareEmoji, 0), new Square(squareEmoji, 0),
                new Square(squareEmoji, 0), new Square(squareEmoji, 0), new Square(squareEmoji, 0)
            });
        }
    }
}
