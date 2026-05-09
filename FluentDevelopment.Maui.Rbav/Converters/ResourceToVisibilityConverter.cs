
using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace FluentDevelopment.Maui.Rbav.Converters;
/// <summary>
/// Converts a resource access check to a visibility boolean for UI binding.
/// </summary>
public class ResourceToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="ResourceToVisibilityConverter"/>.
    /// </summary>
    public static readonly ResourceToVisibilityConverter Instance = new();

    /// <summary>
    /// Converts a resource access check to a boolean value indicating visibility.
    /// </summary>
    /// <param name="value">The value passed from the binding source (typically the user).</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">A tuple containing the <see cref="MauiRbavService"/> and the resource name.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>True if the resource is available; otherwise, false.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not (MauiRbavService rbavService, string resourceName)) return false;
        // 3. التحقق الفعلي
        // نمرر الـ value (المستخدم) للتأكد من تحديث الـ Binding عند تغيير المستخدم
        return rbavService.HasResource(resourceName);
    }

    /// <summary>
    /// Not implemented. Converts a value back to its source type.
    /// </summary>
    /// <param name="value">The value produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>Throws <see cref="NotImplementedException"/>.</returns>
    /// <exception cref="NotImplementedException">Always thrown.</exception>
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

