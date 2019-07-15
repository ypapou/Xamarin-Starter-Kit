using System;
using Company.App.Ios.Views.BottomTabBar;
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

        public void NavigateToTemplate1(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetViewController<SideBarMenuViewController, SideBarMenuViewModel>(fromViewModel);
            var hostView = fromView.SideBarViewController;
            var contentView = new Template1ViewController();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template1);
        }

        public void NavigateToTemplate1(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template1ViewController> contentViewFactory = () => new Template1ViewController();

            hostView.SetRootContent(contentViewFactory, BottomTabBarItem.Template1);
        }

        public void NavigateToTemplate2(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetViewController<SideBarMenuViewController, SideBarMenuViewModel>(fromViewModel);
            var hostView = fromView.SideBarViewController;
            var contentView = new Template2ViewController();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template2);
        }

        public void NavigateToTemplate2(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template2ViewController> contentViewFactory = () => new Template2ViewController();

            hostView.SetRootContent(contentViewFactory, BottomTabBarItem.Template2);
        }

        public void NavigateToTemplate3(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetViewController<SideBarMenuViewController, SideBarMenuViewModel>(fromViewModel);
            var hostView = fromView.SideBarViewController;
            var contentView = new Template3ViewController();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template3);
        }

        public void NavigateToTemplate3(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetViewController<BottomTabBarViewController, BottomTabBarViewModel>(fromViewModel);
            Func<Template3ViewController> contentViewFactory = () => new Template3ViewController();

            hostView.SetRootContent(contentViewFactory, BottomTabBarItem.Template3);
        }
    }
}
