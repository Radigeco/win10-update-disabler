using System.Diagnostics;
using System.Windows;
using MaterialDesignThemes.Wpf;
using NoToAutoUpdates;

namespace UpdateControl
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
            Process.Start("https://github.com/Radigeco");
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/radigeco");
        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto://radigeco@gmail.com");
        }

        private void LinkedinButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/attila-g%C3%A1l-5b6b86b0/");
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
