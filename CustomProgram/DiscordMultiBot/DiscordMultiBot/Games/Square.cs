using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class Square
    {

        public Square(DiscordEmoji squareEmoji, int squareNumber)
        {
            SquareEmoji = squareEmoji;
            SquareNumber = squareNumber;
        }
        public DiscordEmoji SquareEmoji { get; set; }

        public int SquareNumber { get; set; }


    }
}
