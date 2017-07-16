using ScrapJunker.IOC;
using System.Web.Http;
using WebApi.StructureMap;

namespace ScrapJunker.Crawler.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.UseStructureMap<ObjectFactory>();
        }
    }
}
