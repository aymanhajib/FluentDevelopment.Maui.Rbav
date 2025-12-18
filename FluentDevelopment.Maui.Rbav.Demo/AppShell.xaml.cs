using FluentDevelopment.Maui.Rbav.Utilities;

namespace FluentDevelopment.Maui.Rbav.Demo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            var rbav = ServiceHelper.GetService<MauiRbavService>();

            rbav.PropertyChanged += async (s, e) =>
            {
                if (e.PropertyName == nameof(MauiRbavService.CurrentRole))
                {
                    var role = rbav.CurrentRole;
                    if (role != null)
                    {
                        await GoToAsync("//main");
                    }
                    else
                    {
                        await GoToAsync("//login");
                    }
                }
            };
        }
    }
}
