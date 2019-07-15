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

using Company.App.Presentation.ViewModels.BottomTabBar;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToHome(ILifecycleViewModel fromViewModel);

        void NavigateToTemplate1(SideBarMenuViewModel fromViewModel);

        void NavigateToTemplate1(BottomTabBarViewModel fromViewModel);

        void NavigateToTemplate2(SideBarMenuViewModel fromViewModel);

        void NavigateToTemplate2(BottomTabBarViewModel fromViewModel);

        void NavigateToTemplate3(SideBarMenuViewModel fromViewModel);

        void NavigateToTemplate3(BottomTabBarViewModel fromViewModel);
    }
}
