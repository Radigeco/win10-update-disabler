namespace NoToAutoUpdates
{
    public class UpdateService
    {
        public void DisableUpdates()
        {
            var creator = new ProcessCreator();
            var stopUpdateService = creator.CreateService("sc stop wuauserv");
            stopUpdateService.Start();
            var disableUpdateService = creator.CreateService("sc config wuauserv start=disabled");
            disableUpdateService.Start();
            var stopOrchestratorService = creator.CreateService("sc stop UsoSvc");
            stopOrchestratorService.Start();
            var disableOrchestratorService = creator.CreateService("sc config UsoSvc start=disabled");
            disableOrchestratorService.Start();
        }

        public void EnableUpdates()
        {
            var creator = new ProcessCreator();
            var enableUpdateService = creator.CreateService("sc config wuauserv start=demand");
            enableUpdateService.Start();
            var startUpdateService = creator.CreateService("sc start wuauserv");
            startUpdateService.Start();
            var enableOrchestratorService = creator.CreateService("sc config UsoSvc start=demand");
            enableOrchestratorService.Start();
            var startOrchestratorService = creator.CreateService("sc start UsoSvc");
            startOrchestratorService.Start();
        }
    }
}
