
using System.Data;
using Microsoft.Maui.Controls;
using System;
using System.Globalization;
using System.Linq;

namespace FluentDevelopment.Maui.Rbav.Converters;

public class RoleToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {

        if (parameter is not (MauiRbavService rbavService, string roleString)) return false;

        var roles = roleString.Split(',');
        if(roles.Length == 0)
            return rbavService.HasRole(roleString);

        return rbavService.HasRole([.. roles.Select(r => r.Trim())]);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
