using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Infrastructure.DTO;
using ScrapJunker.Umbraco.Core;
using ScrapJunker.Umbraco.Infrastructure.Standalone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Services.Content
{
    public class CrawledPageUmbContentService :  BaseUmbContentService, IUmbContentService
    {
        public CrawledPageUmbContentService(ServiceContext serviceContext, IUmbAlias umbAlias) 
            : base(serviceContext,umbAlias)
        {
        }

        public string DocTypeAlias => _umbAlias.DocType_CrawledPage;

        public void SaveOrUpdate<T>(T commandDTO, string docTypeAlias) where T: IGenericDTO
        {
            var content = commandDTO as CrawledPageDTO ;

            var umbRootDashboard = GetRootByTokenAndDocTypeAlias(content.Token,_umbAlias.DocType_DashboardPage);

            if (umbRootDashboard == null)
                throw new ArgumentNullException($"Could not find user registered by token {content.Token}");

            var umbCrawlerNode = umbRootDashboard.Children().SingleOrDefault(child => child.ContentType.Alias == _umbAlias.DocType_CrawlerPage);
            if (umbCrawlerNode == null)
                throw new NullReferenceException($"Dashboard with token: {content.Token} not properly configured. Missing {_umbAlias.DocType_CrawlerPage}");

            var crawledPageHostNodeContent = umbCrawlerNode.Children().FirstOrDefault(child => child.Name == content.Host);
            if(crawledPageHostNodeContent == null)
            {
                crawledPageHostNodeContent = _serviceContext.ContentService.CreateContent(content.Host, umbCrawlerNode.Id, docTypeAlias);
                if (crawledPageHostNodeContent.HasProperty(_umbAlias.Property_IsRoot))
                {
                    crawledPageHostNodeContent.SetValue(_umbAlias.Property_IsRoot, true);
                }
                _serviceContext.ContentService.SaveAndPublishWithStatus(crawledPageHostNodeContent);
            }

            var crawledPageNodeContent = crawledPageHostNodeContent.Name == content.Name ? crawledPageHostNodeContent : null;
            if(crawledPageNodeContent == null)
            {
                crawledPageNodeContent = _serviceContext.ContentService.CreateContent(content.Name, crawledPageHostNodeContent.Id, docTypeAlias);
            }

            if (crawledPageNodeContent.HasProperty(_umbAlias.Property_Content))
            {
                crawledPageNodeContent.SetValue(_umbAlias.Property_Content, commandDTO.Content);
            }

            _serviceContext.ContentService.SaveAndPublishWithStatus(crawledPageNodeContent);

        }
        
    }
}
