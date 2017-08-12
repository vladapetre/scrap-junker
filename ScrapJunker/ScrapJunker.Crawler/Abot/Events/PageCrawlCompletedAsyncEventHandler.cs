using Abot.Crawler;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using System.IO;
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
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Abot");
                _storage.Store<string>(e.CrawledPage.Content.Text, path, $"{e.CrawledPage.Uri.PathAndQuery}.html".Replace('/', '-'));
            }
        }
    }
}
