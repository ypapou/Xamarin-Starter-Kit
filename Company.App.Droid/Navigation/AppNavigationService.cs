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
        public void NavigateToHome(IViewModel fromViewModel)
        {
            var fromView = GetView(fromViewModel);

            Navigate<SideBarActivity>(fromView);
        }

        public void NavigateToTemplate1(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = GetActivity<SideBarActivity, SideBarViewModel>(fromViewModel);
            var contentView = Template1Fragment.NewInstance();

            hostView.SetContent(contentView, isDefault);
        }

        public void NavigateToTemplate1(BottomTabBarViewModel fromViewModel)
        {
            var hostView = GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template1Fragment.NewInstance();

            hostView.SetContent(contentView);
        }

        public void NavigateToTemplate2(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = GetActivity<SideBarActivity, SideBarViewModel>(fromViewModel);
            var contentView = Template2Fragment.NewInstance();

            hostView.SetContent(contentView, isDefault);
        }

        public void NavigateToTemplate2(BottomTabBarViewModel fromViewModel)
        {
            var hostView = GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template2Fragment.NewInstance();

            hostView.SetContent(contentView);
        }

        public void NavigateToTemplate3(SideBarViewModel fromViewModel, bool isDefault)
        {
            var hostView = GetActivity<SideBarActivity, SideBarViewModel>(fromViewModel);
            var contentView = Template3Fragment.NewInstance();

            hostView.SetContent(contentView, isDefault);
        }

        public void NavigateToTemplate3(BottomTabBarViewModel fromViewModel)
        {
            var hostView = GetActivity<BottomTabBarActivity, BottomTabBarViewModel>(fromViewModel);
            var contentView = Template3Fragment.NewInstance();

            hostView.SetContent(contentView);
        }
    }
}
