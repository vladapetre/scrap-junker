using ScrapJunker.Crawler.Api.DTO;
using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Web.Http;

namespace ScrapJunker.Crawler.Api.Controllers
{
    public class CrawlerController : ApiController
    {
        private readonly ICrawler _crawler;

        public CrawlerController(ICrawler crawler)
        {
            _crawler = crawler;
        }

        [HttpPost]
        public IHttpActionResult Run([FromBody] CrawlerRunConfigurationDto crawlerRunConfigurationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _crawler.Configuration.CrawlTimeoutSeconds = crawlerRunConfigurationDto.CrawlTimeoutSeconds ?? 30;
                _crawler.Configuration.MaxConcurrentThreads = crawlerRunConfigurationDto.MaxConcurrentThreads ?? 1;
                _crawler.Configuration.MaxPagesToCrawl = crawlerRunConfigurationDto.MaxPagesToCrawl ?? 100;

                _crawler.Run(crawlerRunConfigurationDto.Url);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}
