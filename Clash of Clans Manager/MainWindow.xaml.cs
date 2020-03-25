using ClashOfClansManager.Classes;
using ClashOfClansManager.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ClashOfClansManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TextResponse { get; set; }
        public string Token { get; set; }
        public ViewModel ViewModel { get; set; }
        public string ClanTag { get; set; }
        public MainWindow()
        {
            //_ = Init();
        }

        private async Task Init()
        {
            ViewModel = new ViewModel();
            var requester = new Requester(Token)
            {
                ClanTag = ClanTag
            };
            await requester.RunAsync(ViewModel).ConfigureAwait(true);
            InitializeComponent();
            DataContext = this;
        }

        private void SendToken_Click(object sender, RoutedEventArgs e)
        {
            Token = TextBoxToken.Text;
            ClanTag = TextBoxClanTag.Text;
            _ = Init();
        }
    }
}
