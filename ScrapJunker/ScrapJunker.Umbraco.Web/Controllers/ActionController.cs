using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Umbraco.Web.CQRS.Commands;
using ScrapJunker.Umbraco.Web.DTO;
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
        public IHttpActionResult Crawl([FromBody] ActionCrawlCommandDTO actionCrawlCommandDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = Guid.NewGuid();
            try
            {
                var result = _commandDispatcher.DispatchWithValidation(new ActionCrawlCommand(id, 0, actionCrawlCommandDTO));
                if (!result.Success)
                {
                    return BadRequest(string.Join("\r\n", result.Errors));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(id);
        }
    }
}
