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
        string DocType_CrawledPage { get; }
        string DocType_DashboardPage { get; }
        string Property_Token { get; }
        string DocType_CrawlerPage { get; }
        string Property_IsRoot { get; }
    }
}
