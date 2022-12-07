using DSharpPlus.Entities;
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
    public class HasAPIKey : IServicesState
    {
        private VideoDetails result;

        public BaseClientService.Initializer EstasblishConnections(string api)
        {
            var connections = new BaseClientService.Initializer()
            {
                ApiKey = api,
            };
            return connections; 
        }

        public async Task ToDo(string api, string id)
        {
            BaseClientService.Initializer apiConnections = EstasblishConnections(api);
            result = new VideoDetails();
            await result.GetVideoDetails(apiConnections, id);
            
        }

        public string Description()
        {
            string message = "YouTube Video Details";
            return message; 
        }

        public string Message()
        {
            string message = $"Status: {result.Issues()}\n\n" +
                            $"Video ID: {result.videoID()}\n\n" +
                            $"Video is upload on channel: {result.videoChannelTitle()} on {result.PublicDate()}\n\n" +
                            $"Thumbnail URL: {result.ThumbnailURL()}\n\n" +
                            $"Total: {result.ViewCount()} views | {result.LikeCount()} Likes | {result.CommentCount()} Comments\n\n" +
                            $"Video Title: {result.videoTitle()}\n\n" +
                            $"Video Description:\n{result.videoDescription()}";
            return message;
        }


    }
}
