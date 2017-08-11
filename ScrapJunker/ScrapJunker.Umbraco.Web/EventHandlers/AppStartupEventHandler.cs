using ScrapJunker.Umbraco.Web.ContentFinders;
using ScrapJunker.Umbraco.Web.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace ScrapJunker.Umbraco.Web.EventHandlers
{
    public class AppStartupEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            GlobalConfiguration.Configuration.Services.
               Replace(typeof(IHttpControllerActivator), new UmbracoWebApiHttpControllerActivator());

            ContentLastChanceFinderResolver.Current.SetFinder(new DefaultContentFinder());
        }
    }
}