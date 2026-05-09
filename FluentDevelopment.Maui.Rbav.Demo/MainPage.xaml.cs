using FluentDevelopment.Rba;
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
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pPerm.ItemsSource = RbavService.GetRolePermissions(RbavService.CurrentRole);
        }

        private void OnLogoutClicked(object? sender, EventArgs e)
        {
            RbavService.CurrentRole = null;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var per = (RbaPermission)pPerm.SelectedItem;
            if (per != null)
            {
                RbavService.RemovePermission(per);
                pPerm.ItemsSource.Remove(pPerm.SelectedItem);
            }
        }
    }
}
