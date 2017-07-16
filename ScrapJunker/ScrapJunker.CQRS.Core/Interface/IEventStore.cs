using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface IEventStore
    {
        void OpenOrCreateStream(IEvent @event);
        void AppendToStream(IEvent @event);
        void AppendToStream(IList<IEvent> @events);
        void TakeSnapshot(IEvent @event);
        IList<TEvent> LoadCommitedFromStream<TEvent>(Guid aggregateId) where TEvent : IEvent;
        IList<TEvent> LoadUncommitedFromStream<TEvent>(Guid aggregateId) where TEvent : IEvent;
        void LoadFromSnapshotForwardAndAppend(IEvent @event);
        void Commit(Guid guid);
    }
}
