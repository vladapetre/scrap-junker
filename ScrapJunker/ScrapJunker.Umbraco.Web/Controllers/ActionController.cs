using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Infrastructure.DTO;
using ScrapJunker.Umbraco.Web.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace ScrapJunker.Umbraco.Web.Controllers
{
    [PluginController("api")]
    public class ActionController : UmbracoApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ActionController(ICommandDispatcher commandDispatcher) : base()
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public IHttpActionResult Crawl([FromBody] RunCrawlerConfigurationDto runCrawlerConfigurationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = Guid.NewGuid();
            try
            {
                _commandDispatcher.Dispatch(new ActionCrawlCommand(id, 0, runCrawlerConfigurationDto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(id);
        }
    }
}
