using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DunamisChurchMobile.Models;

namespace DunamisChurchMobile.ViewModels
{
    public class YoutubeViewModel : INotifyPropertyChanged
    {
        public static string channelID= "UCK_Jbyeifa1W5A4Z8uB708w";


        public YoutubeViewModel(string ChannelID)
        {
            channelID = ChannelID;
            apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=49&channelId="
          + channelID
          //+ "Your_ChannelId"
          + "&key="
          + ApiKey;
            InitDataAsync();

        }

        private const string ApiKey = "AIzaSyADgBl2wj41IAAF19EgiYv3TeOMUfrQ_VA";

        private string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=49&channelId="
            + channelID
            //+ "Your_ChannelId"
            + "&key="
            + ApiKey;

        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            //+ "0ce22qhacyo,j8GU5hG-34I,_0aQJHoI1e8"
            //+ "Your_Videos_Id"
            + "&key="
            + ApiKey;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

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



        public async Task InitDataAsync()
        {
            IsBusy = true;
            var videoIds = await GetVideoIdsFromChannelAsync();
            IsBusy = false;
        }

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
                        //DislikeCount = statistics?.Value<int>("dislikeCount"),
                        //FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        //CommentCount = statistics?.Value<int>("commentCount"),

                        //Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList()
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}