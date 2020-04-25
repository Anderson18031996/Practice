using Practice.Commom.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Commom.Services
{
   public interface IApiService
    {
        Task<Response> GetListAsync<T>(string url, string service, string controller, Form user);
    }
}
