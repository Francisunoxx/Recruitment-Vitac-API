using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFlurlService
    {
        Task<TReturn> Send_POST_Async_With_Key<TReturn, TModel>(API api, TModel model);
    }
}
