using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Standalone
{
    public sealed class UmbServiceAccess 
    {
        private readonly ServiceContext _Services;
        private readonly DatabaseContext _Database;

        public UmbServiceAccess()
        {
            _Services = UmbContextAccess.CreateServiceContext();
            _Database = UmbContextAccess.CreateDatabaseContext();
        }

        /// <summary>
        /// Gets the current ServiceContext
        /// </summary>
        public ServiceContext Services
        {
            get { return _Services; }
        }

        public DatabaseContext Database
        {
            get { return _Database; }
        }
    }
}
