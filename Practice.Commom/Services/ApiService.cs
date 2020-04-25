using Newtonsoft.Json;
using Practice.Commom.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Commom.Services
{
  public  class ApiService : IApiService
    {
        public async Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller, Form user)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
               
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                var url = $"{servicePrefix}/{controller}";
                var response = await client.PostAsync(url,content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        token = "",
                        expiration = "",
                        problem = result
                    };
                }

                //var list = JsonConvert.DeserializeObject<List<string>>(result);
                Response list = JsonConvert.DeserializeObject<Response>(result);

                return new Response
                {
                    token = "",
                    expiration = "",
                    problem = ""
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    token = "",
                    expiration = "",
                    problem = ""
                };

            }
        }
    }
}
