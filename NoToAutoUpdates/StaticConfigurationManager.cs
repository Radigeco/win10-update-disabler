using System;
using System.Collections.Generic;
using System.Configuration;

namespace UpdateControl
{
    public static class StaticConfigurationManager
    {
        private static readonly Dictionary<string, string> DefaultAppSettings;

        static StaticConfigurationManager()
        {
            DefaultAppSettings = new Dictionary<string, string>
            {
                {"StopUpdate","sc stop wuauserv" },
                {"DisableUpdate","sc config wuauserv start=disabled" },
                {"StopOrchestrator","sc stop UsoSvc" },
                {"DisableOrchestrator","sc config UsoSvc start=disabled" },
                {"EnableUpdate","sc config wuauserv start=demand" },
                {"StartUpdate","sc start wuauserv" },
                {"EnableOrchestrator","sc config UsoSvc start=demand" },
                {"StartOrchestrator","sc start UsoSvc" },
                {"UpdateServiceName","wuauserv" },
                {"LinkedinProfilePage","https://www.linkedin.com/in/attila-g%C3%A1l-5b6b86b0/" },
                {"GithubPage","https://github.com/Radigeco" },
                {"EnableTrustedInstaller","sc config TrustedInstaller start=demand"},
                {"AutomaticTrustedInstaller","sc config TrustedInstaller start=delayed-auto "}
            };
        }

        public static string GetValue(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (String.IsNullOrEmpty(value))
                value = DefaultAppSettings[key];
            return value;
        }
    }
}