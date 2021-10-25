using Chatting.Domain;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatting.WPF.Services
{
    public class SignalRChattingService
    {
        private HubConnection _connection;

        public event Action<ChattingMessage> ChattingMessageReceived;

        public SignalRChattingService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<ChattingMessage>("ReceiveChattingMessage", 
                (message) => ChattingMessageReceived?.Invoke(message));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        public async Task SendChattingMessage(ChattingMessage message)
        {
            await _connection.SendAsync("ReceiveChattingMessage", message);
        }
    }
}
