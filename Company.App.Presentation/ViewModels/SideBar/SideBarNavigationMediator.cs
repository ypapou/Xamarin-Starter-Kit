using System;
using FlexiMvvm;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarNavigationMediator : ISideBarNavigationMediator
    {
        private WeakReference<SideBarViewModel> _sideBarViewModelWeakReference;
        private WeakReference<SideBarMenuViewModel> _sideBarMenuViewModelWeakReference;

        public void SetSideBarViewModel(SideBarViewModel viewModel)
        {
            _sideBarViewModelWeakReference = new WeakReference<SideBarViewModel>(viewModel);
        }

        public void SetSideBarMenuViewModel(SideBarMenuViewModel viewModel)
        {
            _sideBarMenuViewModelWeakReference = new WeakReference<SideBarMenuViewModel>(viewModel);
        }

        public void NavigateToTemplate1(bool isDefault)
        {
            _sideBarViewModelWeakReference?.GetTarget()?.NavigateToTemplate1(isDefault);
        }

        public void NavigateToTemplate2(bool isDefault)
        {
            _sideBarViewModelWeakReference?.GetTarget()?.NavigateToTemplate2(isDefault);
        }

        public void NavigateToTemplate3(bool isDefault)
        {
            _sideBarViewModelWeakReference?.GetTarget()?.NavigateToTemplate3(isDefault);
        }

        public void CloseMenu()
        {
            _sideBarViewModelWeakReference?.GetTarget()?.CloseMenuInteraction.RaiseRequested();
        }

        public void SelectDefaultMenuItem()
        {
            _sideBarMenuViewModelWeakReference?.GetTarget()?.SelectDefaultItem();
        }
    }
}
