using DiscordMultiBot.youtube;
using DiscordMultiBot.youtube.State;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot
{
    public interface IServicesState
    {
        Task ToDo(string api, string id);
        string Description();
        string Message();
    }
}
