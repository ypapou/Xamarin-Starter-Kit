using Company.App.Bootstrappers;
using Company.App.Droid.Navigation;
using Company.App.Presentation.Navigation;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Droid.Bootstrappers
{
    public class PlatformBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new AppNavigationService());
        }
    }
}
