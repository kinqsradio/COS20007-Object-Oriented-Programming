using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class GameBot
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public DiscordEmoji BotEmoji { get; set; }
        public int DifficultLevel { get; set; }
        public string Result { get; set; }

        public GameBot(ulong id, string name, DiscordEmoji botEmoji, int difficultLevel)
        {
            Id = id;    
            Name = name;
            BotEmoji = botEmoji;

            if(difficultLevel == 1)
            {
                DifficultLevel = 1;
            }
            else if(difficultLevel == 2) 
            { 
                DifficultLevel = 2; 
            }
            else
            {
                DifficultLevel = 3;
            }
        }

        public void SetGameResult(string result)
        {
            Result = result;    
        }
    }
}
