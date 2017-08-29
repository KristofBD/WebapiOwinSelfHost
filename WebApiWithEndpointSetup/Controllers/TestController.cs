using System.Web.Http;

namespace WebApiWithEndpointSetup.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("picking-orders")]
        public IHttpActionResult DoStuff()
        {
            return Ok();
        }
    }
}
