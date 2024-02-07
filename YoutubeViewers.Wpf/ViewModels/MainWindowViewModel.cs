using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Wpf.Views;

namespace YoutubeViewers.Wpf.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public enum ActiveView
        {
            YoutubeViewers,
            AddUserAccount
        }

        private object _currentViewContent;
        public object CurrentViewContent
        {
            get => _currentViewContent;
            set
            {
                _currentViewContent = value;
                OnPropertyChanged(nameof(CurrentViewContent));
            }
        }

        public ICommand SwitchViewCommand { get; }

        private ActiveView _currentView;
        public ActiveView CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public MainWindowViewModel()
        {
            SwitchViewCommand = new Commands.RelayCommand(OnSwitchCommandExcute);
            CurrentViewContent = new YoutubeViewersView();
        }

        private void OnSwitchCommandExcute(object sender)
        {
            if (CurrentView == ActiveView.YoutubeViewers)
            {
                CurrentViewContent = new AddUserAccountView();
                CurrentView = ActiveView.AddUserAccount;
            }
            else
            {
                CurrentViewContent = new YoutubeViewersView();
                CurrentView = ActiveView.YoutubeViewers;
            }
        }

    }
}
