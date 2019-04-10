using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace SignalRChat.Hubs
{
    // The ChatHub class inherits from the SignalR Hub class. 
    // The Hub class manages connections, groups, and messaging.
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }
        // The SendMessage method can be called by any connected client. 
        // It sends the received message to all clients. 
        // SignalR code is asynchronous to provide maximum scalability.
        public async Task SendMessage(string user, string message)
        {
            _logger.LogInformation($@"Message {user} Message is {message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}