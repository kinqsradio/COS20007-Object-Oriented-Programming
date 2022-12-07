using DiscordMultiBot.youtube.State;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.youtube
{
    public class Services
    {
        private string _api;
        private string videoID;
        private CommandContext _ctx;
        private IServicesState _state;
        public Services(CommandContext context, string id)
        {
            _api = Factory.Instance().InstantiateJson("ytapi");
            videoID = id;
            _ctx = context; 
            _state = Factory.Instance().InstantiateServices(_api);
        }   
        
        public async Task SendingMessage()
        {
            var result = _state;
            await result.ToDo(_api, videoID);

            string message = $"{result.Description()}\n\n{result.Message()}";

            //await result.GetVideoDetails(_api,videoID);

            Console.WriteLine(message);
            var newMessage = Factory.Instance().InstantiateMessage(message);
            DiscordMessage embedMessage = await _ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
        }
    }
}
