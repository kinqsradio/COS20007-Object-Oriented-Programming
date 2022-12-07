using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public static class GameEmoji
    {
        public static DiscordEmoji X;
        public static DiscordEmoji O;
        public static DiscordEmoji Field;
        public static DiscordEmoji One;
        public static DiscordEmoji Two;
        public static DiscordEmoji Three;
        public static DiscordEmoji Four;
        public static DiscordEmoji Five;
        public static DiscordEmoji Six;
        public static DiscordEmoji Seven;
        public static DiscordEmoji Eight;
        public static DiscordEmoji Nine;

        public static void InitEmoji(CommandContext ctx)
        {
            X = BuildEmoji(ctx, ":regional_indicator_x:");
            O = BuildEmoji(ctx, ":o2:");
            Field = BuildEmoji(ctx, ":black_large_square:");
            One = BuildEmoji(ctx, ":one:");
            Two = BuildEmoji(ctx, ":two:");
            Three = BuildEmoji(ctx, ":three:");
            Four = BuildEmoji(ctx, ":four:");
            Five = BuildEmoji(ctx, ":five:");
            Six = BuildEmoji(ctx, ":six:");
            Seven = BuildEmoji(ctx, ":seven:");
            Eight = BuildEmoji(ctx, ":eight:");
            Nine = BuildEmoji(ctx, ":nine:");
        }

        private static DiscordEmoji BuildEmoji(CommandContext ctx, string emoji)
        {
            return DiscordEmoji.FromName(ctx.Client, emoji);
        }

        // Returns a list of all the emojies.
        public static List<DiscordEmoji> OneThroughNine()
        {
            return new List<DiscordEmoji>
            {
                One, Two, Three,
                Four, Five, Six,
                Seven, Eight, Nine
            };
        }
    }
}