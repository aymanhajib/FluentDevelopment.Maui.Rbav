
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace FluentDevelopment.Maui.Rbav
{
    /// <summary>
    /// Provides extension methods for configuring FluentDevelopment RBAV services in a MAUI application.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Registers the <see cref="MauiRbavService"/> as a singleton in the application's service collection.
        /// </summary>
        /// <param name="builder">The <see cref="MauiAppBuilder"/> to configure.</param>
        /// <param name="rbavService">
        /// An optional <see cref="MauiRbavService"/> instance to use. If not provided, a new instance will be registered.
        /// </param>
        /// <returns>The <see cref="MauiAppBuilder"/> for chaining.</returns>
        public static MauiAppBuilder UseMauiFluentDevelopmentRbav(this MauiAppBuilder builder, MauiRbavService? rbavService = null)
        {
            if (rbavService != null)
            {
                builder.Services.AddSingleton<MauiRbavService>(rbavService);
            }
            else
            {
                builder.Services.AddSingleton<MauiRbavService>();
            }
            return builder;
        }
    }
}
