using ScrapJunker.Umbraco.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ScrapJunker.Umbraco.Web.DependencyResolution
{
    public class UmbracoWebApiHttpControllerActivator : IHttpControllerActivator
    {
        private readonly DefaultHttpControllerActivator _defaultHttpControllerActivator;

        public UmbracoWebApiHttpControllerActivator()
        {
            this._defaultHttpControllerActivator = new DefaultHttpControllerActivator();
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            IHttpController instance =
               ControllersHelper.IsUmbracoController(controllerType)
                  ? this._defaultHttpControllerActivator.Create(request, controllerDescriptor, controllerType)
                  : StructuremapMvc.StructureMapDependencyScope.GetInstance(controllerType) as IHttpController;

            return instance;
        }
    }
}