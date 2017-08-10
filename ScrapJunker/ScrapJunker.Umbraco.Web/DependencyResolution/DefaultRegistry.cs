// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrapJunker.Umbraco.Web.DependencyResolution {
    using global::Umbraco.Core;
    using global::Umbraco.Core.Services;
    using ScrapJunker.IOC;
    using ScrapJunker.Umbraco.Infrastructure.Standalone;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;

    public class DefaultRegistry : ObjectFactory
    {
        #region Constructors and Destructors

        private static Action<IAssemblyScanner> scan = delegate (IAssemblyScanner scanner)
        {
            scanner.Assembly("ScrapJunker.Umbraco.Core");
            scanner.Assembly("ScrapJunker.Umbraco.Infrastructure");
            scanner.Assembly("ScrapJunker.Umbraco.Web");
            scanner.With(new ControllerConvention());
        };

        public DefaultRegistry() : base((scanner) => scan(scanner))
        {
            For<ServiceContext>().Use(c => c.GetInstance<UmbServiceAccess>().Services);
        }

        #endregion
    }

    public static class ControllersHelper
    {
        public static bool IsUmbracoController(Type controllerType)
        {
            return controllerType.Namespace != null
               && controllerType.Namespace.StartsWith("umbraco", StringComparison.InvariantCultureIgnoreCase)
               && !controllerType.Namespace.StartsWith("umbraco.extensions", StringComparison.InvariantCultureIgnoreCase);
        }
    }

}