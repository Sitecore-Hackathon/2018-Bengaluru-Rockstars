using System.Collections.Generic;
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
            return json;
        }
    }
}
