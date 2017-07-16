using NEventStore;
using NEventStore.Dispatcher;
using ScrapJunker.CQRS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class NEventStore : IEventStore
    {
        private static readonly byte[] EncryptionKey = new byte[]
          {
                0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
          };
        private readonly IStoreEvents _store;

        public NEventStore()
        {
            _store = Wireup.Init()
               //.LogToOutputWindow()
                         .UsingInMemoryPersistence()
                         //.UsingSqlPersistence("EventStore") // Connection string is in app.config
                         //.WithDialect(new MsSqlDialect())
                         //.EnlistInAmbientTransaction() // two-phase commit
                         .InitializeStorageEngine()
                         //.TrackPerformanceInstance("example")
                         //.UsingJsonSerialization()
                         //.Compress()
                         //.EncryptWith(EncryptionKey)
                        // .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                         .Build();
        }

        private static void DispatchCommit(ICommit commit)
        {
            // This is where we'd hook into our messaging infrastructure, such as NServiceBus,
            // MassTransit, WCF, or some other communications infrastructure.
            // This can be a class as well--just implement IDispatchCommits.
            //try
            //{
            //    foreach (EventMessage @event in commit.Events)
            //        Console.WriteLine(Resources.MessagesDispatched + ((SomeDomainEvent)@event.Body).Value);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(Resources.UnableToDispatch);
            //}
        }

        public void OpenOrCreateStream(IEvent @event)
        {
            // we can call CreateStream(StreamId) if we know there isn't going to be any data.
            // or we can call OpenStream(StreamId, 0, int.MaxValue) to read all commits,
            // if no commits exist then it creates a new stream for us.
            using (IEventStream stream = _store.OpenStream(@event.Guid, 0, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = @event });
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        public void AppendToStream(IEvent @event)
        {
            using (IEventStream stream = _store.OpenStream(@event.Guid, 0, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = @event });
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        public void AppendToStream(IList<IEvent> @events)
        {
            using (IEventStream stream = _store.OpenStream(@events.FirstOrDefault().Guid, 0, int.MaxValue))
            {
                foreach (var @event in @events)
                {
                    stream.Add(new EventMessage { Body = @event });
                }
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        public void TakeSnapshot(IEvent @event)
        {
            var memento = new AggregateMemento { Value = "snapshot" };
            _store.Advanced.AddSnapshot(new Snapshot(@event.Guid.ToString(), 2, memento));
        }

        public IList<TEvent> LoadCommitedFromStream<TEvent>(Guid aggregateId) where TEvent:IEvent
        {
            using (IEventStream stream = _store.OpenStream(aggregateId, 0, int.MaxValue))
            {
                return stream.CommittedEvents.Select(e => (TEvent)e.Body).ToList();
            }
        }

        public IList<TEvent> LoadUncommitedFromStream<TEvent>(Guid aggregateId) where TEvent : IEvent
        {
            using (IEventStream stream = _store.OpenStream(aggregateId, 0, int.MaxValue))
            {
                return stream.UncommittedEvents.Select(e => (TEvent)e.Body).ToList();
            }
        }

        public void LoadFromSnapshotForwardAndAppend(IEvent @event)
        {
            var latestSnapshot = _store.Advanced.GetSnapshot(@event.Guid, 0);

            using (IEventStream stream = _store.OpenStream(latestSnapshot, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = @event });
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        public void Commit(Guid guid)
        {
            using (IEventStream stream = _store.OpenStream(guid, 0, int.MaxValue))
            {
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}
