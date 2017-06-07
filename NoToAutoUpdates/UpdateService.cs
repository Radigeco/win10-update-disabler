using System;
using System.Configuration;
using System.Management;
using System.Security;

namespace UpdateControl
{
    public class UpdateService
    {
        public void DisableUpdates()
        {
            var creator = new CommandLineProcessCreator();
            var stopUpdateService = creator.CreateService(StaticConfigurationManager.GetValue("StopUpdate"));
            stopUpdateService.Start();
            var disableUpdateService = creator.CreateService(StaticConfigurationManager.GetValue("DisableUpdate"));
            disableUpdateService.Start();
            var stopOrchestratorService = creator.CreateService(StaticConfigurationManager.GetValue("StopOrchestrator"));
            stopOrchestratorService.Start();
            var disableOrchestratorService = creator.CreateService(StaticConfigurationManager.GetValue("DisableOrchestrator"));
            disableOrchestratorService.Start();
        }

        public void EnableUpdates()
        {
            var creator = new CommandLineProcessCreator();
            var enableUpdateService = creator.CreateService(StaticConfigurationManager.GetValue("EnableUpdate"));
            enableUpdateService.Start();
            var startUpdateService = creator.CreateService(StaticConfigurationManager.GetValue("StartUpdate"));
            startUpdateService.Start();
            var enableOrchestratorService = creator.CreateService(StaticConfigurationManager.GetValue("EnableOrchestrator"));
            enableOrchestratorService.Start();
            var startOrchestratorService = creator.CreateService(StaticConfigurationManager.GetValue("StartOrchestrator"));
            startOrchestratorService.Start();
        }

        public StartupState GetServiceState(string serviceName)
        {
            StartupState state = StartupState.Automatic;
            try
            {
                PermissionSet fullTrust = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
                fullTrust.Demand();
                string wmiQuery = $"SELECT * FROM Win32_Service WHERE Name='{serviceName}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
                ManagementObjectCollection results = searcher.Get();
                foreach (var service in results)
                {
                    if (service["StartMode"].ToString() == "Disabled")
                        state = StartupState.Disabled;
                    else
                        state = StartupState.Enabled;
                }
                return state;
            }
            catch (SecurityException se)
            {
                return StartupState.Refused;
            }
            catch (Exception e)
            {
                return StartupState.Error;
            }
        }
        public enum StartupState
        {
            Disabled = 0,
            Enabled = 1,
            Automatic = 2,
            Refused = 3,
            Error = 4
        }
    }
}
