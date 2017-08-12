using ScrapJunker.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Infrastructure.DTO { 

    public class CrawledPageDTO : GenericDTO
    {
        public string Name { get; set; }

        public string Token { get; set; }
        public string Host { get; set; }
    }
}