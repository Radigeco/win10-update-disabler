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
            var stopUpdateService = creator.CreateService(ConfigurationManager.AppSettings["StopUpdate"]);
            stopUpdateService.Start();
            var disableUpdateService = creator.CreateService(ConfigurationManager.AppSettings["DisableUpdate"]);
            disableUpdateService.Start();
            var stopOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["StopOrchestrator"]);
            stopOrchestratorService.Start();
            var disableOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["DisableOrchestrator"]);
            disableOrchestratorService.Start();
        }

        public void EnableUpdates()
        {
            var creator = new CommandLineProcessCreator();
            var enableUpdateService = creator.CreateService(ConfigurationManager.AppSettings["EnableUpdate"]);
            enableUpdateService.Start();
            var startUpdateService = creator.CreateService(ConfigurationManager.AppSettings["StartUpdate"]);
            startUpdateService.Start();
            var enableOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["EnableOrchestrator"]);
            enableOrchestratorService.Start();
            var startOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["StartOrchestrator"]);
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
