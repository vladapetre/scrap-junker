using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface IAggregateRoot
    {
        Guid Guid { get;  }
        int Version { get; set; }

        void Load(IEnumerable<IEvent> history);
        List<IEvent> UncommitedChanges { get; }
    }
}
