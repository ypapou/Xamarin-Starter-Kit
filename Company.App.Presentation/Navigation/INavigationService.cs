using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToHome(ILifecycleViewModel fromViewModel);

        void NavigateToTemplate1(SideBarViewModel fromViewModel, bool isDefault);

        void NavigateToTemplate1(BottomTabBarViewModel fromViewModel, bool isDefault);

        void NavigateToTemplate2(SideBarViewModel fromViewModel, bool isDefault);

        void NavigateToTemplate2(BottomTabBarViewModel fromViewModel, bool isDefault);

        void NavigateToTemplate3(SideBarViewModel fromViewModel, bool isDefault);

        void NavigateToTemplate3(BottomTabBarViewModel fromViewModel, bool isDefault);
    }
}
