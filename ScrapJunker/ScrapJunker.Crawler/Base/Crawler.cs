using ScrapJunker.Crawler.Core.Interface;
using System.Threading.Tasks;
using System;

namespace ScrapJunker.Crawler.Base
{
    public abstract class Crawler : ICrawler
    {
        protected Crawler()
        {

        }

        public abstract ICrawlerConfiguration Configuration {get;}

        public abstract void Configure(ICrawlerConfiguration configuration);

        public abstract void Run(string uri);
        public abstract Task RunAsync(string uri);
    }
}
