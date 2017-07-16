using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface IEvent
    {
        Guid Guid { get;  }
        int Version { get; set; }
    }
}
