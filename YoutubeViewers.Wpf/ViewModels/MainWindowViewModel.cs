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
        private MainWindowViewModel _Instance;
        public MainWindowViewModel Instance
        {
            get
            {
                return _Instance;
            }
            set
            {
                _Instance = value;
                this.OnPropertyChanged(nameof(Instance));
            }
        }


        public enum ActiveView
        {
            YoutubeViewers,
            AddUserAccount
        }

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

        public ICommand SwitchViewCommand { get; } = new Commands.CommandsBase((x) =>
        {
            MainWindowViewModel vm = (MainWindowViewModel)x;
            if (vm.CurrentView == ActiveView.YoutubeViewers)
            {
                vm.CurrentViewContent = new AddUserAccountView();
                vm.CurrentView = ActiveView.AddUserAccount;
            }
            else
            {
                vm.CurrentViewContent = new YoutubeViewersView();
                vm.CurrentView = ActiveView.YoutubeViewers;
            }
        });
    }
}
