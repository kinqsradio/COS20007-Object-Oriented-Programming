using DiscordMultiBot.Games;
using DiscordMultiBot.Games.Strategy;
using DiscordMultiBot.Maths;
using DiscordMultiBot.youtube.State;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot
{
    class Factory
    {
        private static Factory instance;

        public static Factory Instance()
        {
            if (instance == null)
            {
                instance = new Factory();
            }
            return instance;
        }

        public string InstantiateJson(string choice)
        {
            switch (choice)
            {
                case "token":
                    return new Readjson("token").ReadFromJson();
                case "ytapi":
                    return new Readjson("ytapi").ReadFromJson();
                case "sql":
                    return new Readjson("sql").ReadFromJson();
                default:
                    return "Not Found!";
            }
        }

        public DiscordConfiguration InstantiateConfig()
        {
            var config = new DiscordConfiguration
            {
                Token = Instance().InstantiateJson("token"),
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };
           
            return config;
        }

        public DiscordClient InstantiateClient()
        {
            return new DiscordClient(Instance().InstantiateConfig());
        }


        public CommandsNextConfiguration InstantiateCommandsConfig()
        {
            var commandsConfig = new CommandsNextConfiguration
            {
                EnableDms = true,
                EnableMentionPrefix = true,
            };
            return commandsConfig;
        }


        public DiscordEmbedBuilder InstantiateMessage(string result)
        {
            DiscordEmbedBuilder newEmbed;

            //Display Message
            newEmbed = new DiscordEmbedBuilder
            {
                Title = "Results:",
                Description = $"{result}",
                Color = DiscordColor.Black
            };
            return newEmbed;
        }

        public Strategy Strategy(string method)
        {
            switch (method.ToLower())
            {
                case "average":
                    return new Average();
                case "minmax":
                    return new MinMax();
                case "sum":
                    return new Sum();
                case "sub":
                    return new Subtract();
                case "mult":
                    return new Multiplication();
                case "div":
                    return new Divide();
                default:
                    return new Error();
            }
        }

        public GameStrategy GameStrategy(string method)
        {
            switch (method.ToLower())
            {
                case "counterstrat1":
                    return new Strat1();
                case "counterstrat2":
                    return new Strat2();
                case "counterstrat3":
                    return new Strat3();
                case "randominempty":
                    return new PlaceRandomInEmpty();
                case "trywin":
                    return new TryToWin();
                default:
                    return new GameError();
            }
        }

        public GameStrateCase1 InstantiateCanBlockOrWin()
        {
            return new CanBlockOrWin();
        }

        //End Game Strategy

        public IServicesState InstantiateServices(string api)
        {
            if (string.IsNullOrEmpty(api))
            {
                return new NoApiKey();
            }
            else if(api == Instance().InstantiateJson("ytapi"))
            {
                return new HasAPIKey();
            }
            else
            {
                return new NoApiKey();
            }
        }
    }
}