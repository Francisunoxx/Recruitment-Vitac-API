using Flurl;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flurl;
using Flurl.Http;
using ViewModel;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using Flurl.Http.Configuration;

namespace SykesArray_Vitac.Controllers
{
    [RoutePrefix("api/v1/account")]
    public class AccountController : ApiController
    {
        private readonly IFlurlService ifs;
        public AccountController(IFlurlService ifs)
        {
            this.ifs = ifs;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody] Login login)
        {
            var result = await this.ifs.Send_POST_Async_With_Key<Authenticate, Credential>(login.api, login.credential);

            return Ok(result);
        }
    }
}
