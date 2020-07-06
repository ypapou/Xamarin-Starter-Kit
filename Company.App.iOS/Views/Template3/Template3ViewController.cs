using Company.App.Presentation.ViewModels.Template3;
using Company.App.Resources;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.Template3
{
    public class Template3ViewController : BindableViewController<Template3ViewModel>
    {
        private UIBarButtonItem SideBarMenuBarButtonItem { get; } = BarButtonItemFactory.CreateSideBarMenu();

        public override void LoadView()
        {
            View = new Template3View();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.Title = Strings.Template3_Title;
            NavigationItem.LeftBarButtonItem = SideBarMenuBarButtonItem;
        }
    }
}
