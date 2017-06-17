using System.ServiceProcess;

namespace UpdateControl
{
    public class NativeUpdateService
    {
        public void Disable()
        {
            var serviceController = new ServiceController("TrustedInstaller");
            serviceController.Stop();
            
        }
    }
}
