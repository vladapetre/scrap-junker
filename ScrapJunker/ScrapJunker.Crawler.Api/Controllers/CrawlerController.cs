using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.CQRS.Command;
using ScrapJunker.Crawler.Api.DTO;
using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Web.Http;

namespace ScrapJunker.Crawler.Api.Controllers
{
    public class CrawlerController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CrawlerController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("run")]
        public IHttpActionResult Run([FromBody] RunCrawlerConfigurationDto runCrawlerConfigurationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _commandDispatcher.Dispatch(new RunCrawlerCommand(runCrawlerConfigurationDto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}
