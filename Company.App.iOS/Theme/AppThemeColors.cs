using UIKit;

namespace Company.App.Ios.Theme
{
    public abstract class AppThemeColors
    {
        /* Content */

        public abstract UIColor ContentBackground { get; }

        /* Bottom Tab Bar */

        public abstract UIColor BottomTabBarBackground { get; }

        public abstract UIColor BottomTabBarItemText { get; }

        public abstract UIColor BottomTabBarItemTextSelected { get; }

        /* Side Bar */

        public abstract UIColor SideBarMenuBackground { get; }

        public abstract UIColor SideBarMenuItemBackgroundHighlighted { get; }

        public abstract UIColor SideBarMenuItemBackgroundSelected { get; }

        public abstract UIColor SideBarMenuItemIconBackground { get; }

        public abstract UIColor SideBarMenuItemText { get; }
    }
}
