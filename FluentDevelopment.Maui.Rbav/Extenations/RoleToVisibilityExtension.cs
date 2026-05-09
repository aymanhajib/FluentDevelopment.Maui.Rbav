
using FluentDevelopment.Maui.Rbav.Converters;
using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    /// <summary>
    /// A markup extension that binds the visibility of a control to the current role using the specified role name.
    /// </summary>
    [ContentProperty(nameof(Role))]
    [AcceptEmptyServiceProvider]
    public class RoleToVisibilityExtension : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the role name to check for visibility.
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Provides a binding that determines visibility based on the current role.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A binding object for visibility, or false if the service or role is not available.</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Role)) return false;

            var binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = RoleToVisibilityConverter.Instance,
                ConverterParameter = (rbavService, Role)
            };
            return binding;
        }
    }
}
