using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XConnectRocks.Email
{
    public class OutlookEmailModel
    {
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }
        public  string EmailBody { get; set; }
        public string Intent { get; set; }
    }
}

