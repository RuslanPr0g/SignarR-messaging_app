using Chatting.Domain;
using Chatting.WPF.Services;
using Chatting.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chatting.WPF.Commands
{
    public class SendChattingMessageCommand : ICommand
    {
        private readonly ChattingViewModel _viewModel;
        private readonly SignalRChattingService _chatService;

        public SendChattingMessageCommand(ChattingViewModel viewModel, SignalRChattingService chatService)
        {
            _viewModel = viewModel;
            _chatService = chatService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var message = new ChattingMessage
                {
                    Red = _viewModel.Red,
                    Green = _viewModel.Green,
                    Blue = _viewModel.Blue,
                    Content = _viewModel.Messages.LastOrDefault()?.ChattingMessage.Content ?? string.Empty
                };

                await _chatService.SendChattingMessage(message);

                _viewModel.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
