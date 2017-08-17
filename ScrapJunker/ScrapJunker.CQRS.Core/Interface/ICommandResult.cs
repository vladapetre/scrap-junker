using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface ICommandResult
    {
        bool Success { get; }
        IList<string> Errors { get; set; }
    }
}
