using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace ScrapJunker.Umbraco.Web.ContentFinders
{
    public class DefaultContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {

            if (contentRequest.HasDomain)
            {
                var rootNodeId = contentRequest.UmbracoDomain.RootContentId.Value;
                var rootNode = contentRequest.RoutingContext.UmbracoContext.ContentCache.GetById(rootNodeId);

                var notFoundPage = rootNode.Descendants("notFoundPage").Single();

                contentRequest.SetIs404();
                contentRequest.PublishedContent = notFoundPage;

                return notFoundPage != null;
            }

            return false;

            
        }
    }
}