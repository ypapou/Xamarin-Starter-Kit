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
                    return ConversionResult<int>.SetValue(Resource.Id.none);
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
                    return ConversionResult<BottomTabBarItem>.SetValue(BottomTabBarItem.None);
            }
        }
    }
}
