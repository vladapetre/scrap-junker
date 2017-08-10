using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Umbraco.Core;
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
        private readonly ServiceContext _serviceContext;
        private readonly IUmbAlias _umbAlias;

        public ContentController(ServiceContext serviceContext,IUmbAlias umbAlias) : base()
        {
            _serviceContext = serviceContext;
            _umbAlias = umbAlias;
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] GenericDTO content)
        {
            try
            {
                var umbracoContent = _serviceContext.ContentService.GetById(content.Id);
                if (umbracoContent == null)
                    umbracoContent = _serviceContext.ContentService.CreateContent("Test", -1, _umbAlias.DocType_MasterPage);

                if (umbracoContent.HasProperty(_umbAlias.Property_Content))
                {
                    umbracoContent.SetValue(_umbAlias.Property_Content, content.Content);
                }

                _serviceContext.ContentService.SaveAndPublishWithStatus(umbracoContent);

                return Ok(umbracoContent);
            }
            catch (InvalidCastException ex)
            {
                return BadRequest();
            }
            catch(NullReferenceException ex)
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