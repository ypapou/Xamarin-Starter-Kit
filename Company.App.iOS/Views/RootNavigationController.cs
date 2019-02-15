using Company.App.Presentation.ViewModels;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views
{
    public class RootNavigationController : NavigationController<EntryViewModel>
    {
        public RootNavigationController()
        {
            NavigationBarHidden = true;
        }
    }
}
