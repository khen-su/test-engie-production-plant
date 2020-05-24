using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PowerPlantCodingChallenge.Controllers
{
    public class SimpleWebSocketHandler : Hub, ISimpleWebSocketHandler
    {
        protected IHubContext<SimpleWebSocketHandler> _context;

        public SimpleWebSocketHandler(IHubContext<SimpleWebSocketHandler> context)
        {
            _context = context;

        }

        public async Task SendMessage(string message)
        {
            if (_context.Clients == null) return;
            await _context.Clients.All.SendAsync("message", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}