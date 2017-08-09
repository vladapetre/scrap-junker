using ScrapJunker.Umbraco.Core;
using ScrapJunker.Umbraco.Infrastructure.Standalone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Umbraco.Infrastructure.Services
{
    public class UmbContentService : IUmbContentService
    {
        private readonly UmbServiceAccess _umbServiceAccess;
        private IUmbAlias _umbAlias;

        public UmbContentService(UmbServiceAccess umbServiceAccess,IUmbAlias umbAlias)
        {
            _umbServiceAccess = umbServiceAccess;
            _umbAlias = umbAlias;
        }

        public void SaveContent<T>(T content, string contentName, string contentPath)
        {
            var newContent = _umbServiceAccess.Services.ContentService.CreateContent(contentName, -1, _umbAlias.DocType_MasterPage);

            if (newContent.HasProperty(_umbAlias.Property_Content))
            {
                newContent.SetValue(_umbAlias.Property_Content, content);
            }

            _umbServiceAccess.Services.ContentService.SaveAndPublishWithStatus(newContent);
        }
    }
}
