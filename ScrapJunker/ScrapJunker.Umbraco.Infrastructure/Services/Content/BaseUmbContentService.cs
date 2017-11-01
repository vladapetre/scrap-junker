using ScrapJunker.Infrastructure.Core.Interface;
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
    public abstract class BaseUmbContentService : IUmbContentService
    {
        protected readonly ServiceContext _serviceContext;
        protected readonly IUmbAlias _umbAlias;

        protected BaseUmbContentService(ServiceContext serviceContext, IUmbAlias umbAlias)
        {
            _serviceContext = serviceContext;
            _umbAlias = umbAlias;
        }

        public abstract string DocTypeAlias { get; }

        public T GetById<T>(int id)
        {
            return (T)_serviceContext.ContentService.GetById(id);
        }

        public IEnumerable<T> GetByParentId<T>(int parentId)
        {
            return (IEnumerable<T>)_serviceContext.ContentService.GetById(parentId)?.Children().Where(child => child.ContentType.Alias == DocTypeAlias);
        }

        public abstract void SaveOrUpdate<T>(T commandDTO, string docTypeAlias) where T : IGenericDTO;

        protected IContent GetRootByTokenAndDocTypeAlias(string token, string docTypeAlias)
        {
            return _serviceContext.ContentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == docTypeAlias && c.HasProperty(_umbAlias.Property_Token) && c.GetValue<string>(_umbAlias.Property_Token) == token);
        }
    }
}
