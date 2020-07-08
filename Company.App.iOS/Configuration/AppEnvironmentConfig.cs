using System;
using Company.App.Configuration;
using Company.App.Ios.Helpers;

namespace Company.App.Ios.Configuration
{
    public sealed class AppEnvironmentConfig : IAppEnvironmentConfig
    {
        public AppEnvironmentConfig()
        {
            CurrentEnvironment = Enum.Parse<CurrentEnvironment>(Secrets.CURRENT_ENVIRONMENT);
        }

        public CurrentEnvironment CurrentEnvironment { get; }

        public string AppCenterSecret => Secrets.APP_CENTER_SECRET;
    }
}
