// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Company.App.Droid.ValueConverters;
using Company.App.Presentation.ViewModels.BottomTabBar;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.BottomTabBar
{
    using Android.Support.V4.App;

    [Activity]
    public class BottomTabBarActivity : FlexiBindableAppCompatActivity<BottomTabBarViewModel>
    {
        private const string RootContentBackStackEntryName = "RootContent";

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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var currentFragment = SupportFragmentManager.FindFragmentById(Resource.Id.content_layout);

            return (currentFragment != null && currentFragment.OnOptionsItemSelected(item)) || base.OnOptionsItemSelected(item);
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

        public void SetRootContent(Fragment fragment, BottomTabBarItem item)
        {
            SupportFragmentManager.PopBackStack(RootContentBackStackEntryName, (int)PopBackStackFlags.Inclusive);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_layout, fragment)
                .AddToBackStackIf(item != ViewModel.DefaultItem, RootContentBackStackEntryName)
                .Commit();

            ViewModel.SelectedItem = item;
        }

        public void SetContent(Fragment fragment, bool addToBackStack)
        {
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_layout, fragment)
                .AddToBackStackIf(addToBackStack, null)
                .Commit();
        }

        private void SupportFragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            if (SupportFragmentManager.BackStackEntryCount == 0)
            {
                ViewModel.SelectedItem = ViewModel.DefaultItem;
            }
        }
    }
}
