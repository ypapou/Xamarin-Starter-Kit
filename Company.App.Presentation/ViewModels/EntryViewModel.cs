using Company.App.Presentation.Navigation;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels
{
    public class EntryViewModel : LifecycleViewModel
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            if (!recreated)
            {
                _navigationService.NavigateToHome(this);
            }
        }
    }
}
