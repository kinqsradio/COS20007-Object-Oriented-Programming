using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.Models
{
    public class PlayerDB
    {
        public PlayerDB(string userId, int wins, int losses, int ties)
        {
            UserId = userId;
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }

        public string UserId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
    }
}
