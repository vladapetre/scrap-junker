using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapJunker.Pooling.Core.Interface
{
    public interface IObjectPool<TObject>
    {
        TObject GetObject();
        void PutObject(TObject item);
    }
}
