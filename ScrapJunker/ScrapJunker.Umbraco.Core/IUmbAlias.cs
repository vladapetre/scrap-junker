using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Umbraco.Core
{
    public interface IUmbAlias
    {
        string DocType_MasterPage { get; }
        string Property_Content { get; }
    }
}
