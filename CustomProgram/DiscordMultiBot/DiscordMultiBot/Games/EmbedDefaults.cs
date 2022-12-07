using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    // Defaults for the embed in both MP and SP

    public static class EmbedDefaults
    {
        public static string Title;
        public static string PlayerAndEmoji;

        public static void SetEmbedDefaultsMP(Player p1, Player p2)
        {
            Title = $"{p1.Name} playing agaist {p2.Name}";
            PlayerAndEmoji = $"{p1.Name}: {p1.PlayerEmoji}\n" +
                             $"{p2.Name}: {p2.PlayerEmoji}";
        }

        public static void SetEmbedDefaultsSP(Player p1, GameBot ai)
        {
            Title = $"{p1.Name} playing against {ai.Name}";
            PlayerAndEmoji = $"{p1.Name}: {p1.PlayerEmoji}\n" +
                             $"{ai.Name}: {ai.BotEmoji}\nDifficulty: {ai.DifficultLevel}";
        }
    }
}
