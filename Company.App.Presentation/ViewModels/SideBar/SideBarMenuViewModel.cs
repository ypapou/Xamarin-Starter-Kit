using System.ComponentModel;
using Company.App.Presentation.Navigation;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarMenuViewModel : LifecycleViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISideBarNavigationMediator _sideBarNavigationMediator;

        public SideBarMenuViewModel(INavigationService navigationService, ISideBarNavigationMediator sideBarNavigationMediator)
        {
            _navigationService = navigationService;
            _sideBarNavigationMediator = sideBarNavigationMediator;
        }

        public SideBarMenuItem SelectedItem
        {
            get => State.GetEnum<SideBarMenuItem>();
            private set => State.SetEnum(value);
        }

        public Command<SideBarMenuItem> NavigateToItemCommand => CommandProvider.Get<SideBarMenuItem>(NavigateToItem);

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            _sideBarNavigationMediator.DefaultItem = SideBarMenuItem.Template1;
            _sideBarNavigationMediator.SelectedItem = SelectedItem;
            _sideBarNavigationMediator.PropertyChangedWeakSubscribe(SideBarNavigationMediator_PropertyChanged);

            if (!recreated)
            {
                NavigateToItem(_sideBarNavigationMediator.DefaultItem);
            }
        }

        private void NavigateToItem(SideBarMenuItem item)
        {
            if (item != SelectedItem)
            {
                switch (item)
                {
                    case SideBarMenuItem.Template1:
                        _navigationService.NavigateToTemplate1(this);
                        break;
                    case SideBarMenuItem.Template2:
                        _navigationService.NavigateToTemplate2(this);
                        break;
                    case SideBarMenuItem.Template3:
                        _navigationService.NavigateToTemplate3(this);
                        break;
                    default:
                        /* Do logging */
                        break;
                }
            }
            else
            {
                _sideBarNavigationMediator.CloseMenuInteraction.RaiseRequested();
            }
        }

        private void SideBarNavigationMediator_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SelectedItem = _sideBarNavigationMediator.SelectedItem;
        }
    }
}
