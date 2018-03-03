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
using Hackathon.Feature.XConnectUtility.Models;
using Hackathon.Feature.XConnectUtility.Repository;

namespace Hackathon.Feature.XConnectUtility.Controllers
{
    [ServicesController]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "GET,POST")]
    public class ServiceController : ServicesApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = false;
            if (Request.Headers.Contains("UserData"))
            {
                IEnumerable<string> headerValues = Request.Headers.GetValues("UserData");
                var jsonData = headerValues.FirstOrDefault();

                EmailIntent list = JsonConvert.DeserializeObject<EmailIntent>(jsonData);

                IServiceRepository repo = new ServiceRepository();
                result = repo.TriggerGoals(list);

                if (result)
                {
                    return Content(HttpStatusCode.OK, result);
                }
            }
            return Content(HttpStatusCode.BadRequest, result);
        }
    }
}
