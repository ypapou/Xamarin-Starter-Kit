using Company.App.Bootstrappers;
using Company.App.Ios.Navigation;
using Company.App.Ios.Theme;
using Company.App.Ios.Theme.Universal.Light;
using Company.App.Presentation.Navigation;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Ios.Bootstrappers
{
    public class PlatformBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupTheme();
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new AppNavigationService());
        }

        private void SetupTheme()
        {
            AppTheme.Set(new UniversalLightAppTheme());
        }
    }
}
