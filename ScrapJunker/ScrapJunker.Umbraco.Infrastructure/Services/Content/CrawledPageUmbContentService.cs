using ScrapJunker.Infrastructure.Core.Interface;
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
            //var content = commandDTO.Unpack<IContent>();

            //content = new IContent();

            var umbRootDashboard = GetRootByTokenAndDocTypeAlias(commandDTO.Token,_umbAlias.DocType_DashboardPage);

            if (umbRootDashboard == null)
                throw new ArgumentNullException($"Could not find user registered by token {commandDTO.Token}");

            var umbCrawlerNode = umbRootDashboard.Children().SingleOrDefault(child => child.ContentType.Alias == _umbAlias.DocType_CrawlerPage);
            if (umbCrawlerNode == null)
                throw new NullReferenceException($"Dashboard with token: {commandDTO.Token} not properly configured. Missing {_umbAlias.DocType_CrawlerPage}");

            var crawledPageContent = umbCrawlerNode.Children().FirstOrDefault(child => child.Name == commandDTO.Name);
            if(crawledPageContent == null)
            {
                crawledPageContent = _serviceContext.ContentService.CreateContent(commandDTO.Name, umbCrawlerNode.Id, docTypeAlias);
            }

            if (crawledPageContent.HasProperty(_umbAlias.Property_Content))
            {
                crawledPageContent.SetValue(_umbAlias.Property_Content, commandDTO.Content);
            }

            //throw new NotImplementedException();

            _serviceContext.ContentService.SaveAndPublishWithStatus(crawledPageContent);

        }
        
    }
}
