using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Base
{
    public class UmbracoStorage : IStorage
    {
        private readonly IUmbContentService _umbContentService;

        public UmbracoStorage(IUmbContentService umbContentService)
        {
            _umbContentService = umbContentService;
        }

        public void Store<T>(T item, string filePath, string fileName)
        {
            _umbContentService.SaveContent(item, filePath, fileName);
        }
    }
}
