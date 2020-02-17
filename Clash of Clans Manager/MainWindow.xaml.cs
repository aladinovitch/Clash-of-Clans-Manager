using Clash_of_Clans_Manager.Classes;
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
        public MainWindow()
        {
            _ = Init();
        }

        private async Task Init()
        {
            var requester = new Requester();
            await requester.RunAsync().ConfigureAwait(true);
            TextResponse = requester.Response;
            InitializeComponent();
            DataContext = this;
        }
    }
}
