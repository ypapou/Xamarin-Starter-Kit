using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Dialogs;
using Company.App.Infrastructure.Http;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Infrastructure.Bootstrappers
{
    public class PlatformInfrastructureBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IUserDialog>(() => new UserDialog(), Reuse.Singleton);
            simpleIoc.Register<INativeHttpClientHandlerFactory>(() => new NativeHttpClientHandlerFactory(), Reuse.Singleton);
        }
    }
}
