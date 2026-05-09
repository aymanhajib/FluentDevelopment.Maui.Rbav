

using FluentDevelopment.Maui.Rbav.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;

namespace FluentDevelopment.Maui.Rbav.Utilities;
/// <summary>
/// Provides helper methods for accessing registered services from the application's dependency injection container.
/// </summary>
public static class ServiceHelper
{
    /// <summary>
    /// Gets a service of type <typeparamref name="TService"/> from the application's service provider.
    /// </summary>
    /// <typeparam name="TService">The type of the service to retrieve.</typeparam>
    /// <returns>An instance of <typeparamref name="TService"/> if found; otherwise, <c>null</c>.</returns>
    public static TService? GetService<TService>() where TService : class
    {
        return Current.GetService<TService>();
    }

    /// <summary>
    /// Gets the current application's <see cref="IServiceProvider"/> instance.
    /// </summary>
    public static IServiceProvider Current =>
        Application.Current?.Handler?.MauiContext?.Services ??
        throw new InvalidOperationException("Service provider not available");
}
