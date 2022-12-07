using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordMultiBot.Commands;
//$con = mysqli_connect("feenix-mariadb.swin.edu.au","s103995439","160903","s103995439_db");
//Server = feenix-mariadb.swin.edu.au; Database = s103995439_db; User Id = s103995439; Password = 160903;

namespace DiscordMultiBot
{
    class Bot
    {
        public static DiscordClient Client { get; private set; }
        public CommandsNextExtension CommandsNext { get; private set; }
        
        public async Task Run1()
        {

            Client = Factory.Instance().InstantiateClient();

            Client.Ready += OnClientReady;

            var commandsConfig = Factory.Instance().InstantiateCommandsConfig();

            Client.UseInteractivity(new InteractivityConfiguration
            { // Can be tuned to user liking. 2 = 2 minutes.
                Timeout = TimeSpan.FromMinutes(2)
            }
            );

            //Register commands for use
            CommandsNext = Client.UseCommandsNext(commandsConfig);
            CommandsNext.RegisterCommands<CommandsMaths>();
            CommandsNext.RegisterCommands<CommandsTTT>();
            CommandsNext.RegisterCommands<CommandsYT>();

           
            //End Register commands

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }


    }
}
