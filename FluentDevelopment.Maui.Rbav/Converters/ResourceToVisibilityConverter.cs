
using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace FluentDevelopment.Maui.Rbav.Converters;
public class ResourceToVisibilityConverter: IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not (MauiRbavService rbavService, string resourceName)) return false;
        // 3. التحقق الفعلي
        // نمرر الـ value (المستخدم) للتأكد من تحديث الـ Binding عند تغيير المستخدم
        return rbavService.HasResource(resourceName);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

