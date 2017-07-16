using NEventStore;
using NEventStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.CQRS.Base
{
    public class AuthorizationPipelineHook : IPipelineHook , IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void OnDeleteStream(string bucketId, string streamId)
        {
            throw new NotImplementedException();
        }

        public void OnPurge(string bucketId)
        {
            throw new NotImplementedException();
        }

        public void PostCommit(ICommit committed)
        {
            throw new NotImplementedException();
        }

        public bool PreCommit(CommitAttempt attempt)
        {
            throw new NotImplementedException();
        }

        public ICommit Select(ICommit committed)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            // no op
        }
    }
}
