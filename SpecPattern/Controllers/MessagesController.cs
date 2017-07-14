using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using SpecPattern.Hubs;
using SpecPattern.Models;

namespace SpecPattern.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : ApiHubController<Broadcaster>
    {
        public MessagesController(
            IConnectionManager signalRConnectionManager)
        : base(signalRConnectionManager)
        {

        }

        // POST api/messages
        [HttpPost]
        public void Post([FromBody]ChatMessageRequest message)
        {
            this.Clients.Group(message.Channel.ToString()).AddChatMessage(message);
        }
    }
}
