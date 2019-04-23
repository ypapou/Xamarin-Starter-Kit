using Company.App.Common.Resources;
using Company.App.Presentation.ViewModels.Template2;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.Template2
{
    public class Template2ViewController : BindableViewController<Template2ViewModel>
    {
        private UIBarButtonItem SideBarMenuBarButtonItem { get; } = BarButtonItemFactory.CreateSideBarMenu();

        public override void LoadView()
        {
            View = new Template2View();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.Title = Strings.Template2_Title;
            NavigationItem.LeftBarButtonItem = SideBarMenuBarButtonItem;
        }
    }
}
