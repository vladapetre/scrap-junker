using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface IEventRepository
    {
        void Save<TAggregate>(IAggregateRoot aggregate, int expectedVersion) where TAggregate : IAggregateRoot, new();
        TAggregate GetById<TAggregate>(Guid id) where TAggregate : IAggregateRoot, new();
    }
}
