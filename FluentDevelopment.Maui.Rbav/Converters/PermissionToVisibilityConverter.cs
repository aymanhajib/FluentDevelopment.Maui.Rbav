
using Microsoft.Maui.Controls;
using System;
using System.Globalization;


namespace FluentDevelopment.Maui.Rbav.Converters;
public class PermissionToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {

        if (parameter is not (MauiRbavService rbavService, string permissionString)) return false;

        // 2. تحليل النص القادم من الـ XAML
        // المتوقع: "Permission.Resource.Action" (مثلاً: "LayoutMenu.Setting.View")
        var parts = permissionString.Split('.');
        return parts.Length switch
        {
            1 => rbavService.HasPermission(permissionString),
            2 => rbavService.HasPermission(parts[0], parts[1]),
            3 => rbavService.HasPermission(parts[0], parts[1], parts[2]),
            _ => (object)false,
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
