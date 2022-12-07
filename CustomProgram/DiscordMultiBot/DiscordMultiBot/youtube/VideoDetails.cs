using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.youtube
{

    public class VideoDetails
    {
        private string _VideoId;
        private string _Description;
        private string _Title;
        private string _ChannelTitle;
        private string _Thumbnail;
        private object _LikeCount;
        private object _ViewCount;
        private object _CommentCount;
        private DateTime? _PublicationDate;
        public async Task GetVideoDetails(BaseClientService.Initializer apiConnections, string id)
        {
            var connections = new YouTubeService(apiConnections);
            using (connections)
            {
                var searchRequest = connections.Videos.List("snippet, contentDetails, statistics");
                searchRequest.Id = id;
                var searchResponse = await searchRequest.ExecuteAsync();

                var youTubeVideo = searchResponse.Items.FirstOrDefault();
                if (youTubeVideo != null)
                {
                    {
                        _VideoId = youTubeVideo.Id;
                        _Description = youTubeVideo.Snippet.Description;
                        _Title = youTubeVideo.Snippet.Title;
                        _ChannelTitle = youTubeVideo.Snippet.ChannelTitle;
                        _PublicationDate = youTubeVideo.Snippet.PublishedAt;
                        _Thumbnail = youTubeVideo.Snippet.Thumbnails.Maxres.Url;
                        _LikeCount = youTubeVideo.Statistics.LikeCount;
                        _CommentCount = youTubeVideo.Statistics.CommentCount;
                        _ViewCount = youTubeVideo.Statistics.ViewCount;
                    };
                }
            }
        }

        public string videoID() { return _VideoId; }
        public string videoDescription() { return _Description; }
        public string videoTitle() { return _Title; }
        public string videoChannelTitle() { return _ChannelTitle; }
        public string ThumbnailURL() { return _Thumbnail; }
        public object LikeCount() { return _LikeCount; }
        public object ViewCount() { return _ViewCount; }
        public object CommentCount() { return _CommentCount; }
        public object PublicDate() { return _PublicationDate; }
        public string Issues() { return "No Errors Found"; }
    }
}
