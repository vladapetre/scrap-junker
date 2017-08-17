using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Core.Interface
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
        ICommandResult DispatchWithValidation<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
