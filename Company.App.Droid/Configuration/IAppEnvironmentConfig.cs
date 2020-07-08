using Company.App.Configuration;

namespace Company.App.Droid.Configuration
{
    public interface IAppEnvironmentConfig : IEnvironmentConfig
    {
        string AppCenterSecret { get; }
    }
}
