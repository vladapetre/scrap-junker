using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Umbraco.Core
{
    public interface IUmbContentService
    {
        string DocTypeAlias { get; }
        void SaveOrUpdate<T>(T commandDTO, string docTypeAlias) where T : IGenericDTO;
        T GetById<T>(int id);
        IEnumerable<T> GetByParentId<T>(int parentId);
    }
}
