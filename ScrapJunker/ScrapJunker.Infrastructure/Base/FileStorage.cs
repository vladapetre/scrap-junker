using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Base
{
    public class FileStorage : IStorage
    {
        public void Store<T>(T item, string filePath, string fileName)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            System.IO.File.WriteAllText(Path.Combine(filePath,fileName), item.ToString());
        }
    }
}
