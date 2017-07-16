using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface IEventDispatcher
    {
        void Dispatch<T>(T @event) where T : IEvent;
    }
}
