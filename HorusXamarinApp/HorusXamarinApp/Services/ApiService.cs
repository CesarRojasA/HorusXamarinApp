using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HorusXamarinApp.Services
{
    public class ApiService : IApiService
    {

        public async Task<Response<T>> PostAsync<T>(object model, string service) where T : class
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync($"{AppSettings.ApiUrl}/{service}", content);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return new Response<T>
            {
                IsSuccess = response.IsSuccessStatusCode,
                Result = result
            };



        }
        public async Task<Response<T>> GetAsync<T>(string service) where T : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string token = Preferences.Get("TokenLogin", string.Empty);

                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{AppSettings.ApiUrl}/{service}"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add("Authorization", token);

                HttpResponseMessage response = await httpClient.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(responseString);

                return new Response<T> { IsSuccess = response.IsSuccessStatusCode, Result = result };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}