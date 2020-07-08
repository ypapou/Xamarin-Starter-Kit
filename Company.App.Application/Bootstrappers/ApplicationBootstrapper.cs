using Company.App.Application.Services.Connectivity;
using Company.App.Application.UserInteraction;
using Company.App.Bootstrappers;
using Company.App.Infrastructure.Dialogs;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

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
            simpleIoc.Register<IConnectivity>(
                () => new ConnectivityImplementation(),
                Reuse.Singleton);

            simpleIoc.Register<IConnectivityService>(
                () => new ConnectivityService(
                    simpleIoc.Get<IConnectivity>()),
                Reuse.Singleton);

            simpleIoc.Register<IUserInteractionService>(
                () => new UserInteractionService(
                    simpleIoc.Get<IUserDialog>()),
                Reuse.Singleton);
        }
    }
}
