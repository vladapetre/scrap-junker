using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.editorControls;
using umbraco.interfaces;
using Umbraco.Core;

namespace ScrapJunker.Umbraco.Infrastructure.Standalone
{
    public class UmbBootManager : CoreBootManager
    {
        internal UmbBootManager(UmbracoApplicationBase UmbracoApplication)
            : base(UmbracoApplication)
        {
            //This is only here to ensure references to the assemblies needed for the DataTypesResolver
            //otherwise they won't be loaded into the AppDomain.
            var InterfacesAssemblyName = typeof(IDataType).Assembly.FullName;
            var EditorControlsAssemblyName = typeof(uploadField).Assembly.FullName;
        }
    }
}
