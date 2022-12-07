using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Maths
{
    public class Anaylzer
    {
        private List<int> _numbers;
        private Strategy _strategy;
        private CommandContext _ctx;

        public Anaylzer(CommandContext context, string method, List<int> numbers)
        {
            _ctx = context;
            _numbers = numbers;
            _strategy = Factory.Instance().Strategy(method);
        }

        public async Task SendingSummarise()
        {
            string result = _strategy.SendSummary(_numbers);
            var newMessage = Factory.Instance().InstantiateMessage(result);
            DiscordMessage embedMessage = await _ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
        }
    }
}
