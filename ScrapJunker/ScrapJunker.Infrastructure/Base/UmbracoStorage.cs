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
        private readonly IHttpClientWrapper _httpClientWrapper;

        public UmbracoStorage(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public void Store<T>(T item, string filePath, string fileName)
        {
            var content = new GenericDTO();
            content.Name = fileName;
            content.Token = "test token";
            content.Pack(item);

            _httpClientWrapper.Post("http://scrapjunker.umbraco.web:8030/umbraco/api/content/post", content);
        }
    }
}
