using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Xml.XPath;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
[assembly: OwinStartup(typeof(SykesArray_Vitac.Startup))]

namespace SykesArray_Vitac
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();

            // Web API routes
            webApiConfiguration.MapHttpAttributeRoutes();

            // Config content type to JSON
            webApiConfiguration.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            // Config response type to JSON
            webApiConfiguration.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());

            webApiConfiguration.EnableSwagger(x =>
            {
                x.SingleApiVersion("v1", "Recruitment Vitac");
                x.IncludeXmlComments(GetXmlCommentPath());
            }).EnableSwaggerUi(z => z.DisableValidator());

            var corsOptions = new CorsOptions
            {
                //Add CORS Policy
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context =>
                    {
                        //Task.FromResult(new CorsPolicy
                        var policy = new CorsPolicy
                        {
                            AllowAnyHeader = true,
                            AllowAnyMethod = true,
                            AllowAnyOrigin = true,
                            SupportsCredentials = true
                        };
                        //policy.Origins.Add("http://phmnl5dev025:32212/");
                        policy.Origins.Add("http://localhost:8080");

                        return Task.FromResult(policy);
                    }
                }
            };

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");

            webApiConfiguration.EnableCors(cors);

            // Inject Ninject into Owin Pipeline
            // Inject Web API Config into Ninject
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(webApiConfiguration)
                .UseCors(corsOptions);
        }

        private string GetXmlCommentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"bin\SykesArray_Vitac.xml";
        }

        public static StandardKernel CreateKernel()
        {
            return new StandardKernel(new NinjectBindings());
        }
    }
}
