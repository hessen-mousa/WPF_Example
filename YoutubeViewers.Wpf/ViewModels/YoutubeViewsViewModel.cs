using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Wpf.BusinessLogic;
using YoutubeViewers.Wpf.Models;


namespace YoutubeViewers.Wpf.ViewModels
{
    internal class YoutubeViewsViewModel : ViewModelBase
    {
        private YoutubeViewsViewModel _Instance;
        public YoutubeViewsViewModel Instance
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

        private ObservableCollection<YoutubeUsers> _YoutuberViewersList = new(new Database().GetYoutubeUsers());
        public ObservableCollection<YoutubeUsers> YoutuberViewersList
        {
            get
            {
                return _YoutuberViewersList;
            }
            set
            {
                _YoutuberViewersList = value;
                this.OnPropertyChanged(nameof(YoutuberViewersList));
            }
        }

        private YoutubeUsers _SelectedYoutubeUser = null;
        public YoutubeUsers SelectedYoutubeUser
        {
            get
            {
                return _SelectedYoutubeUser;
            }
            set
            {
                _SelectedYoutubeUser = value;
                this.OnPropertyChanged(nameof(SelectedYoutubeUser));
                this.OnPropertyChanged(nameof(DisplayUsername));
            }
        }
        public string DisplayUsername => SelectedYoutubeUser?.Username ?? "Please select a username";

        public ICommand AddYoutubeUser { get; } = new Commands.CommandsBase((x) =>
        {
            YoutubeViewsViewModel vm = (YoutubeViewsViewModel)x;
            vm.YoutuberViewersList.Add(new YoutubeUsers { Username = "Markus", IsMember = false, IsSubscribed = true });
        });

        public ICommand RemoveYoutubeUser { get; } = new Commands.CommandsBase((x) =>
        {
            YoutubeViewsViewModel vm = (YoutubeViewsViewModel)x;
            vm.YoutuberViewersList.Remove(vm.YoutuberViewersList.Last());

        });
    }
}
