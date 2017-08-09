﻿using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.IOC;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api
{
    public class CrawlerApiObjectFactory : ObjectFactory
    {
        private static Action<IAssemblyScanner> scan = delegate (IAssemblyScanner scanner)
       {
           scanner.Assembly("ScrapJunker.Crawler.Api");
           scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
       };

        public CrawlerApiObjectFactory() : base((scanner) => scan(scanner))
        {

        }
    }
}