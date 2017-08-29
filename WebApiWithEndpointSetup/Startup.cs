using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Logging;
using Newtonsoft.Json.Serialization;
using Owin;
using WebApiWithEndpointSetup.Configuration;

namespace WebApiWithEndpointSetup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                var httpConfiguration = new HttpConfiguration();

                httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                httpConfiguration.Formatters.XmlFormatter.UseXmlSerializer = true;

                httpConfiguration.ConfigureApiDocumentation();

                httpConfiguration.MapHttpAttributeRoutes();

                app.UseWebApi(httpConfiguration);
            }
            catch (Exception ex)
            {
                app.CreateLogger<Startup>()
                    .WriteCritical("Oops somebody forgot to test something...", ex);
                throw;
            }
        }
    }
}