using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IGenericDTO
    {
        string Token { get; set; }
        int Id { get; set; }
        Type Type { get; set; }
        object Content { get; set; }
        string Name { get; set; }

        void Pack<T>(T content);
        T Unpack<T>();
        bool TryUnpack<T>(out T content);
    }
}
