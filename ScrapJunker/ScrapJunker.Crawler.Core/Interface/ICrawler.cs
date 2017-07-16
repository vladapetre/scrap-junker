namespace ScrapJunker.Crawler.Core.Interface
{
    public interface ICrawler
    {
        void Configure(ICrawlerConfiguration configuration);
        void Run(string uri);
    }
}
