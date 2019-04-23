using System;
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Fragment = FlexiMvvm.Views.Fragment;

namespace Company.App.Droid.Views.SideBar
{
    [Activity]
    public class SideBarActivity : AppCompatActivity<SideBarViewModel>
    {
        private DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.side_bar);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, toolbar, Resource.String.SideBar_OpenMenu, Resource.String.SideBar_CloseMenu);
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

        public void SetContent(Fragment fragment, bool isDefault)
        {
            SupportFragmentManager.PopBackStack();
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .AddToBackStackIf(!isDefault, null)
                .Commit();

            TryCloseDrawer();
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
                ViewModel.SelectDefaultMenuItemCommand.Execute();
            }
        }

        private void CloseMenuInteraction_Requested(object sender, EventArgs e)
        {
            TryCloseDrawer();
        }
    }
}
