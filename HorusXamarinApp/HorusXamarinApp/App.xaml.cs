using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Services;
using HorusXamarinApp.ViewModels;
using HorusXamarinApp.Views;
using HorusXamarinApp.Views.Gamification;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace HorusXamarinApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<GamificationPage, GamificationPageViewModel>();
            containerRegistry.Register<IRetoService, RetoService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<ILoginService, LoginService>();

        }
    }
}
