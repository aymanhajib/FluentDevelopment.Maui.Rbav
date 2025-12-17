


using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    [ContentProperty(nameof(Resource))]
    public class ResourceToVisibilityExtension : IMarkupExtension
    {
        public string Resource { get; set; } = string.Empty;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Resource)) return false;

            Binding binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = ServiceHelper.ResourceToVisibilityConverter,
                ConverterParameter = (rbavService, Resource)
            };
            return binding;
        }
    }
}