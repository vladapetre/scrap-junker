using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
