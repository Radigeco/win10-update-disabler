using System.Configuration;

namespace UpdateControl
{
    public class UpdateService
    {
        public void DisableUpdates()
        {
            var creator = new ProcessCreator();
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
            var creator = new ProcessCreator();
            var enableUpdateService = creator.CreateService(ConfigurationManager.AppSettings["EnableUpdate"]);
            enableUpdateService.Start();
            var startUpdateService = creator.CreateService(ConfigurationManager.AppSettings["StartUpdate"]);
            startUpdateService.Start();
            var enableOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["EnableOrchestrator"]);
            enableOrchestratorService.Start();
            var startOrchestratorService = creator.CreateService(ConfigurationManager.AppSettings["StartOrchestrator"]);
            startOrchestratorService.Start();
        }
    }
}
