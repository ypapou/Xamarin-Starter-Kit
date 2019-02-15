using Company.App.Ios.Theme;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views.Template1
{
    public class Template1View : ScrollableLayoutView
    {
        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.ContentBackground;
        }
    }
}
