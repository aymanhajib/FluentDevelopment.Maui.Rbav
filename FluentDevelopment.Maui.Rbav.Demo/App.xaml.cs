namespace FluentDevelopment.Maui.Rbav.Demo
{
    public partial class App : Application
    {
        public static MauiRbavService MauiRbavService { get; set; } = new MauiRbavService();
        public App()
        {
            InitializeComponent();

            var rbav = MauiRbavService;

            rbav.AddRoles("admin", "user", "guest");
            rbav.AddResources("main", "page1", "page2", "page3");
            rbav.AddActions("add", "view", "edit");

            var role = rbav.GetRole("admin");
            rbav.AddRolePermission(role,
                "main",
                "view",
                "admin");
            rbav.AddRolePermission(role,
                "page1",
                "view"
                );
            rbav.AddRolePermission(role,
                "page2",
                "view"
                );
            rbav.AddRolePermission(role,
                "page3",
                "view"
                );

            role = rbav.GetRole("user");
            rbav.AddRolePermission(role,
                "main",
                "view"
                );
            rbav.AddRolePermission(role,
                "main",
                "view",
                "user");
            rbav.AddRolePermission(role,
                "page1",
                "view"
                );
            rbav.AddRolePermission(role,
                "page2",
                "view"
                );

            role = rbav.GetRole("guest");
            rbav.AddRolePermission(role,
                "main",
                "view"
                );
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}