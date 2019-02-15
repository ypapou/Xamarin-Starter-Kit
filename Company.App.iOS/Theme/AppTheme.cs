using System;

namespace Company.App.Ios.Theme
{
    public abstract class AppTheme
    {
        private static AppTheme _current;

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
    }
}
