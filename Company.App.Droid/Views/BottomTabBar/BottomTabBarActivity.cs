using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Company.App.Droid.ValueConverters;
using Company.App.Presentation.ViewModels.BottomTabBar;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Fragment = FlexiMvvm.Views.Fragment;

namespace Company.App.Droid.Views.BottomTabBar
{
    [Activity]
    public class BottomTabBarActivity : BindableAppCompatActivity<BottomTabBarViewModel>
    {
        private BottomNavigationView BottomNavigationView { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.bottom_tab_bar);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            BottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);

            SupportFragmentManager.BackStackChangedWeakSubscribe(SupportFragmentManager_BackStackChanged);
        }

        public override void Bind(BindingSet<BottomTabBarViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(BottomNavigationView)
                .For(v => v.SelectedItemIdBinding())
                .To(vm => vm.SelectedItem)
                .WithConversion<BottomTabBarItemValueConverter>();

            bindingSet.Bind(BottomNavigationView)
                .For(v => v.NavigationItemSelectedBinding())
                .To(vm => vm.NavigateToItemCommand)
                .WithConversion<BottomTabBarItemValueConverter>();
        }

        public void SetContent(Fragment fragment, bool isDefault)
        {
            SupportFragmentManager.PopBackStack();
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .AddToBackStackIf(!isDefault, null)
                .Commit();
        }

        private void SupportFragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            if (SupportFragmentManager.BackStackEntryCount == 0)
            {
                ViewModel.SelectDefaultItemCommand.Execute();
            }
        }
    }
}
