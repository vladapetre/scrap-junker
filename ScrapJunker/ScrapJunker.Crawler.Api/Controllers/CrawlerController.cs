using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.CQRS.Commands;
using ScrapJunker.Crawler.Api.Domain;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.DTO;
using System;
using System.Web.Http;

namespace ScrapJunker.Crawler.Api.Controllers
{
    public class CrawlerController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEventRepository _eventRepository;

        public CrawlerController(ICommandDispatcher commandDispatcher, IEventRepository eventRepository)
        {
            _commandDispatcher = commandDispatcher;
            _eventRepository = eventRepository;
        }

        [HttpPost]
        [Route("run")]
        public IHttpActionResult Run([FromBody] RunCrawlerConfigurationDto runCrawlerConfigurationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = Guid.NewGuid();
            try
            {
                _commandDispatcher.Dispatch(new RunCrawlerCommand(id, 0 , runCrawlerConfigurationDto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(id);
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_eventRepository.GetById<TestAggregate>(id));
        }
    }
}
