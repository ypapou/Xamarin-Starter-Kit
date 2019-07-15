using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarViewModel : LifecycleViewModel
    {
        private readonly ISideBarNavigationMediator _sideBarNavigationMediator;

        public SideBarViewModel(ISideBarNavigationMediator sideBarNavigationMediator)
        {
            _sideBarNavigationMediator = sideBarNavigationMediator;
        }

        public SideBarMenuItem DefaultItem => _sideBarNavigationMediator.DefaultItem;

        public SideBarMenuItem Selectedtem
        {
            get => _sideBarNavigationMediator.SelectedItem;
            set => _sideBarNavigationMediator.SelectedItem = value;
        }

        public Interaction CloseMenuInteraction => _sideBarNavigationMediator.CloseMenuInteraction;
    }
}
