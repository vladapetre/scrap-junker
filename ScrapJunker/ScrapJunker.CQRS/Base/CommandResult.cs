using ScrapJunker.CQRS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class CommandResult : ICommandResult
    {
        public IList<string> Errors { get; set; } = new List<string>();

        public bool Success => !Errors.Any();
    }
}
