using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Base
{
    public class GenericDTO : IGenericDTO
    {

        public Type Type { get; set; }

        public object Content { get; set; }

        public int Id { get; set; }

        public void Pack<T>(T content)
        {
            Type = typeof(T);
            Content = content;
        }

        public bool TryUnpack<T>(out T content)
        {
            if (Type != null)
            {
                if (typeof(T).IsEquivalentTo(Type))
                {
                    content = (T)Content;
                    return true;
                }
            }

            content = default(T);
            return false;
        }

        public T Unpack<T>()
        {
            if (Type != null)
            {
                if (typeof(T).IsEquivalentTo(Type))
                {
                    return (T)Content;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            throw new NullReferenceException();
        }
    }
}
