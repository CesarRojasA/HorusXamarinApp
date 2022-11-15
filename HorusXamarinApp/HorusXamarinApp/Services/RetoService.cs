using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorusXamarinApp.Services
{
    public class RetoService : IRetoService
    {
        private readonly IApiService _apiService;
        public RetoService(IApiService apiService) 
        {
            _apiService = apiService;
        }
        public async Task<List<RetoModel>> getAllRetos()
        {
            try
            {
                Response<List<RetoModel>> response = await _apiService.GetAsync<List<RetoModel>>("Challenges");
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
