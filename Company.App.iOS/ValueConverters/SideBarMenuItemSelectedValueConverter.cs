using System;
using System.Globalization;
using Company.App.Presentation.ViewModels.SideBar;
using FlexiMvvm.ValueConverters;

namespace Company.App.Ios.ValueConverters
{
    public class SideBarMenuItemSelectedValueConverter : ValueConverter<SideBarMenuItem, bool>
    {
        protected override ConversionResult<bool> Convert(SideBarMenuItem value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(parameter is SideBarMenuItem currentValue && value == currentValue);
        }
    }
}
