using System;
using System.Collections.Generic;
using OutLook = Microsoft.Office.Interop.Outlook;
using System.Reflection;
using System.Text.RegularExpressions;

namespace XConnectRocks.Email
{
    public class OutlookEmailClient
    {
        public List<OutlookEmailModel> GetOutlookemails()
        {
            OutLook.Application oOutlookApp;
            OutLook._NameSpace oOutlookNS;
            OutLook.MAPIFolder oOutlookFolder;
            OutLook._Explorer oOutlookExp;
            
            String pattern = @"[\r|\n|\t]";
            oOutlookApp = new OutLook.Application();
            oOutlookNS = (OutLook._NameSpace)oOutlookApp.GetNamespace("MAPI");
            oOutlookFolder = oOutlookNS.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
            oOutlookExp = oOutlookFolder.GetExplorer(false);
            oOutlookNS.Logon(Missing.Value, Missing.Value, false, true);

            OutLook.Items items = oOutlookFolder.Items;
            List<OutlookEmailModel> outlooksModels=new List<OutlookEmailModel>();
            foreach (object item in items)
            {
                try
                {
                    if (item is OutLook.MailItem)
                    {
                        OutLook.MailItem mailitem = (OutLook.MailItem) item;
                        if (mailitem.UnRead == true &&  mailitem.ReceivedTime > DateTime.Parse(DateTime.Now.Date.ToString("MM-dd-yyyy")))
                        {
                            OutlookEmailModel emailoutlookmodel = new OutlookEmailModel
                            {
                               
                                EmailFrom = mailitem.Sender.Address.ToLower().Contains("exchange administrative group") ?mailitem.Sender.GetExchangeUser().PrimarySmtpAddress:mailitem.Sender.Address,
                                EmailSubject = mailitem.Subject,
                                EmailBody = Regex.Replace(mailitem.Body, pattern, string.Empty)
                            };
                            outlooksModels.Add(emailoutlookmodel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return outlooksModels;
        }

    }
}
