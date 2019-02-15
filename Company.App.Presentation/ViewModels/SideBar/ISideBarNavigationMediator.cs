namespace Company.App.Presentation.ViewModels.SideBar
{
    public interface ISideBarNavigationMediator
    {
        void SetSideBarViewModel(SideBarViewModel viewModel);

        void SetSideBarMenuViewModel(SideBarMenuViewModel viewModel);

        void NavigateToTemplate1(bool isDefault);

        void NavigateToTemplate2(bool isDefault);

        void NavigateToTemplate3(bool isDefault);

        void CloseMenu();

        void SelectDefaultMenuItem();
    }
}
