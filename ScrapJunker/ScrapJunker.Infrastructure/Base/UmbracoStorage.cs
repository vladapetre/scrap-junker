using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Infrastructure.DTO;
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

        public void StoreCrawledPage(string htmlContent, Uri absoluteUri, string token)
        {
            var content = new CrawledPageDTO
            {
                Host = absoluteUri.Host,
                Name = absoluteUri.PathAndQuery,
                Token = token
            };

            content.Pack(htmlContent);

            _httpClientWrapper.Post("http://scrapjunker.umbraco.web:8030/umbraco/api/content/post", content);
        }
    }
}
