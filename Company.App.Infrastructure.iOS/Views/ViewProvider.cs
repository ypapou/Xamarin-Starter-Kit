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

using UIKit;

namespace Company.App.Infrastructure.Views
{
    public static class ViewProvider
    {
        public static UIViewController GetCurrentViewController()
        {
            return GetVisibleViewControllerFrom(UIApplication.SharedApplication.KeyWindow.RootViewController);
        }

        private static UIViewController GetVisibleViewControllerFrom(UIViewController viewController)
        {
            if (viewController is UINavigationController navigationController)
            {
                return GetVisibleViewControllerFrom(navigationController.VisibleViewController);
            }
            else if (viewController is UITabBarController tabBarController)
            {
                return GetVisibleViewControllerFrom(tabBarController.SelectedViewController);
            }
            else if (viewController.PresentedViewController != null)
            {
                return GetVisibleViewControllerFrom(viewController.PresentedViewController);
            }

            return viewController;
        }
    }
}
