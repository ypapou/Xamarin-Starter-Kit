using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Connectivity;
using Company.App.Infrastructure.SecureStorage;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Infrastructure.Bootstrappers
{
    public class InfrastructureBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IConnectivity>(() => Connectivity.Connectivity.Instance);
            simpleIoc.Register<ISecureStorage>(() => SecureStorage.SecureStorage.Instance);
        }
    }
}
