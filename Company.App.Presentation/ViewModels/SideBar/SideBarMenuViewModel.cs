using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarMenuViewModel : LifecycleViewModel
    {
        private const SideBarMenuItem DefaultItem = SideBarMenuItem.Template1;

        private readonly ISideBarNavigationMediator _sideBarNavigationMediator;

        public SideBarMenuViewModel(ISideBarNavigationMediator sideBarNavigationMediator)
        {
            _sideBarNavigationMediator = sideBarNavigationMediator;

            _sideBarNavigationMediator.SetSideBarMenuViewModel(this);
        }

        public SideBarMenuItem SelectedItem
        {
            get => State.GetEnum(defaultValue: SideBarMenuItem.None);
            private set => State.SetEnum(value);
        }

        public Command<SideBarMenuItem> NavigateToItemCommand => CommandProvider.Get<SideBarMenuItem>(NavigateToItem);

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            if (!recreated)
            {
                NavigateToItem(DefaultItem);
            }
        }

        private void NavigateToItem(SideBarMenuItem item)
        {
            if (item != SelectedItem)
            {
                var isDefaultItem = item == DefaultItem;

                switch (item)
                {
                    case SideBarMenuItem.Template1:
                        _sideBarNavigationMediator.NavigateToTemplate1(isDefaultItem);
                        SelectedItem = item;
                        break;
                    case SideBarMenuItem.Template2:
                        _sideBarNavigationMediator.NavigateToTemplate2(isDefaultItem);
                        SelectedItem = item;
                        break;
                    case SideBarMenuItem.Template3:
                        _sideBarNavigationMediator.NavigateToTemplate3(isDefaultItem);
                        SelectedItem = item;
                        break;
                    default:
                        /* DiagnosticLogger.NonCriticalIssue($"'{item}' side bar menu item is not handled."); */
                        break;
                }
            }
            else
            {
                _sideBarNavigationMediator.CloseMenu();
            }
        }

        internal void SelectDefaultItem()
        {
            SelectedItem = DefaultItem;
        }
    }
}
