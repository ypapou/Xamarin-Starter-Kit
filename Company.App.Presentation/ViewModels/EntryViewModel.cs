using Company.App.Presentation.Navigation;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels
{
    public class EntryViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize()
        {
            base.Initialize();

            _navigationService.NavigateToHome(this);
        }
    }
}
