using Chatting.Domain;
using Chatting.WPF.Commands;
using Chatting.WPF.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Chatting.WPF.ViewModels
{
    public class ChattingViewModel : ViewModelBase
    {
        private byte _red;
        public byte Red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                OnPropertyChanged(nameof(Red));
            }
        }

        private byte _green;
        public byte Green
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
                OnPropertyChanged(nameof(Green));
            }
        }

        private byte _blue;
        public byte Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                _blue = value;
                OnPropertyChanged(nameof(Blue));
            }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public ObservableCollection<ChattingColorViewModel> Messages { get; }

        public ICommand SendChattingMessageCommand { get; }

        public ChattingViewModel(SignalRChattingService signalRChattingService)
        {
            SendChattingMessageCommand = new SendChattingMessageCommand(this, signalRChattingService);

            Messages = new ObservableCollection<ChattingColorViewModel>();

            signalRChattingService.ChattingMessageReceived += SignalRChattingService_ChattingMessageReceived;
        }

        public static ChattingViewModel CreatedConnectedViewModel(SignalRChattingService signalRChattingService)
        {
            ChattingViewModel viewModel = new ChattingViewModel(signalRChattingService);

            signalRChattingService.Connect().ContinueWith(task =>
            {
                if (task.Exception is not null)
                {
                    viewModel.ErrorMessage = "Unable to connect to chat hub...";
                }
            });

            return viewModel;
        }

        private void SignalRChattingService_ChattingMessageReceived(ChattingMessage message)
        {
            Messages.Add(new ChattingColorViewModel(message));
        }
    }
}
