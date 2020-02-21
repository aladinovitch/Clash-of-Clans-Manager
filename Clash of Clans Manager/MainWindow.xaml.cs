﻿using Clash_of_Clans_Manager.Classes;
using Clash_of_Clans_Manager.Model;
using System.Threading.Tasks;
using System.Windows;

namespace Clash_of_Clans_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TextResponse { get; set; }
        public ViewModel ViewModel { get; set; }
        public MainWindow()
        {
            _ = Init();
        }

        private async Task Init()
        {
            ViewModel = new ViewModel();
            var requester = new Requester();
            await requester.RunAsync(ViewModel).ConfigureAwait(true);
            TextResponse = ViewModel.Clan.ToString();
            InitializeComponent();
            DataContext = this;
        }
    }
}
