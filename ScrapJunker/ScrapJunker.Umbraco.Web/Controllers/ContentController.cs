using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Umbraco.Core;
using ScrapJunker.Umbraco.Web.CQRS.Commands;
using ScrapJunker.Umbraco.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace ScrapJunker.Umbraco.Web.Controllers
{
    [PluginController("api")]
    public class ContentController : UmbracoApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ContentController(ICommandDispatcher commandDispatcher) : base()
        {
            _commandDispatcher = commandDispatcher;
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] CreateCrawledPageCommnandDTO contentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var id = Guid.NewGuid();
                _commandDispatcher.Dispatch(new CreateCrawledPageCommnand(id, 0, contentDTO));



                return Ok(id);
            }
            catch (InvalidCastException ex)
            {
                return BadRequest();
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
    }
}