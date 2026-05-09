


using FluentDevelopment.Maui.Rbav.Converters;
using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    /// <summary>
    /// A markup extension that provides a binding to control visibility based on a resource and the current role.
    /// </summary>
    [ContentProperty(nameof(Resource))]
    [AcceptEmptyServiceProvider]
    public class ResourceToVisibilityExtension : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the resource name to check for visibility.
        /// </summary>
        public string Resource { get; set; } = string.Empty;

        /// <summary>
        /// Provides a binding that determines visibility based on the specified resource and the current role.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the markup extension.</param>
        /// <returns>A binding object for visibility, or false if the service or resource is not available.</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Resource)) return false;

            var binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = ResourceToVisibilityConverter.Instance,
                ConverterParameter = (rbavService, Resource)
            };
            return binding;
        }
    }
}