using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Infrastructure.DTO;
using ScrapJunker.Umbraco.Core;
using ScrapJunker.Umbraco.Web.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Services;
using Umbraco.Web;
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
        public IHttpActionResult Post([FromBody] CrawledPageDTO contentDTO)
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
            catch (InvalidCastException)
            {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int publishedContentId)
        {
            //TODO REPLACE WITH QUERY
            var helper = new UmbracoHelper(UmbracoContext);

            var result = helper.TypedContent(publishedContentId);

            if (result == null)
                return NotFound();

            return Ok(new {
                Name  = result.Name,
                Url = result.Url,
                Content = result.GetPropertyValue<string>("content")
            });
        }

        [HttpGet]
        public static string Ping()
        {
            return "Pong";
        }
    }
}