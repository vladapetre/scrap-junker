using ScrapJunker.Crawler.Abot;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using StructureMap;

namespace ScrapJunker.IOC
{
    public class ObjectFactory : Registry
    {
        public ObjectFactory()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.Assembly("ScrapJunker.Infrastructure.Core");
                x.Assembly("ScrapJunker.Infrastructure");
                x.Assembly("ScrapJunker.Crawler.Core");
                x.Assembly("ScrapJunker.Crawler");
                x.WithDefaultConventions();
            });

            For<ICrawler>().Use<AbotPoliteCrawler>();
            For<IStorage>().Use<FileStorage>();
            For<ICrawlerConfiguration>().Use<AbotCrawlerConfiguration>();
        }

        public static Container Instance()
        {
            return new Container(new ObjectFactory());
        }
    }
}
