using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScrapJunker.CQRS.Base;
using ScrapJunker.Infrastructure.DTO;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class CreateCrawledPageCommnand : Command
    {
        public CrawledPageDTO ContentDTO { get; protected set; }

        public CreateCrawledPageCommnand(Guid id, int version, CrawledPageDTO contentDTO) : base(id, version)
        {
            ContentDTO = contentDTO;
        }
    }
}