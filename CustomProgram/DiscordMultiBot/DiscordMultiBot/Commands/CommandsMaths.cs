using DiscordMultiBot.Maths;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Commands
{
    public class CommandsMaths : BaseCommandModule
    {
        [Command("maths")]
        [Description("There are many maths function such as average, min or max, sum, divide, subtract")]
        public async Task Test(CommandContext ctx, [Description("Maths method: Average, MinMax, Sum, Div, Sub")] string method, [Description("List of number")] params int[] Numbers)
        {
            List<int> numberslist = Numbers.ToList();
            Anaylzer dataanalyser = new Anaylzer(ctx, method, numberslist);
            await dataanalyser.SendingSummarise();
        }
    }
}
