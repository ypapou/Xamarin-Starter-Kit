using System;
using System.Globalization;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ValueConverters;

namespace Company.App.Droid.ValueConverters
{
    public class SideBarMenuItemValueConverter : ValueConverter<SideBarMenuItem, int>
    {
        protected override ConversionResult<int> Convert(SideBarMenuItem value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case SideBarMenuItem.Template1:
                    return ConversionResult<int>.SetValue(Resource.Id.template1_item);
                case SideBarMenuItem.Template2:
                    return ConversionResult<int>.SetValue(Resource.Id.template2_item);
                case SideBarMenuItem.Template3:
                    return ConversionResult<int>.SetValue(Resource.Id.template3_item);
                default:
                    return ConversionResult<int>.SetValue(Resource.Id.none);
            }
        }

        protected override ConversionResult<SideBarMenuItem> ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Resource.Id.template1_item:
                    return ConversionResult<SideBarMenuItem>.SetValue(SideBarMenuItem.Template1);
                case Resource.Id.template2_item:
                    return ConversionResult<SideBarMenuItem>.SetValue(SideBarMenuItem.Template2);
                case Resource.Id.template3_item:
                    return ConversionResult<SideBarMenuItem>.SetValue(SideBarMenuItem.Template3);
                default:
                    return ConversionResult<SideBarMenuItem>.SetValue(SideBarMenuItem.None);
            }
        }
    }
}
