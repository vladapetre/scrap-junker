using ScrapJunker.CQRS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class Event : IEvent
    {
        public int Version { get; set; }
        public Guid AggregateId { get; set; }
        public Guid Guid { get; protected set; }
    }
}
