using Company.App.Configuration;

namespace Company.App.Ios.Configuration
{
    public interface IAppEnvironmentConfig : IEnvironmentConfig
    {
        string AppCenterSecret { get; }
    }
}
