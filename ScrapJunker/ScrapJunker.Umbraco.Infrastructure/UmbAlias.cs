using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Umbraco.Infrastructure
{
    public class UmbAlias : IUmbAlias
    {
        public string DocType_MasterPage => "masterPage";

        public string Property_Content => "content";
    }
}
