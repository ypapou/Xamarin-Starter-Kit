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
using System.Globalization;
using Company.App.Presentation.ViewModels.BottomTabBar;
using FlexiMvvm.ValueConverters;

namespace Company.App.Droid.ValueConverters
{
    public class BottomTabBarItemValueConverter : ValueConverter<BottomTabBarItem, int>
    {
        protected override ConversionResult<int> Convert(BottomTabBarItem value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case BottomTabBarItem.Template1:
                    return ConversionResult<int>.SetValue(Resource.Id.template1_item);
                case BottomTabBarItem.Template2:
                    return ConversionResult<int>.SetValue(Resource.Id.template2_item);
                case BottomTabBarItem.Template3:
                    return ConversionResult<int>.SetValue(Resource.Id.template3_item);
                default:
                    return ConversionResult<int>.UnsetValue();
            }
        }

        protected override ConversionResult<BottomTabBarItem> ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Resource.Id.template1_item:
                    return ConversionResult<BottomTabBarItem>.SetValue(BottomTabBarItem.Template1);
                case Resource.Id.template2_item:
                    return ConversionResult<BottomTabBarItem>.SetValue(BottomTabBarItem.Template2);
                case Resource.Id.template3_item:
                    return ConversionResult<BottomTabBarItem>.SetValue(BottomTabBarItem.Template3);
                default:
                    return ConversionResult<BottomTabBarItem>.UnsetValue();
            }
        }
    }
}
