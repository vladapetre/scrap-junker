using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    internal class AggregateMemento
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
