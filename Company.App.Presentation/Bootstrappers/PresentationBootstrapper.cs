using System.Net.Http;
using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Http;
using Company.App.Presentation.Operations;
using FFImageLoading;
using FFImageLoading.Config;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Bootstrappers
{
    public class PresentationBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupFFImageLoading(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc, new ErrorHandler()), Reuse.Singleton);
        }

        private void SetupFFImageLoading(IDependencyProvider dependencyProvider)
        {
            var nativeHttpClientHandlerFactory = dependencyProvider.Get<INativeHttpClientHandlerFactory>();

            ImageService.Instance.Initialize(new Configuration
            {
                HttpClient = new HttpClient(nativeHttpClientHandlerFactory.Create())
            });
        }
    }
}
