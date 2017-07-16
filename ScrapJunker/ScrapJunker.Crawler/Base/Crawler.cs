using ScrapJunker.Crawler.Core.Interface;

namespace ScrapJunker.Crawler.Base
{
    public abstract class Crawler : ICrawler
    {
        protected Crawler()
        {

        }

        public abstract void Configure(ICrawlerConfiguration configuration);

        public abstract void Run(string uri);
    }
}
