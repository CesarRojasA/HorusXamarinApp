using HorusXamarinApp.Models;
using System.Threading.Tasks;

namespace HorusXamarinApp.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> postLogin(LoginModel loginModel);
    }
}
