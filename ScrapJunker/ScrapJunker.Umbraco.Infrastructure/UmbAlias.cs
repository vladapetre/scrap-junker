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

        public string DocType_CrawledPage => "crawledPage";

        public string DocType_DashboardPage => "dashboardPage";

        public string Property_Token => "token";

        public string DocType_CrawlerPage => "crawlerPage";

        public string Property_IsRoot => "isRoot";

        public string Property_AbsoluteUri => "absoluteUri";
    }
}
