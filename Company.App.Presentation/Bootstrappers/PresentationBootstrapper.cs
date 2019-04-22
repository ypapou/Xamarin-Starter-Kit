using System;
using System.Net.Http;
using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Http;
using Company.App.Presentation.Navigation;
using Company.App.Presentation.Operations;
using Company.App.Presentation.ViewModels;
using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Presentation.ViewModels.SideBar;
using Company.App.Presentation.ViewModels.Template1;
using Company.App.Presentation.ViewModels.Template2;
using Company.App.Presentation.ViewModels.Template3;
using FFImageLoading;
using FFImageLoading.Config;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.Bootstrappers
{
    public class PresentationBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupViewModels(simpleIoc);
            SetupLifecycleViewModelProvider(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc, new ErrorHandler()), Reuse.Singleton);
            simpleIoc.Register<IImageService>(() => CreateImageService(simpleIoc), Reuse.Singleton);
        }

        private void SetupViewModels(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<ISideBarNavigationMediator>(() => new SideBarNavigationMediator(), Reuse.Singleton);
            simpleIoc.Register(() => new EntryViewModel(simpleIoc.Get<INavigationService>()));
            simpleIoc.Register(() => new SideBarViewModel(simpleIoc.Get<INavigationService>(), simpleIoc.Get<ISideBarNavigationMediator>()));
            simpleIoc.Register(() => new SideBarMenuViewModel(simpleIoc.Get<ISideBarNavigationMediator>()));
            simpleIoc.Register(() => new BottomTabBarViewModel(simpleIoc.Get<INavigationService>()));
            simpleIoc.Register(() => new Template1ViewModel());
            simpleIoc.Register(() => new Template2ViewModel());
            simpleIoc.Register(() => new Template3ViewModel());
        }

        private void SetupLifecycleViewModelProvider(IServiceProvider serviceProvider)
        {
            LifecycleViewModelProvider.SetFactory(new DefaultLifecycleViewModelFactory(serviceProvider));
        }

        private IImageService CreateImageService(IDependencyProvider dependencyProvider)
        {
            var imageService = new ImageService();
            var nativeHttpClientHandlerFactory = dependencyProvider.Get<INativeHttpClientHandlerFactory>();

            imageService.Initialize(new Configuration
            {
                HttpClient = new HttpClient(nativeHttpClientHandlerFactory.Create())
            });

            return imageService;
        }
    }
}
