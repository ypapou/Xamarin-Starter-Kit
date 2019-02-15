using UIKit;

namespace Company.App.Ios.Theme
{
    public abstract class AppThemeColors
    {
        public abstract UIColor ContentBackground { get; }

        public abstract UIColor SideBarMenuBackground { get; }

        public abstract UIColor SideBarMenuItemBackgroundHighlighted { get; }

        public abstract UIColor SideBarMenuItemBackgroundSelected { get; }

        public abstract UIColor SideBarMenuItemText { get; }
    }
}
