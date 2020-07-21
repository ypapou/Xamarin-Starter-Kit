using System;
using System.Linq;
using Company.App.Ios.Theme;
using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Resources;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.BottomTabBar
{
    public class BottomTabBarViewController : FlexiBindableTabBarController<BottomTabBarViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var template1NavigationController = new UINavigationController
            {
                TabBarItem = new UITabBarItem(
                    Strings.BottomTabBar_Item_Template1,
                    AppTheme.Current.Images.GetTemplate1Icon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    AppTheme.Current.Images.GetTemplate1SelectedIcon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal))
            };

            var template2NavigationController = new UINavigationController
            {
                TabBarItem = new UITabBarItem(
                    Strings.BottomTabBar_Item_Template2,
                    AppTheme.Current.Images.GetTemplate2Icon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    AppTheme.Current.Images.GetTemplate2SelectedIcon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal))
            };

            var template3NavigationController = new UINavigationController
            {
                TabBarItem = new UITabBarItem(
                    Strings.BottomTabBar_Item_Template3,
                    AppTheme.Current.Images.GetTemplate3Icon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    AppTheme.Current.Images.GetTemplate3SelectedIcon24().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal))
            };

            ViewControllers = new UIViewController[]
            {
                template1NavigationController,
                template2NavigationController,
                template3NavigationController
            };

            ShouldSelectViewController = ShouldSetContent;
            this.ViewControllerSelectedWeakSubscribe(BottomTabBarViewController_ViewControllerSelected);
        }

        public void SetRootContent(Func<UIViewController> viewControllerFactory, BottomTabBarItem item)
        {
            var tabNavigationController = (UINavigationController)GetTabViewController(item);

            if (!tabNavigationController.ViewControllers.Any())
            {
                tabNavigationController.PushViewController(viewControllerFactory(), false);
            }

            SelectedViewController = tabNavigationController;
            ViewModel.SelectedItem = item;
        }

        private bool ShouldSetContent(UITabBarController tabBarController, UIViewController viewController)
        {
            var item = GetBottomTabBarItem(viewController);

            return ViewModel.NavigateToItemCommand.CanExecute(item);
        }

        private UIViewController GetTabViewController(BottomTabBarItem item)
        {
            return ViewControllers[(int)item];
        }

        private BottomTabBarItem GetBottomTabBarItem(UIViewController viewController)
        {
            return (BottomTabBarItem)Array.IndexOf(ViewControllers, viewController);
        }

        private void BottomTabBarViewController_ViewControllerSelected(object sender, UITabBarSelectionEventArgs e)
        {
            var item = GetBottomTabBarItem(e.ViewController);

            ViewModel.NavigateToItemCommand.Execute(item);
        }
    }
}
