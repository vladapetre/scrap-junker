using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Core.Interface
{
    public interface ICrawler
    {
        ICrawlerConfiguration Configuration { get; }
        void Configure(ICrawlerConfiguration configuration);
        void Run(string uri);
        Task RunAsync(string uri);
    }
}
