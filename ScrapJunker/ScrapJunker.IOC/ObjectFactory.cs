using System;
using ScrapJunker.Crawler.Abot;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using StructureMap;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.CQRS.Base;
using StructureMap.Pipeline;

namespace ScrapJunker.IOC
{
    public class ObjectFactory : Registry
    {
        protected static Container container;
        public ObjectFactory()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.Assembly("ScrapJunker.Infrastructure.Core");
                x.Assembly("ScrapJunker.Infrastructure");
                x.Assembly("ScrapJunker.Crawler.Core");
                x.Assembly("ScrapJunker.Crawler");
                x.Assembly("ScrapJunker.Crawler.Api");
                x.Assembly("ScrapJunker.CQRS.Core");
                x.Assembly("ScrapJunker.CQRS");
                x.WithDefaultConventions();
                x.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
            });

            For<ICrawler>().Use<AbotPoliteCrawler>();
            For<IStorage>().Use<FileStorage>();
            For<ICrawlerConfiguration>().Use<AbotCrawlerConfiguration>();
            For<IEventRepository>().Use<NEventRepository>();
            For<IEventStore>().Use<NEventStore>().Singleton();
            For<IContainer>().Use(() => new Container(this)).Singleton();

        }

        //public static Container Instance()
        //{
        //    if (container == null)
        //        container = new Container(new ObjectFactory());
        //    return container;
        //}

        //public T Resolve<T>()
        //{
        //    return Instance().GetInstance<T>();
        //}
    }
}
