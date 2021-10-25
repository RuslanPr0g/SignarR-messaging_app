namespace Chatting.WPF.ViewModels
{
    public class MainViewModel
    {
        public ChattingViewModel ChattingViewModel { get; }

        public MainViewModel(ChattingViewModel chatViewModel)
        {
            ChattingViewModel = chatViewModel;
        }
    }
}
