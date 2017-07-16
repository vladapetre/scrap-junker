using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Base
{
    public abstract class BaseEventHandler: IEventHandler
    {
        protected ILogger _logger;

        public BaseEventHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void OnChanged(EventArgs e)
        {

        }

        public abstract void Register<T>(T sender);

        public abstract void UnRegister<T>(T sender);
    }
}
