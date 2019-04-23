using Company.App.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.BottomTabBar
{
    public class BottomTabBarViewModel : LifecycleViewModel
    {
        private const BottomTabBarItem DefaultItem = BottomTabBarItem.Template1;

        private readonly INavigationService _navigationService;

        public BottomTabBarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public BottomTabBarItem SelectedItem
        {
            get => State.GetEnum(defaultValue: BottomTabBarItem.None);
            private set => State.SetEnum(value);
        }

        public Command<BottomTabBarItem> NavigateToItemCommand => CommandProvider.Get<BottomTabBarItem>(NavigateToItem, CanNavigateToItem);

        public Command SelectDefaultItemCommand => CommandProvider.Get(SelectDefaultItem);

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            if (!recreated)
            {
                NavigateToItem(DefaultItem);
            }
        }

        private void NavigateToItem(BottomTabBarItem item)
        {
            var isDefaultItem = item == DefaultItem;

            switch (item)
            {
                case BottomTabBarItem.Template1:
                    _navigationService.NavigateToTemplate1(this, isDefaultItem);
                    SelectedItem = item;
                    break;
                case BottomTabBarItem.Template2:
                    _navigationService.NavigateToTemplate2(this, isDefaultItem);
                    SelectedItem = item;
                    break;
                case BottomTabBarItem.Template3:
                    _navigationService.NavigateToTemplate3(this, isDefaultItem);
                    SelectedItem = item;
                    break;
                default:
                    /* DiagnosticLogger.NonCriticalIssue($"'{item}' side bar menu item is not handled."); */
                    break;
            }
        }

        private bool CanNavigateToItem(BottomTabBarItem item)
        {
            return item != SelectedItem && item != BottomTabBarItem.None;
        }

        private void SelectDefaultItem()
        {
            SelectedItem = DefaultItem;
        }
    }
}
