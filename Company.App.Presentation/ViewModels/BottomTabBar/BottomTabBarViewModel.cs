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

using Company.App.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.BottomTabBar
{
    public class BottomTabBarViewModel : LifecycleViewModel
    {
        private readonly INavigationService _navigationService;

        public BottomTabBarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public BottomTabBarItem DefaultItem { get; private set; }

        public BottomTabBarItem SelectedItem
        {
            get => State.GetEnum<BottomTabBarItem>();
            set => State.SetEnum(value);
        }

        public Command<BottomTabBarItem> NavigateToItemCommand => CommandProvider.Get<BottomTabBarItem>(NavigateToItem, CanNavigateToItem);

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            DefaultItem = BottomTabBarItem.Template1;

            if (!recreated)
            {
                NavigateToItem(DefaultItem);
            }
        }

        private void NavigateToItem(BottomTabBarItem item)
        {
            switch (item)
            {
                case BottomTabBarItem.Template1:
                    _navigationService.NavigateToTemplate1(this);
                    break;
                case BottomTabBarItem.Template2:
                    _navigationService.NavigateToTemplate2(this);
                    break;
                case BottomTabBarItem.Template3:
                    _navigationService.NavigateToTemplate3(this);
                    break;
                default:
                    /* Do logging */
                    break;
            }
        }

        private bool CanNavigateToItem(BottomTabBarItem item)
        {
            return item != SelectedItem;
        }
    }
}
