using Company.App.Common.Bootstrappers;
using Company.App.Presentation.Operations;
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

            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc, new ErrorHandler()), Reuse.Singleton);
        }
    }
}
