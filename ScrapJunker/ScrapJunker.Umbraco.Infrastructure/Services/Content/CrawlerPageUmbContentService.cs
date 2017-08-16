using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using ScrapJunker.Infrastructure.Core.Interface;

namespace ScrapJunker.Umbraco.Infrastructure.Services.Content
{
    public class CrawlerPageUmbContentService : BaseUmbContentService, IUmbContentService
    {
        public CrawlerPageUmbContentService(ServiceContext serviceContext, IUmbAlias umbAlias)
            : base(serviceContext, umbAlias)
        {
        }

        public override string DocTypeAlias => _umbAlias.DocType_CrawlerPage;

        public override void SaveOrUpdate<T>(T commandDTO, string docTypeAlias)
        {
            throw new NotImplementedException();
        }
    }
}
