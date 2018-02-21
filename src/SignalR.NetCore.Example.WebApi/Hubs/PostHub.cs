using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace SignalR.NetCore.Example.WebApi.Hubs
{
    [HubName("Post")]
    public class PostHub : Hub
    {
        public void Post(string value)
        {
            this.Clients.All.notify(value);
        }
    }
}
