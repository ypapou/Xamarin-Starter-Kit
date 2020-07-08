using Company.App.Application.Bootstrappers;
using Company.App.Bootstrappers;
using Company.App.Configuration;
using Company.App.Infrastructure.Bootstrappers;
using Company.App.Ios.Configuration;
using Company.App.Presentation.Bootstrappers;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Configuration;
using FlexiMvvm.Ioc;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;

namespace Company.App.Ios.Bootstrappers
{
    public static class InitialBootstrapper
    {
        public static void Execute()
        {
            var config = CreateBootstrapperConfig();
            var simpleIoc = config.GetSimpleIoc();

            SetupEnvironmentConfig(simpleIoc);
            SetupAppCenter(simpleIoc);
            SetupFlexiMvvm();

            ExecuteBootstrappers(config);
        }

        private static BootstrapperConfig CreateBootstrapperConfig()
        {
            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            return config;
        }

        private static void SetupEnvironmentConfig(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register(
                () => new AppEnvironmentConfig(),
                Reuse.Singleton);

            simpleIoc.Register<IEnvironmentConfig>(
                simpleIoc.Get<AppEnvironmentConfig>);

            simpleIoc.Register<IAppEnvironmentConfig>(
                simpleIoc.Get<AppEnvironmentConfig>);
        }

        private static void SetupAppCenter(ISimpleIoc simpleIoc)
        {
            var appEnvironmentConfig = simpleIoc.Get<IAppEnvironmentConfig>();
            var appCenterSecret = appEnvironmentConfig.AppCenterSecret;

            AppCenter.Start(appCenterSecret, typeof(Crashes));
        }

        private static void SetupFlexiMvvm()
        {
            FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged(false);
        }

        private static void ExecuteBootstrappers(BootstrapperConfig config)
        {
            var compositeBootstrapper = new CompositeBootstrapper(
                new CommonBootstrapper(),
                new InfrastructureBootstrapper(),
                new PlatformInfrastructureBootstrapper(),
                new ApplicationBootstrapper(),
                new PresentationBootstrapper(),
                new PlatformBootstrapper());
            compositeBootstrapper.Execute(config);
        }
    }
}
