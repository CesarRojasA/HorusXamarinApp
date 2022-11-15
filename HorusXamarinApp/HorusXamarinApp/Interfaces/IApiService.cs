using HorusXamarinApp.Models;
using System.Threading.Tasks;

namespace HorusXamarinApp.Interfaces
{
    public interface IApiService
    {
        Task<Response<T>> PostAsync<T>(object model, string service) where T : class;
        Task<Response<T>> GetAsync<T>(string service) where T : class;
    }
}
