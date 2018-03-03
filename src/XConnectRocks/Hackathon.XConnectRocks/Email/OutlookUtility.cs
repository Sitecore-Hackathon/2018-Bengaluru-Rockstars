
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace XConnectRocks.Email
{
    public static class OutlookUtility
    {
        public static string ReadEmailsFromInbox()
        {
            OutlookEmailClient objectoutlookclient = new OutlookEmailClient();
            List<OutlookEmailModel> emaiList = objectoutlookclient.GetOutlookemails();
            var json = new JavaScriptSerializer().Serialize(emaiList);
            // Console.Write((json));
            //Console.Read();
            return json;
        }
    }
}
