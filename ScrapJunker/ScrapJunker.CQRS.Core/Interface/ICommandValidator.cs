using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface ICommandValidator<in TCommand>
    {
        void Validate(TCommand command);
    }
}
