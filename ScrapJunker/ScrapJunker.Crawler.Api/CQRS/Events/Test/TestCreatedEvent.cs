using ScrapJunker.CQRS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.CQRS.Events.Test
{
    public class TestCreatedEvent : Event
    {

        public TestCreatedEvent(Guid id, string url)
        {
            Guid = id;
            Url = url;
        }

        public string Url { get; set; }
    }
}