using System;
using Company.App.Ios.ValueConverters;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views.SideBar
{
    public class SideBarMenuViewController : BindableViewController<SideBarMenuViewModel>
    {
        [Weak]
        private readonly SideBarViewController _sideBarViewController;

        public SideBarMenuViewController(SideBarViewController sideBarViewController)
        {
            _sideBarViewController = sideBarViewController;
        }

        private new SideBarMenuView View
        {
            get => (SideBarMenuView)base.View;
            set => base.View = value;
        }

        public SideBarViewController SideBarViewController => _sideBarViewController;

        public override void LoadView()
        {
            base.LoadView();

            View = new SideBarMenuView();
        }

        public override void Bind(BindingSet<SideBarMenuViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.Template1Button)
                .For(v => v.SelectedBinding())
                .To(vm => vm.SelectedItem)
                .WithConversion<SideBarMenuItemSelectedValueConverter>(SideBarMenuItem.Template1);

            bindingSet.BindDefault(View.Template1Button)
                .To(vm => vm.NavigateToItemCommand)
                .WithCommandParameter(SideBarMenuItem.Template1);

            bindingSet.Bind(View.Template2Button)
                .For(v => v.SelectedBinding())
                .To(vm => vm.SelectedItem)
                .WithConversion<SideBarMenuItemSelectedValueConverter>(SideBarMenuItem.Template2);

            bindingSet.BindDefault(View.Template2Button)
                .To(vm => vm.NavigateToItemCommand)
                .WithCommandParameter(SideBarMenuItem.Template2);

            bindingSet.Bind(View.Template3Button)
                .For(v => v.SelectedBinding())
                .To(vm => vm.SelectedItem)
                .WithConversion<SideBarMenuItemSelectedValueConverter>(SideBarMenuItem.Template3);

            bindingSet.BindDefault(View.Template3Button)
                .To(vm => vm.NavigateToItemCommand)
                .WithCommandParameter(SideBarMenuItem.Template3);
        }
    }
}
