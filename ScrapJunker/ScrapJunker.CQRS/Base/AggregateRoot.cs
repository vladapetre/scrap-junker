using ScrapJunker.CQRS.Base;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.CQRS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public List<IEvent> UncommitedChanges { get; protected set; }

        public int Version { get; set; }
        public Guid AggregateId { get; set; }
        public Guid Guid { get; protected set; }
        public int EventVersion { get; protected set; }

        public AggregateRoot()
        {
            UncommitedChanges = new List<IEvent>();
        }

        public void Load(IEnumerable<IEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
            Version = history.Last().Version;
            EventVersion = Version;
        }

        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IEvent @event, bool isNew)
        {
            dynamic d = this;

            d.Handle(Converter.ChangeTo(@event, @event.GetType()));
            if (isNew)
            {
                UncommitedChanges.Add(@event);
            }
        }
    }
}
