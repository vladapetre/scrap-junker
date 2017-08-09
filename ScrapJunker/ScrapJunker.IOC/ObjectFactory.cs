﻿using System;
using ScrapJunker.Crawler.Abot;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using StructureMap;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.CQRS.Base;
using StructureMap.Pipeline;
using StructureMap.Graph;
using ScrapJunker.Umbraco.Core;
using ScrapJunker.Umbraco.Infrastructure.Services;

namespace ScrapJunker.IOC
{
    public class ObjectFactory : Registry
    {
        protected static Container container;
        public ObjectFactory(params Action<IAssemblyScanner>[] scanActions)
        {
            Action<IAssemblyScanner> scan = delegate(IAssemblyScanner scanner){
               
                scanner.Assembly("ScrapJunker.Infrastructure.Core");
                scanner.Assembly("ScrapJunker.Infrastructure");
                scanner.Assembly("ScrapJunker.Crawler.Core");
                scanner.Assembly("ScrapJunker.Crawler");
                scanner.Assembly("ScrapJunker.CQRS.Core");
                scanner.Assembly("ScrapJunker.CQRS");
                scanner.Assembly("ScrapJunker.Umbraco.Core");
                //scanner.Assembly("ScrapJunker.Umbraco.Infrastructure");
            };

            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scan(scanner);
               

                if (scanActions != null)
                {
                    foreach(var scanAction in scanActions)
                    {
                        scanAction(scanner);
                    }
                }

                scanner.WithDefaultConventions();
            });

            For<ICrawler>().Use<AbotPoliteCrawler>();
            For<IStorage>().Use<FileStorage>();
            For<ICrawlerConfiguration>().Use<AbotCrawlerConfiguration>();
            For<IEventRepository>().Use<NEventRepository>();
            For<IEventStore>().Use<NEventStore>().Singleton();
            For<IContainer>().Use(() => new Container(this)).Singleton();

        }
    }
}
