using DiscordMultiBot.Maths;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.youtube.State
{
    public class NoApiKey : IServicesState
    {
        public Task ToDo(string api, string id)
        {
            return Task.CompletedTask;  
        }
        public string Description()
        {
            string message = "Error: No API Key Found!";
            return message;
        }

        public string Message()
        {
            string message = "Status: Status Down!";
            return message;
        }

    }
}