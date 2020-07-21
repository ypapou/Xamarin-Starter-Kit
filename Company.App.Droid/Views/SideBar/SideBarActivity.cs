using System;
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.SideBar
{
    using Android.Support.V4.App;

    [Activity(Theme = "@style/AppTheme.Translucent")]
    public class SideBarActivity : FlexiAppCompatActivity<SideBarViewModel>
    {
        private const string RootContentBackStackEntryName = "RootContent";

        private DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.side_bar);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var drawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle(this, _drawerLayout, toolbar, Resource.String.SideBar_OpenMenu, Resource.String.SideBar_CloseMenu);
            _drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            SupportFragmentManager.BackStackChangedWeakSubscribe(SupportFragmentManager_BackStackChanged);
            ViewModel.CloseMenuInteraction.RequestedWeakSubscribe(CloseMenuInteraction_Requested);
        }

        public override void OnBackPressed()
        {
            if (!TryCloseDrawer())
            {
                base.OnBackPressed();
            }
        }

        public void SetRootContent(Fragment fragment, SideBarMenuItem item)
        {
            SupportFragmentManager.PopBackStack(RootContentBackStackEntryName, (int)PopBackStackFlags.Inclusive);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_layout, fragment)
                .AddToBackStackIf(item != ViewModel.DefaultItem, RootContentBackStackEntryName)
                .Commit();

            ViewModel.Selectedtem = item;
            TryCloseDrawer();
        }

        public void SetContent(Fragment fragment, bool addToBackStack)
        {
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_layout, fragment)
                .AddToBackStackIf(addToBackStack, null)
                .Commit();
        }

        private bool TryCloseDrawer()
        {
            var wasClosed = false;

            if (_drawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
                _drawerLayout.CloseDrawer(GravityCompat.Start);
                wasClosed = true;
            }

            return wasClosed;
        }

        private void SupportFragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            if (SupportFragmentManager.BackStackEntryCount == 0)
            {
                ViewModel.Selectedtem = ViewModel.DefaultItem;
            }
        }

        private void CloseMenuInteraction_Requested(object sender, EventArgs e)
        {
            TryCloseDrawer();
        }
    }
}
