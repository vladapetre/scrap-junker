using ScrapJunker.Crawler.Core.Interface;
using System.Web.Http;

namespace ScrapJunker.Crawler.Api.Controllers
{
    public class CrawlerController : ApiController
    {
        public CrawlerController(ICrawler crawler)
        {

        }
      
    }
}
