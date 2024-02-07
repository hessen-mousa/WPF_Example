using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Wpf.BusinessLogic;
using YoutubeViewers.Wpf.Commands;
using YoutubeViewers.Wpf.Models;


namespace YoutubeViewers.Wpf.ViewModels
{
    internal class YoutubeViewsViewModel : ViewModelBase
    {
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

        public ICommand RemoveYoutubeUserCommand { get; set; }

        public ICommand AddYoutubeUserCommand { get;set; }

        public YoutubeViewsViewModel()
        {
            RemoveYoutubeUserCommand = new RelayCommand(OnRemoveCommandExcute);
            AddYoutubeUserCommand = new RelayCommand(OnAddYoutubeUserCommandExcute);
        }

        private void OnAddYoutubeUserCommandExcute(object sender)
        {
            this.YoutuberViewersList.Add(new YoutubeUsers { Username = "Markus", IsMember = false, IsSubscribed = true });

        }
        private void OnRemoveCommandExcute(object sender)
        {
            this.YoutuberViewersList.Remove(this.YoutuberViewersList.Last());
        }
    }
}
