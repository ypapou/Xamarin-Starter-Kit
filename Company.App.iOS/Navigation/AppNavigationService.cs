using System;
using Company.App.Ios.Views.BottomBar;
using Company.App.Ios.Views.SideBar;
using Company.App.Ios.Views.Template1;
using Company.App.Ios.Views.Template2;
using Company.App.Ios.Views.Template3;
using Company.App.Presentation.Navigation;
using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;

namespace Company.App.Ios.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToHome(ILifecycleViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.Get(fromViewModel);
            var toView = new SideBarViewController();

            Navigate(fromView, toView, true);
        }

        public void NavigateToTemplate1(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = NavigationViewProvider.GetViewController<SideBarViewController, SideBarViewModel>(fromViewModel);
            var contentView = new Template1ViewController();

            hostView.SetContent(contentView);
        }

        public void NavigateToTemplate1(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template1ViewController> contentViewFactory = () => new Template1ViewController();

            hostView.SetContent(hostView.Template1NavigationController, contentViewFactory);
        }

        public void NavigateToTemplate2(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = NavigationViewProvider.GetViewController<SideBarViewController, SideBarViewModel>(fromViewModel);
            var contentView = new Template2ViewController();

            hostView.SetContent(contentView);
        }

        public void NavigateToTemplate2(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template2ViewController> contentViewFactory = () => new Template2ViewController();

            hostView.SetContent(hostView.Template2NavigationController, contentViewFactory);
        }

        public void NavigateToTemplate3(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = NavigationViewProvider.GetViewController<SideBarViewController, SideBarViewModel>(fromViewModel);
            var contentView = new Template3ViewController();

            hostView.SetContent(contentView);
        }

        public void NavigateToTemplate3(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template3ViewController> contentViewFactory = () => new Template3ViewController();

            hostView.SetContent(hostView.Template3NavigationController, contentViewFactory);
        }
    }
}
