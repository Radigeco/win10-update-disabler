using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

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
            UpdateServiceStateLabel();
        }

        public void UpdateServiceStateLabel()
        {
            var updateService = new CommandLineUpdateService();
            var serviceState = updateService.GetServiceState(StaticConfigurationManager.GetValue("UpdateServiceName"));
            ServiceStatusLabel.Text = Enum.GetName(typeof(CommandLineUpdateService.StartupState), serviceState);
            if (serviceState == CommandLineUpdateService.StartupState.Disabled)
            {
                ServiceStatusIcon.Kind = PackIconKind.Alert;
                ServiceStatusIcon.Foreground = ConvertFromHexToBrush("#AD1457");
            }
            else
            {
                ServiceStatusIcon.Kind = PackIconKind.CheckboxMarkedCircle;
                ServiceStatusIcon.Foreground = ConvertFromHexToBrush("#00BCD4");
            }
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(StaticConfigurationManager.GetValue("GithubPage"));
        }

        private void LinkedinButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(StaticConfigurationManager.GetValue("LinkedinProfilePage"));
        }

        private void Disable_Click(object sender, RoutedEventArgs e)
        {
            var updateService = new CommandLineUpdateService();
            updateService.DisableUpdates();
            UpdateServiceStateLabel();
        }

        private void Enable_Click(object sender, RoutedEventArgs e)
        {
            var updateService = new CommandLineUpdateService();
            updateService.EnableUpdates();
            UpdateServiceStateLabel();
        }

        public SolidColorBrush ConvertFromHexToBrush(string hexCode)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hexCode);
        }

    }


}
