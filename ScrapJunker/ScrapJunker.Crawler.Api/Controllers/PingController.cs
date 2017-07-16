using System.Web.Http;

namespace ScrapJunker.Crawler.Api.Controllers
{
    public class PingController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Pong";
        }
    }
}
