using Company.App.Ios.Theme;
using Company.App.Ios.Views.SideBar;
using UIKit;

namespace Company.App.Ios.Views
{
    public static class BarButtonItemFactory
    {
        public static UIBarButtonItem CreateSideBarMenu()
        {
            return new UIBarButtonItem(
                AppTheme.Current.Images.GetSideBarMenuIcon24(),
                UIBarButtonItemStyle.Plain,
                (sender, args) => SideBarViewController.Current?.ToggleMenu());
        }
    }
}
