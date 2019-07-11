using System;
using UIKit;

namespace Company.App.Ios.Theme
{
    public abstract class AppTheme
    {
        private static AppTheme _current;

        protected AppTheme()
        {
            SetUITabBarAppearance();
            SetUITabBarItemAppearance();
        }

        public static AppTheme Current => _current ?? throw new InvalidOperationException(
            $"Application theme is not specified. Use '{nameof(AppTheme)}.{nameof(Set)}' method to set the theme.");

        public abstract AppThemeColors Colors { get; }

        public virtual AppThemeDimens Dimens { get; } = new AppThemeDimens();

        public virtual AppThemeFonts Fonts { get; } = new AppThemeFonts();

        public virtual AppThemeImages Images { get; } = new AppThemeImages();

        public static void Set(AppTheme theme)
        {
            _current = theme;
        }

        private void SetUITabBarAppearance()
        {
            UITabBar.Appearance.BarTintColor = Colors.BottomTabBarBackground;
        }

        private void SetUITabBarItemAppearance()
        {
            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes { TextColor = Colors.BottomTabBarItemText },
                UIControlState.Normal);

            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes { TextColor = Colors.BottomTabBarItemTextSelected },
                UIControlState.Selected);
        }
    }
}
