using System.Collections.Generic;
using Sitecore;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;
using System.Web.Http;
using System.Linq;
using Sitecore.Data;
using Sitecore.Resources.Media;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Net;
using System.Web.Helpers;
using Newtonsoft.Json;
using System;
using Hackathon.Feature.ServiceAPI.Models;
using Hackathon.Feature.ServiceAPI.Repository;

namespace Hackathon.Feature.ServiceAPI.Controllers
{
    [ServicesController]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "GET,POST")]
    public class ServiceController : ServicesApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            HttpRequestMessage re = new HttpRequestMessage();
            var headers = re.Headers;

            EmailIntents list = new EmailIntents();

            IServiceRepository repo = new ServiceRepository();
            var result = repo.TriggerGoals(list);

            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }

            return Content(HttpStatusCode.NotFound, result);
        }
    }
}
