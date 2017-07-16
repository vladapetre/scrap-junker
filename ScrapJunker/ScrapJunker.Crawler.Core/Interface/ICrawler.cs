using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Core.Interface
{
    public interface ICrawler
    {
        void Configure(ICrawlerConfiguration configuration);
        void Run(string uri);
    }
}
