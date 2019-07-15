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

        public override UIColor SideBarMenuItemBackgroundHighlighted { get; } = ColorConverters.FromHex("#B4B4B4").ToPlatformColor();

        public override UIColor SideBarMenuItemBackgroundSelected { get; } = ColorConverters.FromHex("#DCDCDC").ToPlatformColor();

        public override UIColor SideBarMenuItemIconBackground { get; } = UIColor.Black;

        public override UIColor SideBarMenuItemText { get; } = UIColor.Black;
    }
}
