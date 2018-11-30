using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Connectivity;
using FlexiMvvm.Bootstrappers;

namespace Company.App.Infrastructure.Bootstrappers
{
    public class InfrastructureBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            simpleIoc.Register<IConnectivity>(() => Connectivity.Connectivity.Instance);
        }
    }
}
