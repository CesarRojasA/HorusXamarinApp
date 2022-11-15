using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Models;
using System;
using System.Threading.Tasks;

namespace HorusXamarinApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IApiService _apiService;
        public LoginService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<LoginResponseModel> postLogin(LoginModel loginModel)
        {
            try
            {
                Response<LoginResponseModel> response = await _apiService.PostAsync<LoginResponseModel>(loginModel, "UserSignIn");
                return response.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
