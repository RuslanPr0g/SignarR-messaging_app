using Chatting.WPF.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;

namespace Chatting.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatting")
                .Build();

            ChattingViewModel chatViewModel = ChattingViewModel.CreatedConnectedViewModel(new Services.SignalRChattingService(connection));

            MainWindow window = new()
            {
                DataContext = new MainViewModel(chatViewModel)
            };

            window.Show();
        }
    }
}
