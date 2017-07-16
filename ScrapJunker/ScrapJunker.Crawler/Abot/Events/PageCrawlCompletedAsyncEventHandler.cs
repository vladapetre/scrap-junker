using Abot.Crawler;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using System.IO;
using System.Net;

namespace ScrapJunker.Crawler.Abot.Events
{
    public class PageCrawlCompletedAsyncEventHandler : BaseEventHandler
    {
        private readonly IStorage _storage;

        public PageCrawlCompletedAsyncEventHandler(ILogger logger, IStorage storage) : base(logger)
        {
            _storage = storage;
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
            _logger.Log($"Finished crawling page {e.CrawledPage.ParentUri}");
            if (e.CrawledPage.WebException != null || e.CrawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                _logger.Log($"Failed with exception {e.CrawledPage.HttpWebResponse.StatusCode} - {e.CrawledPage.WebException}");
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Abot");
                _storage.Store<string>(e.CrawledPage.Content.Text, path, $"{e.CrawledPage.Uri.PathAndQuery}.html".Replace('/', '-'));
            }
        }
    }
}
