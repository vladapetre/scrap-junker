using Umbraco.Core;
using Umbraco.Core.Services;

namespace ScrapJunker.Umbraco.Infrastructure.Standalone
{
    public interface IUmbServiceAccess
    {
        ServiceContext Services { get; }

        DatabaseContext Database { get; }
    }

    public sealed class UmbServiceAccess : IUmbServiceAccess
    {
        private readonly ServiceContext _services;
        private readonly DatabaseContext _database;

        public UmbServiceAccess()
        {
            _services = UmbContextAccess.CreateServiceContext();
            _database = UmbContextAccess.CreateDatabaseContext();
        }

        /// <summary>
        /// Gets the current ServiceContext
        /// </summary>
        public ServiceContext Services => _services;

        public DatabaseContext Database => _database;
    }
}
