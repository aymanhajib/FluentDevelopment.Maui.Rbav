namespace FluentDevelopment.Maui.Rbav.Demo;

public partial class Login : ContentPage
{
    MauiRbavService _rbavService { get; set; }
    public Login(MauiRbavService rbavService)
    {
        InitializeComponent();
        _rbavService = rbavService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (picker.SelectedItem != null)
        {
            var rolename = (string)picker.SelectedItem;
            if (rolename != null)
            {
                var role = _rbavService.GetRole(rolename);
                if (role != null)
                {
                    _rbavService.CurrentRole = role;
                }
            }
        }
    }
}