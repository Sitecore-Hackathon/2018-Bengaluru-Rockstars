using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Hackathon.Feature.ServiceAPI.Processor
{
    public class RegisterRoute
    {
        public void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configure(Configure);

        }
        protected void Configure(HttpConfiguration configuration)
        {
            var routes = configuration.Routes;
            routes.MapHttpRoute("hackathon", "hackathon/webapi/{controller}/{action}", new
            {
                controller = "Service",
                action = "Get"
            }
            );


            configuration.EnableCors();
        }
    }
}