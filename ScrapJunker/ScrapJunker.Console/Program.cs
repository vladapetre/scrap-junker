using ScrapJunker.Crawler.Abot.Events;
using ScrapJunker.Crawler.Base;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.IOC;
using System.Collections.Generic;

namespace ScrapJunker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ObjectFactory.Instance();

            var crawler = container.GetInstance<ICrawler>();
            var logger = container.GetInstance<ILogger>();
            var storage = container.GetInstance<IStorage>();

            var configuration = new CrawlerConfiguration()
            {
                CrawlTimeoutSeconds = 30,
                MaxConcurrentThreads = 1,
                MaxPagesToCrawl = 5,
                UserAgentString = "Scrap Junker Test v1",
                EventHandlers = new List<IEventHandler>
                {
                    new PageCrawlCompletedAsyncEventHandler(logger,storage)
                }
            };

            crawler.Configure(configuration);

            crawler.Run("https://msdn.microsoft.com/en-us/library/fyy7a5kt(v=vs.110).aspx");

            System.Console.ReadKey();
        }
    }
}
