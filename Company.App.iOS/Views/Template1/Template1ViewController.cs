using Company.App.Presentation.ViewModels.Template1;
using Company.App.Resources;
using FlexiMvvm.Views;
using UIKit;

namespace Company.App.Ios.Views.Template1
{
    public class Template1ViewController : FlexiBindableViewController<Template1ViewModel>
    {
        private UIBarButtonItem SideBarMenuBarButtonItem { get; } = BarButtonItemFactory.CreateSideBarMenu();

        public override void LoadView()
        {
            View = new Template1View();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.Title = Strings.Template1_Title;
            NavigationItem.LeftBarButtonItem = SideBarMenuBarButtonItem;
        }
    }
}
