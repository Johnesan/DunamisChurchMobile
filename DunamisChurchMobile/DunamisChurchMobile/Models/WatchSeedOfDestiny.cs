using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.Models
{
    public class WatchSeedOfDestiny
    {
        public string VideoId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ChannelTitle { get; set; }

        public string DefaultThumbnailUrl { get; set; }

        public string MediumThumbnailUrl { get; set; }

        public string HighThumbnailUrl { get; set; }

        public string StandardThumbnailUrl { get; set; }

        public string MaxResThumbnailUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public int? ViewCount { get; set; }

        public int? LikeCount { get; set; }

        [Ignore]
        public int? DislikeCount { get; set; }

        [Ignore]
        public int? FavoriteCount { get; set; }

        [Ignore]
        public int? CommentCount { get; set; }

        [Ignore]
        public List<string> Tags { get; set; }
    }
}
