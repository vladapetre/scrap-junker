using System;

namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IEventHandler
    {
        void Register<T>(T sender);
        void UnRegister<T>(T sender);
        void OnChanged(EventArgs e);
    }
}
