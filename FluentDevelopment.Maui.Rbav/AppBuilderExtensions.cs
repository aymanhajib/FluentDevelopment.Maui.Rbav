
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace FluentDevelopment.Maui.Rbav
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseMauiFluentDevelopment(this MauiAppBuilder builder, MauiRbavService? rbavService = null)
        {
            if(rbavService != null)
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
