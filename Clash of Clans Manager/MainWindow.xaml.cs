using Clash_of_Clans_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
