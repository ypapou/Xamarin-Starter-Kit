using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Connectivity;
using Company.App.Infrastructure.SecureStorage;
using FlexiMvvm.Bootstrappers;

namespace Company.App.Infrastructure.Bootstrappers
{
    public class InfrastructureBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            simpleIoc.Register<IConnectivity>(() => Connectivity.Connectivity.Instance);
            simpleIoc.Register<ISecureStorage>(() => SecureStorage.SecureStorage.Instance);
        }
    }
}
