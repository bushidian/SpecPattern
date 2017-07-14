using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SpecPattern.Hubs
{
    public class Broadcaster: Hub<IBroadcaster>
    {
        // Set connection id for just connected client only
        public override Task OnConnected()
        {
            // Set connection id for just connected client only
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }

        // Server side methods called from client
        public Task Subscribe(string channel)
        {
            return Groups.Add(Context.ConnectionId, channel);
        }

        public Task Unsubscribe(string channel)
        {
            return Groups.Remove(Context.ConnectionId, channel);
        }

    }

    // Client side methods to be invoked by Broadcaster Hub
    public interface IBroadcaster
    {
        Task SetConnectionId(string connectionId);
      
    }
}
