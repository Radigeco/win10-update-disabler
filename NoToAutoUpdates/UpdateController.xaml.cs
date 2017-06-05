using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NoToAutoUpdates
{
    /// <summary>
    /// Interaction logic for UpdateController.xaml
    /// </summary>
    public partial class UpdateController : Window
    {
        public UpdateController()
        {
            InitializeComponent();
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TwitterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Disable_Click(object sender, RoutedEventArgs e)
        {
            var updateService = new UpdateService();
            updateService.DisableUpdates();
        }

        private void Enable_Click(object sender, RoutedEventArgs e)
        {
            var updateService = new UpdateService();
            updateService.EnableUpdates();
        }
    }
}
