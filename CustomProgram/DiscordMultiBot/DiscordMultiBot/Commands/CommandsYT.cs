using DiscordMultiBot.Maths;
using DiscordMultiBot.youtube;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Commands
{
    public class CommandsYT : BaseCommandModule
    {
        [Command("yt")]
        [Description("Get YouTube Video Details")]
        public async Task yt(CommandContext ctx, [Description("YouTube Video ID")] string id)
        {
            await ctx.TriggerTypingAsync();
            Services youtubeService = new Services(ctx, id);
            await youtubeService.SendingMessage();
        }
    }
}
