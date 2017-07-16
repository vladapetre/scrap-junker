using ScrapJunker.CQRS.Base;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.CQRS.Events.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.Domain
{
    public class TestAggregate : AggregateRoot,
        IEventHandler<TestCreatedEvent>
    {
        public string Url { get; set; }

        public TestAggregate()
        {

        }

        public TestAggregate(Guid id, string url)
        {
            ApplyChange(new TestCreatedEvent(id, url));
        }

        public void Handle(TestCreatedEvent @event)
        {
            Url = @event.Url;
            Guid = @event.Guid;
            Version = @event.Version;
        }
    }
}