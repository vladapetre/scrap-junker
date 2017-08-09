using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Standalone
{
    public sealed class UmbContextAccess
    {
        public static ServiceContext CreateServiceContext()
        {
            var appBase = new UmbApplicationBase();

            if (ApplicationContext.Current == null)
                appBase.Start(appBase, new EventArgs());

            var appContext = ApplicationContext.Current;
            return appContext.Services;
        }

        public static DatabaseContext CreateDatabaseContext()
        {
            var appBase = new UmbApplicationBase();

            if (ApplicationContext.Current == null)
                appBase.Start(appBase, new EventArgs());

            var appContext = ApplicationContext.Current;
            return appContext.DatabaseContext;
        }
    }
}
