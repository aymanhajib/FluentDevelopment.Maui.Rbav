
using FluentDevelopment.Maui.Rbav.Converters;
using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    /// <summary>
    /// A markup extension that binds visibility to a permission check using the current role from <see cref="MauiRbavService"/>.
    /// </summary>
    [ContentProperty(nameof(Permission))]
    [AcceptEmptyServiceProvider]
    public class PermissionToVisibilityExtension : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the permission name to check for visibility.
        /// </summary>
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// Provides a binding that evaluates visibility based on the specified permission and the current role.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the markup extension.</param>
        /// <returns>A <see cref="Binding"/> for visibility, or <c>false</c> if the service or permission is not available.</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Permission)) return false;

            var binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = PermissionToVisibilityConverter.Instance,
                ConverterParameter = (rbavService, Permission)
            };
            return binding;
        }
    }
}