using Chatting.Domain;
using System;
using System.Windows.Media;

namespace Chatting.WPF.ViewModels
{
    public class ChattingColorViewModel : ViewModelBase
    {
        public ChattingMessage ChattingMessage { get; set; }

        public Brush ColorBrush
        {
            get
            {
                try
                {
                    return new SolidColorBrush(Color.FromRgb(
                        ChattingMessage.Red,
                        ChattingMessage.Green,
                        ChattingMessage.Blue));
                }
                catch (FormatException)
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
        }

        public ChattingColorViewModel(ChattingMessage chattingMessage)
        {
            this.ChattingMessage = chattingMessage;
        }
    }
}
