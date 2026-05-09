
using Microsoft.Maui.Controls;
using System;
using System.Globalization;


namespace FluentDevelopment.Maui.Rbav.Converters;
/// <summary>
/// Converts a permission string and service into a visibility boolean based on permission checks.
/// </summary>
public class PermissionToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="PermissionToVisibilityConverter"/>.
    /// </summary>
    public static readonly PermissionToVisibilityConverter Instance = new();

    /// <summary>
    /// Converts a permission string and service into a visibility boolean.
    /// </summary>
    /// <param name="value">Unused value parameter.</param>
    /// <param name="targetType">The target type of the binding.</param>
    /// <param name="parameter">A tuple containing the <see cref="MauiRbavService"/> and permission string.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>True if the permission is granted; otherwise, false.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not (MauiRbavService rbavService, string permissionString)) return false;

        var parts = permissionString.Split('.');
        return parts.Length switch
        {
            1 => rbavService.HasPermission(permissionString),
            2 => rbavService.HasPermission(parts[0], parts[1]),
            3 => rbavService.HasPermission(parts[0], parts[1], parts[2]),
            _ => false,
        };
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
