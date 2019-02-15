using Company.App.Ios.Theme;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views.Template3
{
    public class Template3View : ScrollableLayoutView
    {
        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.ContentBackground;
        }
    }
}
