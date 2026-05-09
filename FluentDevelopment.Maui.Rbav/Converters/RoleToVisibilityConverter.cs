
using System.Data;
using Microsoft.Maui.Controls;
using System;
using System.Globalization;
using System.Linq;

namespace FluentDevelopment.Maui.Rbav.Converters;

/// <summary>
/// Converts a role or set of roles to a visibility boolean based on the current user's roles.
/// </summary>
public class RoleToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="RoleToVisibilityConverter"/>.
    /// </summary>
    public static readonly RoleToVisibilityConverter Instance = new();

    /// <summary>
    /// Converts a role or comma-separated list of roles to a boolean indicating visibility.
    /// </summary>
    /// <param name="value">Unused. The value to convert.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">A tuple containing the <see cref="MauiRbavService"/> and a role string.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>True if the user has the specified role(s); otherwise, false.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not (MauiRbavService rbavService, string roleString)) return false;

        var roles = roleString.Split(',');
        if (roles.Length == 0)
            return rbavService.HasRole(roleString);

        return rbavService.HasRole([.. roles.Select(r => r.Trim())]);
    }

    /// <summary>
    /// Not implemented. Converts a value back.
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
