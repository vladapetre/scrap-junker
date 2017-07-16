using ScrapJunker.CQRS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class Command : ICommand
    {
        public Guid Guid { get; private set; }
        public int Version { get; private set; }
        public Command(Guid id, int version)
        {
            Guid = id;
            Version = version;
        }
    }
}
