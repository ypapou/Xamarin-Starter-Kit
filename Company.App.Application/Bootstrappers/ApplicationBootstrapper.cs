using Company.App.Application.Connectivity;
using Company.App.Application.UserInteraction;
using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Connectivity;
using Company.App.Infrastructure.Dialogs;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Application.Bootstrappers
{
    public class ApplicationBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IConnectivityService>(() => new ConnectivityService(simpleIoc.Get<IConnectivity>()), Reuse.Singleton);
            simpleIoc.Register<IUserInteractionService>(() => new UserInteractionService(simpleIoc.Get<IUserDialog>()), Reuse.Singleton);
        }
    }
}
