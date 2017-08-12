using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Services.Content
{
    public abstract class BaseUmbContentService
    {
        protected readonly ServiceContext _serviceContext;
        protected readonly IUmbAlias _umbAlias;

        public BaseUmbContentService(ServiceContext serviceContext, IUmbAlias umbAlias)
        {
            _serviceContext = serviceContext;
            _umbAlias = umbAlias;
        }

        protected IContent GetRootByTokenAndDocTypeAlias(string token, string docTypeAlias)
        {
            return _serviceContext.ContentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == docTypeAlias && c.HasProperty(_umbAlias.Property_Token) && c.GetValue<string>(_umbAlias.Property_Token) == token);
        }
    }
}
