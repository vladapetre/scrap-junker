using ScrapJunker.Infrastructure.Core.Interface;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.IOC
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public DependencyResolver(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
