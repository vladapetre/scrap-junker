using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScrapJunker.Umbraco.Web.DTO;
using ScrapJunker.CQRS.Base;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class CreateCrawledPageCommnand : Command
    {
        public CreateCrawledPageCommnandDTO ContentDTO { get; protected set; }

        public CreateCrawledPageCommnand(Guid id, int version, CreateCrawledPageCommnandDTO contentDTO) : base(id, version)
        {
            ContentDTO = contentDTO;
        }
    }
}