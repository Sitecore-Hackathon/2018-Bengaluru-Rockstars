using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.WebApi;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using Sitecore.Xdb.Common.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XConnectRocks
{
    public static class XConnectClientHelper
    {
        
        public static XConnectClient GetClient()
        {
            var xConnectClientName = ConfigurationManager.AppSettings[Constants.xConnectCertificate];
            XdbModel[] models = { CollectionModel.Model };
            var config = new XConnectClientConfiguration(
                new XdbRuntimeModel(models),
                new Uri(xConnectClientName),
                new Uri(xConnectClientName));

            try
            {
                config.Initialize();
            }
            catch (XdbModelConflictException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return new XConnectClient(config);
        }


    }
}
