using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SykesArray_Vitac
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDapperRepository>().To<DapperRepository>();
            this.Bind<IQuestionRepository>().To<QuestionRepository>();
            this.Bind<IQuestionService>().To<QuestionService>();
            this.Bind<IFlurlService>().To<FlurlService>();
        }
    }
}