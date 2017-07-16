using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDependencyResolver _resolver;

        public CommandDispatcher(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var handler = _resolver.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new NotImplementedException(typeof(TCommand).ToString());
                // throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            handler.Handle(command);
        }
    }
}
