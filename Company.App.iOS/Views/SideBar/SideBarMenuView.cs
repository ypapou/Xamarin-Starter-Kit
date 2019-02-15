using Cirrious.FluentLayouts.Touch;
using Company.App.Common.Resources;
using Company.App.Ios.Theme;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.SideBar
{
    public class SideBarMenuView : ScrollableLayoutView
    {
        public UIButton Template1Button { get; private set; }

        public UIButton Template2Button { get; private set; }

        public UIButton Template3Button { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.SideBarMenuBackground;
            Template1Button = new UIButton().SetSideBarMenuItemStyle(Strings.SideBarMenu_Item_Template1, AppTheme.Current.Images.GetTemplate1Icon24());
            Template2Button = new UIButton().SetSideBarMenuItemStyle(Strings.SideBarMenu_Item_Template2, AppTheme.Current.Images.GetTemplate2Icon24());
            Template3Button = new UIButton().SetSideBarMenuItemStyle(Strings.SideBarMenu_Item_Template3, AppTheme.Current.Images.GetTemplate3Icon24());
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(Template1Button)
                .AddLayoutSubview(Template2Button)
                .AddLayoutSubview(Template3Button);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            ContentView.AddConstraints(
                Template1Button.AtTopOfSafeArea(ContentView, AppTheme.Current.Dimens.Inset5x),
                Template1Button.AtLeadingOf(ContentView),
                Template1Button.AtTrailingOf(ContentView));

            ContentView.AddConstraints(
                Template2Button.Below(Template1Button),
                Template2Button.AtLeadingOf(ContentView),
                Template2Button.AtTrailingOf(ContentView));

            ContentView.AddConstraints(
                Template3Button.Below(Template2Button),
                Template3Button.AtLeadingOf(ContentView),
                Template3Button.AtTrailingOf(ContentView),
                Template3Button.AtBottomOfSafeArea(ContentView));
        }

        public override void SafeAreaInsetsDidChange()
        {
            base.SafeAreaInsetsDidChange();

            Template1Button.AdjustSideBarMenuItemStyle(SafeAreaInsets);
            Template2Button.AdjustSideBarMenuItemStyle(SafeAreaInsets);
            Template3Button.AdjustSideBarMenuItemStyle(SafeAreaInsets);
        }
    }
}
