using System;
using System.Linq;
using Company.App.Common.Resources;
using Company.App.Ios.Theme;
using Company.App.Presentation.ViewModels.BottomTabBar;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.BottomBar
{
    public class BottomTabBarViewController : BindableTabBarController<BottomTabBarViewModel>
    {
        public NavigationController Template1NavigationController { get; private set; }

        public NavigationController Template2NavigationController { get; private set; }

        public NavigationController Template3NavigationController { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Template1NavigationController = new NavigationController
            {
                TabBarItem = new UITabBarItem(Strings.BottomTabBar_Item_Template1, AppTheme.Current.Images.GetTemplate1Icon24(), 1)
            };

            Template2NavigationController = new NavigationController()
            {
                TabBarItem = new UITabBarItem(Strings.BottomTabBar_Item_Template2, AppTheme.Current.Images.GetTemplate2Icon24(), 2)
            };

            Template3NavigationController = new NavigationController()
            {
                TabBarItem = new UITabBarItem(Strings.BottomTabBar_Item_Template3, AppTheme.Current.Images.GetTemplate3Icon24(), 3)
            };

            ViewControllers = new[]
            {
                Template1NavigationController,
                Template2NavigationController,
                Template3NavigationController
            };

            ShouldSelectViewController = ShouldSetContent;
            this.ViewControllerSelectedWeakSubscribe(BottomTabBarViewController_ViewControllerSelected);
        }

        public void SetContent(NavigationController tabNavigationController, Func<ViewController> tabContentViewControllerFactory)
        {
            if (!tabNavigationController.ViewControllers.Any())
            {
                tabNavigationController.PushViewController(tabContentViewControllerFactory(), false);
            }

            SelectedViewController = tabNavigationController;
        }

        private bool ShouldSetContent(UITabBarController tabBarController, UIViewController viewController)
        {
            var item = (BottomTabBarItem)Array.IndexOf(ViewControllers, viewController);

            return ViewModel.NavigateToItemCommand.CanExecute(item);
        }

        private void BottomTabBarViewController_ViewControllerSelected(object sender, UITabBarSelectionEventArgs e)
        {
            var item = (BottomTabBarItem)Array.IndexOf(ViewControllers, e.ViewController);

            ViewModel.NavigateToItemCommand.Execute(item);
        }
    }
}
