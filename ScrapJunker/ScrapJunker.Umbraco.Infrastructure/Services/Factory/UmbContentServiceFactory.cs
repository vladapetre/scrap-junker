using ScrapJunker.Umbraco.Core;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Umbraco.Infrastructure.Services.Factory
{
    public class UmbContentServiceFactory : IUmbContentServiceFactory
    {
        private IContainer _container;

        public UmbContentServiceFactory(IContainer container)
        {
            _container = container;
        }

        public IUmbContentService Create(string docTypeAlias)
        {
            if (docTypeAlias == null)
            {
                throw new ArgumentNullException("docTypeAlias");
            }

            return _container.GetInstance<IUmbContentService>(docTypeAlias);
        }
    }
}
