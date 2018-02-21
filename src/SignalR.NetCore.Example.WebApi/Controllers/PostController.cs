using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using SignalR.NetCore.Example.WebApi.Hubs;

namespace SignalR.NetCore.Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IHubContext _hubContext;
        public PostController(IConnectionManager connectionManager)
        {
            _hubContext = connectionManager.GetHubContext<PostHub>();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromQuery]string value)
        {
            _hubContext.Clients.All.notify(value);
        }
    }
}
