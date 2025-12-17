

using FluentDevelopment.Maui.Rbav.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;

namespace FluentDevelopment.Maui.Rbav.Utilities;
public static class ServiceHelper
{
    public static ResourceToVisibilityConverter ResourceToVisibilityConverter { get; private set; } = new ResourceToVisibilityConverter();
    public static PermissionToVisibilityConverter PermissionToVisibilityConverter { get; private set; } = new PermissionToVisibilityConverter();
    public static RoleToVisibilityConverter RoleToVisibilityConverter { get; private set; } = new RoleToVisibilityConverter();
    public static TService? GetService<TService>() where TService : class
    {
        return Current.GetService<TService>();
    }

    public static IServiceProvider Current =>
        Application.Current?.Handler?.MauiContext?.Services ??
        throw new InvalidOperationException("Service provider not available");
}
