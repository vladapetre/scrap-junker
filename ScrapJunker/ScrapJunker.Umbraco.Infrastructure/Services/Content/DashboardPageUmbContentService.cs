using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Services.Content
{
    public class DashboardPageUmbContentService : BaseUmbContentService, IUmbContentService
    {
        public DashboardPageUmbContentService(ServiceContext serviceContext, IUmbAlias umbAlias)
            : base(serviceContext, umbAlias)
        {
        }

        public override string DocTypeAlias => _umbAlias.DocType_DashboardPage;

        public override void SaveOrUpdate<T>(T commandDTO, string docTypeAlias)
        {
            throw new NotImplementedException();
        }
    }
}
