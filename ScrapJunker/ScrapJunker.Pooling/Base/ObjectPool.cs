using ScrapJunker.Pooling.Core;
using ScrapJunker.Pooling.Core.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Pooling.Base
{
    public class ObjectPool<TObject> : IObjectPool<TObject>
    {
        private ConcurrentBag<TObject> _objects;
        private Func<TObject>_objectGenerator;

        public ObjectPool(Func<TObject> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objects = new ConcurrentBag<TObject>();
            _objectGenerator = objectGenerator;
        }

        public TObject GetObject()
        {
            TObject item;
            if (_objects.TryTake(out item)) return item;
            return _objectGenerator();
        }

        public void PutObject(TObject item)
        {
            _objects.Add(item);
        }
    }
}
