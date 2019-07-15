using Company.App.Droid.Views.BottomTabBar;
using Company.App.Droid.Views.SideBar;
using Company.App.Droid.Views.Template1;
using Company.App.Droid.Views.Template2;
using Company.App.Droid.Views.Template3;
using Company.App.Presentation.Navigation;
using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;

namespace Company.App.Droid.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToHome(ILifecycleViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.Get(fromViewModel);

            Navigate<SideBarActivity>(fromView);
        }

        public void NavigateToTemplate1(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetFragment<SideBarMenuFragment, SideBarMenuViewModel>(fromViewModel);
            var hostView = (SideBarActivity)fromView.Activity;
            var contentView = Template1Fragment.NewInstance();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template1);
        }

        public void NavigateToTemplate1(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template1Fragment.NewInstance();

            hostView.SetRootContent(contentView, BottomTabBarItem.Template1);
        }

        public void NavigateToTemplate2(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetFragment<SideBarMenuFragment, SideBarMenuViewModel>(fromViewModel);
            var hostView = (SideBarActivity)fromView.Activity;
            var contentView = Template2Fragment.NewInstance();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template2);
        }

        public void NavigateToTemplate2(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template2Fragment.NewInstance();

            hostView.SetRootContent(contentView, BottomTabBarItem.Template2);
        }

        public void NavigateToTemplate3(SideBarMenuViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetFragment<SideBarMenuFragment, SideBarMenuViewModel>(fromViewModel);
            var hostView = (SideBarActivity)fromView.Activity;
            var contentView = Template3Fragment.NewInstance();

            hostView.SetRootContent(contentView, SideBarMenuItem.Template3);
        }

        public void NavigateToTemplate3(BottomTabBarViewModel fromViewModel)
        {
            var hostView = NavigationViewProvider.GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template3Fragment.NewInstance();

            hostView.SetRootContent(contentView, BottomTabBarItem.Template3);
        }
    }
}
