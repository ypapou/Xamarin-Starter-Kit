using UIKit;
using Xamarin.Essentials;

namespace Company.App.Ios.Theme.Universal.Light
{
    public class UniversalLightAppThemeColors : AppThemeColors
    {
        /* Content */

        public override UIColor ContentBackground { get; } = UIColor.White;

        /* Bottom Tab Bar */

        public override UIColor BottomTabBarBackground { get; } = ColorConverters.FromHex("#03A9F4").ToPlatformColor();

        public override UIColor BottomTabBarItemText { get; } = ColorConverters.FromHex("#B2CFFF").ToPlatformColor();

        public override UIColor BottomTabBarItemTextSelected { get; } = ColorConverters.FromHex("#FFFFFF").ToPlatformColor();

        /* Side Bar */

        public override UIColor SideBarMenuBackground { get; } = UIColor.White;

        public override UIColor SideBarMenuItemBackgroundHighlighted { get; } = UIColor.FromRGB(180, 180, 180);

        public override UIColor SideBarMenuItemBackgroundSelected { get; } = UIColor.FromRGB(220, 220, 220);

        public override UIColor SideBarMenuItemText { get; } = UIColor.Black;
    }
}
