using System.Windows;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;

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
            CreatePopup("Done!");

        }

        private void Enable_Click(object sender, RoutedEventArgs e)
        {
            var updateService = new UpdateService();
            updateService.EnableUpdates();
            CreatePopup("Done!");
        }


        private void CreatePopup(string message)
        {
            var messageDialog = new MessageDialog
            {
                Message = { Text = message }
            };

            DialogHost.Show(messageDialog);
        }
    }
}
