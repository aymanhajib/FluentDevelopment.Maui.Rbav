using FluentDevelopment.Rba.Models;
using System.Diagnostics;

namespace FluentDevelopment.Maui.Rbav.Demo
{
    public partial class MainPage : ContentPage
    {
        MauiRbavService RbavService { get; set; }
        public MainPage(MauiRbavService rbavService)
        {
            InitializeComponent();
            RbavService = rbavService;
            roles.ItemsSource = new List<string> { "admin", "user", "guest" };
            perm.ItemsSource = rbavService.GetRolePermissions(rbavService.CurrentRole);
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            RbavService.CurrentRole = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //btn.Text = RbavService.HasPermission("user").ToString();
            var perm = RbavService.GetRolePermissions(RbavService.CurrentRole);
            if (perm != null)
            {
                foreach (var permission in perm)
                {

                    Debug.WriteLine(permission.Name);
                }
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (roles.SelectedItem != null)
            {
                var role = RbavService.GetRole((string)roles.SelectedItem);
                if (role != null)
                {
                    RbavService.CurrentRole = role;
                }
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var per = (RbaPermission)perm.SelectedItem;
            if (per != null)
            {
                RbavService.RemovePermission(per);
                perm.ItemsSource.Remove(perm.SelectedItem);
            }
        }
    }
}
