﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YoutubeViewers.Wpf.ViewModels;

namespace YoutubeViewers.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            ((MainWindowViewModel)this.DataContext).Instance = (MainWindowViewModel)this.DataContext;
            ((MainWindowViewModel)this.DataContext).CurrentViewContent = new Views.YoutubeViewersView();
        }
    }
}