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
        private ObservableCollection<YoutubeUsers> _YoutuberViewersList = new(new Database().GetYoutubeUsers());
        private YoutubeUsers _SelectedYoutubeUser = null;
        public string DisplayUsername => SelectedYoutubeUser?.Username ?? "Please select a username";

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
