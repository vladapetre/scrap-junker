using NEventStore;
using ScrapJunker.CQRS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class NEventRepository : IEventRepository
    {
        private readonly IEventStore _eventStore;
        private static object _lockStorage = new object();

        public NEventRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Save<TAggregate>(IAggregateRoot aggregate, int expectedVersion) where TAggregate : IAggregateRoot, new()
        {
            {
                var uncommitedChanges = aggregate.UncommitedChanges;
                if (uncommitedChanges.Any())
                {
                    lock (_lockStorage)
                    {
                        var item = new TAggregate();

                        if (expectedVersion != -1)
                        {
                            item = GetById<TAggregate>(aggregate.Guid);
                            if (item.Version != expectedVersion)
                            {
                                throw new ConcurrencyException($"Aggregate {item.Guid} has been previously modified");
                            }
                        }

                        _eventStore.AppendToStream(uncommitedChanges);
                    }
                }
            }
        }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregateRoot, new()
        {
            var events = _eventStore.LoadCommitedFromStream<IEvent>(id);

            var obj = new TAggregate();
            obj.Load(events);
            return obj;
        }
    }
}
