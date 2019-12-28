using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using HtmlAgilityPack;

namespace WebScrape
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<RedditData> redditData = new List<RedditData>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = new HtmlDocument();
            document = await web.LoadFromWebAsync("https://old.reddit.com/top/");
            
            var nodes = document.DocumentNode.SelectNodes("//div[@id='siteTable']/div[@data-context='listing']");

            foreach (var n in nodes)
            {
                redditData.Add(new RedditData() {
                    Title = n.SelectSingleNode(".//div/div/p/a").InnerText,
                    User = n.GetAttributeValue("data-author", "Unable to retrieve author of post"),
                    Subreddit = n.GetAttributeValue("data-subreddit-prefixed", "Unable to retrieve subreddit value"),
                    ThumbnailUrl = n.GetAttributeValue("data-url", "Unable to retrieve thumbnail Url"),
                    Comments = int.Parse(n.GetAttributeValue("data-comments-count", "0")),
                    NSFW = bool.Parse(n.GetAttributeValue("data-nsfw", "false"))
                });
            }

            foreach (var r in redditData)
            {
                System.Console.WriteLine("Title: {0}\nUser: {1}\nSubreddit: {2}\nThumbnail: {3}\nComments: {4}\nNSWF: {5}\n---", r.Title, r.User, r.Subreddit, r.ThumbnailUrl, r.Comments, r.NSFW);
            }
                
            System.Console.WriteLine("Finished.");
        }
    }
}
