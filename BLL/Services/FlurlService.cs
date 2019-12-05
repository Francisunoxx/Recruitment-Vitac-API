using BLL.Interfaces;
using Flurl.Http;
using Flurl.Http.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Services
{
    public class FlurlService : IFlurlService
    {
        public async Task<TReturn> Send_POST_Async_With_Key<TReturn, TModel>(API api, TModel model)
        {
            var url = api.BaseURL + api.Segment;
            /*try
            {
                return await url.WithHeader("Key", api.Key).PostJsonAsync(model).ReceiveJson<TReturn>();
            }
            catch (Exception ex)
            {
                return new Transaction { IsSuccessful = false };
            }*/

            return await url.WithHeader("Key", api.Key).PostJsonAsync(model).ReceiveJson<TReturn>();
        }
    }
}
