using Company.App.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.Interactions;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISideBarNavigationMediator _sideBarNavigationMediator;

        public SideBarViewModel(INavigationService navigationService, ISideBarNavigationMediator sideBarNavigationMediator)
        {
            _navigationService = navigationService;
            _sideBarNavigationMediator = sideBarNavigationMediator;

            _sideBarNavigationMediator.SetSideBarViewModel(this);
        }

        public Interaction CloseMenuInteraction { get; } = new Interaction();

        public Command SelectDefaultMenuItemCommand => CommandProvider.Get(_sideBarNavigationMediator.SelectDefaultMenuItem);

        internal void NavigateToTemplate1(bool isDefault)
        {
            _navigationService.NavigateToTemplate1(this, isDefault);
        }

        internal void NavigateToTemplate2(bool isDefault)
        {
            _navigationService.NavigateToTemplate2(this, isDefault);
        }

        internal void NavigateToTemplate3(bool isDefault)
        {
            _navigationService.NavigateToTemplate3(this, isDefault);
        }
    }
}
