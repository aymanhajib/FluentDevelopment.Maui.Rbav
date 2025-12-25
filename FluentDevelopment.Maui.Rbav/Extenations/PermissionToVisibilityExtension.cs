

using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    [ContentProperty(nameof(Permission))]
    [AcceptEmptyServiceProvider]
    public class PermissionToVisibilityExtension : IMarkupExtension
    {
        public string Permission { get; set; } = string.Empty;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Permission)) return false;

            Binding binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = ServiceHelper.PermissionToVisibilityConverter,
                ConverterParameter = (rbavService, Permission)
            };
            return binding;
        }
    }
}