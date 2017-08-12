using System;

namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IStorage
    {
        void StoreCrawledPage(string htmlContent, Uri absoluteUri, string token);
    }
}
