using Acr.UserDialogs;
using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Models;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HorusXamarinApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region [Private attributes]
        private readonly ILoginService _loginService;
        private LoginModel loginModel;
        private bool eyeIsVisible;
        private bool eyeNoneIsVisible;
        private bool isPassword;
        private bool isEnableScreen;
        private bool isVisibleActivity;
        private bool isRunningActivity;
        private double opacityScreen;
        #endregion 
        #region [Public attributes]
        public LoginModel LoginModel
        {
            set { SetProperty(ref loginModel, value); }
            get { return loginModel; }
        }
        public bool EyeIsVisible
        {
            set { SetProperty(ref eyeIsVisible, value); }
            get { return eyeIsVisible; }
        }
        public bool EyeNoneIsVisible
        {
            set { SetProperty(ref eyeNoneIsVisible, value); }
            get { return eyeNoneIsVisible; }
        }
        public bool IsPassword
        {
            set { SetProperty(ref isPassword, value); }
            get { return isPassword; }
        }
        public bool IsEnableScreen
        {
            set { SetProperty(ref isEnableScreen, value); }
            get { return isEnableScreen; }
        }
        public bool IsVisibleActivity
        {
            set { SetProperty(ref isVisibleActivity, value); }
            get { return isVisibleActivity; }
        }
        public bool IsRunningActivity
        {
            set { SetProperty(ref isRunningActivity, value); }
            get { return isRunningActivity; }
        }
        public double OpacityScreen
        {
            set { SetProperty(ref opacityScreen, value); }
            get { return opacityScreen; }
        }

        public ICommand LoginCommand { set; get; }
        public ICommand EyeCommand { set; get; }
        #endregion

        #region [Constructor]
        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService) :
            base(navigationService)
        {
            _loginService = loginService;
            LoginCommand = new Command(async () => await Login());
            EyeCommand = new Command(() => ShowContraseña());
        }
        #endregion
        #region [Methods]
        public override void Initialize(INavigationParameters parameters)
        {
            try
            {
                LoginModel = new LoginModel();

                EyeIsVisible = true;
                IsPassword = true;
                EyeNoneIsVisible = false;
                IsEnableScreen = true;
                IsVisibleActivity = false;
                IsRunningActivity = false;
                OpacityScreen = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private async Task Login()
        {
            try
            {
                ActivarActivityIndicator();
                if (LoginModel.Password == string.Empty || LoginModel.Email == string.Empty)
                    await UserDialogs.Instance.AlertAsync("Por favor ingrese una email y un válido", "Email y contraseña errónea");
                else
                {
                    LoginResponseModel LoginResponse = await _loginService.postLogin(LoginModel);
                    if (LoginResponse == null)
                        await UserDialogs.Instance.AlertAsync("Intete nuevamente", "Error");
                    else
                    {
                        LlenarPreferences(LoginResponse);
                        _ = await NavigationService.NavigateAsync("GamificationPage");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LlenarPreferences(LoginResponseModel loginResponse)
        {
            try
            {
                Preferences.Set("TokenLogin", loginResponse.AuthorizationToken);
                Preferences.Set("EmailLogin", loginResponse.Email);
                Preferences.Set("FirstnameLogin", loginResponse.Firstname);
                Preferences.Set("SurnameLogin", loginResponse.Surname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ActivarActivityIndicator()
        {
            try
            {
                IsEnableScreen = false;
                IsVisibleActivity = true;
                IsRunningActivity = true;
                OpacityScreen = 0.8;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowContraseña()
        {
            try
            {
                if (EyeIsVisible)
                {
                    EyeIsVisible = false;
                    EyeNoneIsVisible = true;
                    IsPassword = false;
                }
                else
                {
                    EyeIsVisible = true;
                    EyeNoneIsVisible = false;
                    IsPassword = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
