using UIKit;

namespace Company.App.Ios.Theme.Universal.Light
{
    public class UniversalLightAppThemeColors : AppThemeColors
    {
        public override UIColor ContentBackground { get; } = UIColor.White;

        public override UIColor SideBarMenuBackground { get; } = UIColor.White;

        public override UIColor SideBarMenuItemBackgroundHighlighted { get; } = UIColor.FromRGB(180, 180, 180);

        public override UIColor SideBarMenuItemBackgroundSelected { get; } = UIColor.FromRGB(220, 220, 220);

        public override UIColor SideBarMenuItemText { get; } = UIColor.Black;
    }
}
