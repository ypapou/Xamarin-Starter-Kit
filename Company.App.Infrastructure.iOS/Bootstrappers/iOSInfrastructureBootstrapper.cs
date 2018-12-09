using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Dialogs;
using Company.App.Infrastructure.Http;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Infrastructure.Bootstrappers
{
    public class IosInfrastructureBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            simpleIoc.Register<IUserDialog>(() => new UserDialog(), Reuse.Singleton);
            simpleIoc.Register<INativeHttpClientHandlerFactory>(() => new NativeHttpClientHandlerFactory(), Reuse.Singleton);
        }
    }
}
