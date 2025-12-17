

using FluentDevelopment.Maui.Rbav.Utilities;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace FluentDevelopment.Maui.Rbav.Extenations
{
    [ContentProperty(nameof(Role))]
    public class RoleToVisibilityExtension : IMarkupExtension
    {
        public string Role { get; set; } = string.Empty;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var rbavService = ServiceHelper.GetService<MauiRbavService>();

            if (rbavService == null || string.IsNullOrEmpty(Role)) return false;

            Binding binding = new Binding
            {
                Source = rbavService,
                Path = nameof(rbavService.CurrentRole),
                Mode = BindingMode.OneWay,
                Converter = ServiceHelper.RoleToVisibilityConverter,
                ConverterParameter = (rbavService, Role)
            };
            return binding;
        }
    }
}
