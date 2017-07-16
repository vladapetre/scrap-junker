using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IEventHandler
    {
        void Register<T>(T sender);
        void UnRegister<T>(T sender);
        void OnChanged(EventArgs e);
    }
}
