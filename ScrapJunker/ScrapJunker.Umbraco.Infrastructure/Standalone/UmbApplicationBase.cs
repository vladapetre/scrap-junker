using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace ScrapJunker.Umbraco.Infrastructure.Standalone
{
    public sealed class UmbApplicationBase : UmbracoApplicationBase
    {
        protected override IBootManager GetBootManager()
        {
            return new UmbBootManager(this);
        }

        public void Start(object Sender, EventArgs Args)
        {
            Application_Start(Sender, Args);
        }
    }
}
