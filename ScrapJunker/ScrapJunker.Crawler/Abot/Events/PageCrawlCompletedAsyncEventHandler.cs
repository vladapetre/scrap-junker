using Abot.Crawler;
using HtmlAgilityPack;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using System.IO;
using System.Linq;
using System.Net;

namespace ScrapJunker.Crawler.Abot.Events
{
    public interface IPageCrawlCompletedAsyncEventHandler : IEventHandler
    {

    }

    public class PageCrawlCompletedAsyncEventHandler : BaseEventHandler , IPageCrawlCompletedAsyncEventHandler
    {
        private readonly IStorage _storage;
        private readonly IHttpClientWrapper _httpClientWrapper;

        public PageCrawlCompletedAsyncEventHandler(ILogger logger, IStorage storage, IHttpClientWrapper httpClientWrapper) : base(logger)
        {
            _storage = storage;
            _httpClientWrapper = httpClientWrapper;
        }

        public override void Register<T>(T sender)
        {
            ((IPoliteWebCrawler)sender).PageCrawlCompletedAsync += Sender_PageCrawlCompletedAsync;
        }

        public override void UnRegister<T>(T sender)
        {
            ((IPoliteWebCrawler)sender).PageCrawlCompletedAsync -= Sender_PageCrawlCompletedAsync;
        }

        private void Sender_PageCrawlCompletedAsync(object sender, PageCrawlCompletedArgs e)
        {
            _logger.Log($"Finished crawling page {e.CrawledPage.Uri.AbsoluteUri}");
            if (e.CrawledPage.WebException != null || e.CrawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                _logger.Log($"Failed with exception {e.CrawledPage.HttpWebResponse.StatusCode} - {e.CrawledPage.WebException}");

                if (e.CrawledPage.HttpWebResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    System.Console.BackgroundColor = System.ConsoleColor.DarkBlue;
                    System.Console.WriteLine($"Failed with exception {e.CrawledPage.HttpWebResponse.StatusCode} - {e.CrawledPage.WebException}");
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                }

                if (e.CrawledPage.HttpWebResponse.StatusCode != HttpStatusCode.NotFound)
                {
                    System.Console.BackgroundColor = System.ConsoleColor.Red;
                    System.Console.WriteLine($"Failed with exception {e.CrawledPage.HttpWebResponse.StatusCode} - {e.CrawledPage.WebException}");
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                }
            }
            else
            {
               
                var doc = new HtmlDocument();
                doc.LoadHtml(e.CrawledPage.Content.Text);

                var nodes = doc.DocumentNode.SelectNodes("//script|//style|//link");

                foreach (var node in nodes)
                    node.ParentNode.RemoveChild(node);
                _storage.StoreCrawledPage(doc.DocumentNode.OuterHtml, e.CrawledPage.Uri, "test token");
            }
        }
    }
}
