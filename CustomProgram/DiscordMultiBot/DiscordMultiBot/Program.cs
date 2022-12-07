using System;

namespace DiscordMultiBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.Run1().GetAwaiter().GetResult();
        }
    }
}
