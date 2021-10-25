using Chatting.Domain;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatting.SignalR.Hubs
{
    public class ChattingHub : Hub
    {
        public async Task ReceiveChattingMessage(ChattingMessage message)
        {
            await Clients.All.SendAsync("ReceiveChattingMessage", message);
        }
    }
}
