using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.ServiceAPI.Models
{
    public class EmailIntent
    {
        public string EmailId { get; set; }
        public string EmailSubject { get; set; }
        public string Intent { get; set; }
    }
}