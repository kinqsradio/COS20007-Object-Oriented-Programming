using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class Player
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public DiscordEmoji PlayerEmoji { get; set; }
        public string GameResult { get; set; }

        public Player(ulong id, string name, DiscordEmoji playerEmoji)
        {
            Id = id;
            Name = name;
            PlayerEmoji = playerEmoji;
        }

        public void SetGameResult(string result)
        {
            GameResult = result;
        }
    }
}
