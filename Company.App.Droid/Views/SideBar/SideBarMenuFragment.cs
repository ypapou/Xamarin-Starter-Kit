using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Company.App.Droid.ValueConverters;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.SideBar
{
    public class SideBarMenuFragment : BindableFragment<SideBarMenuViewModel>
    {
        private NavigationView NavigationView { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.side_bar_menu, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            NavigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
        }

        public override void Bind(BindingSet<SideBarMenuViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(NavigationView)
                .For(v => v.SetCheckedItemBinding())
                .To(vm => vm.SelectedItem)
                .WithConversion<SideBarMenuItemValueConverter>();

            bindingSet.Bind(NavigationView)
                .For(v => v.NavigationItemSelectedBinding())
                .To(vm => vm.NavigateToItemCommand)
                .WithConversion<SideBarMenuItemValueConverter>();
        }
    }
}
