using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScrape
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = new HtmlDocument();
            document = await web.LoadFromWebAsync("https://old.reddit.com/");
            
            var nodes = document.DocumentNode.SelectNodes("//a[@class='title may-blank ']");

            StringBuilder sb = new StringBuilder();
        
            foreach (var n in nodes)
                sb.Append(string.Format("{0} - {1} in r/{2}\n", n.InnerText, n.Attributes["href"].Value, n.Attributes["href"].Value.Split('/')[2]));

            using (var writer = new System.IO.StreamWriter("output.txt"))
                writer.Write(sb);
                
            System.Console.WriteLine("Finished.");
        }
    }
}
