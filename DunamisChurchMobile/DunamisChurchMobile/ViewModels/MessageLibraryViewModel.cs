using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DunamisChurchMobile.Models;

namespace DunamisChurchMobile.ViewModels
{
    class MessageLibraryViewModel: BaseViewModel
    {
        //default channel ID set to that of DunamisTV
        public static string channelID = "UC0pFEFO86OwhVUcqAQ4ICjQ";
        private string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=50&channelId=" + channelID +"&key=AIzaSyADgBl2wj41IAAF19EgiYv3TeOMUfrQ_VA";

        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
           + "{0}" + "&key=AIzaSyADgBl2wj41IAAF19EgiYv3TeOMUfrQ_VA";

        private List<YoutubeItem> _youtubeItems;

        public List<YoutubeItem> YoutubeItems
        {
            get { return _youtubeItems; }
            set
            {
                _youtubeItems = value;
                OnPropertyChanged();
            }
        }
        public MessageLibraryViewModel(string ChannelID)
        {
            //sets the new channel ID and apiUrlForChannel appropriately to that provided by that provided by the new page using this viewModel
            channelID = ChannelID;
            apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=50&channelId=" + channelID + "&key=AIzaSyADgBl2wj41IAAF19EgiYv3TeOMUfrQ_VA";
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {

            var videoIds = await GetVideoIdsFromChannelAsync();

        }

        //API call to get videos from the channel
        private async Task<List<string>> GetVideoIdsFromChannelAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForChannel);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("id")?.Value<string>("videoId"));
                }

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

       
        //API call to get a particular video from the channel
        private async Task<List<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new List<YoutubeItem>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");

                    var youtubeItem = new YoutubeItem
                    {
                        Title = snippet.Value<string>("title"),
                        Description = snippet.Value<string>("description"),
                        ChannelTitle = snippet.Value<string>("channelTitle"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                        ViewCount = statistics?.Value<int>("viewCount"),
                        LikeCount = statistics?.Value<int>("likeCount"),
                        DislikeCount = statistics?.Value<int>("dislikeCount"),
                        FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        CommentCount = statistics?.Value<int>("commentCount"),

                        Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList(),
                    };

                    youtubeItems.Add(youtubeItem);
                }

                return youtubeItems;
            }
            catch (Exception exception)
            {
                return youtubeItems;
            }
        }
    }
}
