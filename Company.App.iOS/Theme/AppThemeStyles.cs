using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Theme
{
    public static class AppThemeStyles
    {
        public static void SetSideBarMenuItemStyle(this UIButton button, string title, UIImage icon)
        {
            button.ContentEdgeInsets = new UIEdgeInsets(0, AppTheme.Current.Dimens.Inset2x, 0, AppTheme.Current.Dimens.Inset1x);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.SetBackgroundImage(AppTheme.Current.Colors.SideBarMenuItemBackgroundHighlighted.ToImage(), UIControlState.Highlighted);
            button.SetBackgroundImage(AppTheme.Current.Colors.SideBarMenuItemBackgroundSelected.ToImage(), UIControlState.Selected);
            button.SetImage(icon.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(AppTheme.Current.Colors.SideBarMenuItemText, UIControlState.Normal);
            button.TintColor = AppTheme.Current.Colors.SideBarMenuItemIconBackground;
            button.TitleEdgeInsets = new UIEdgeInsets(0, AppTheme.Current.Dimens.Inset1x, 0, 0);
            button.AddConstraints(button.Height().EqualTo(AppTheme.Current.Dimens.SideBarMenuItemHeight).SetPriority((int)UILayoutPriority.DefaultHigh));
        }

        public static void AdjustSideBarMenuItemStyle(this UIButton button, UIEdgeInsets safeAreaInsets)
        {
            button.ContentEdgeInsets = new UIEdgeInsets(0, safeAreaInsets.Left + AppTheme.Current.Dimens.Inset2x, 0, AppTheme.Current.Dimens.Inset1x);
        }
    }
}
