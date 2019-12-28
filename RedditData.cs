using System;

namespace WebScrape 
{
    public class RedditData
    {
        public string Title { get; set; }
        public string User { get; set; }
        public string Subreddit { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public int Comments { get; set; }
        public bool NSFW { get; set; }
    }
}