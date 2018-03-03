using Newtonsoft.Json;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Operations;
using Sitecore.XConnect.Schema;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using XConnectRocks.Email;
using XConnectRocks.Services;

namespace XConnectRocks
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var client = GetClient())
            {
                 GetValidContactsFromXdb(client);
            }

            //MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            //var listOfEmails = OutlookUtility.ReadEmailsFromInbox();
            //var emailList = JsonConvert.DeserializeObject<List<OutlookEmailModel>>(listOfEmails);
            //if (emailList == null)
            //    return;

            //foreach (var email in emailList)
            //{
            //    bool isvalidUser = SearchContacts(email.EmailFrom);
            //    if (isvalidUser)
            //    {
            //        string LUISAppUrl = ConfigurationManager.AppSettings["CognitiveService.OleChat.LUISAppUrl"];
            //        string OleAppIdField = ConfigurationManager.AppSettings["CognitiveService.OleChat.OleAppId"];
            //        string OleAppkey = ConfigurationManager.AppSettings["CognitiveService.OleChat.OleAppkey"];
            //        HttpServiceHelper obj = new HttpServiceHelper();
            //        var query = String.Concat(LUISAppUrl, OleAppIdField, "", OleAppkey,
            //            "&verbose=true&timezoneOffset=0&q= looking ] for Product details please share the information .");
            //        var data = obj.GetServiceResponse<LuisResult>(query, false);
            //        if (data != null)
            //        {
            //            var requestedQuit =
            //                data.TopScoringIntent.Intent.ToLower().Equals("quit") &&
            //                data.TopScoringIntent.Score > 0.4;
            //        }
            //    }
            //}
        }



        private static async Task MainAsync(string[] args)
        {
            //// Valid certificate thumbprints must be passed in
            ////// Valid certificate thumbprints must be passed in
            //CertificateWebRequestHandlerModifierOptions options =
            //    CertificateWebRequestHandlerModifierOptions.Parse(ConfigurationManager.AppSettings[Constants.xConnectCertificate]);
            //var xConnectClientName = ConfigurationManager.AppSettings[Constants.xConnectClient];

            //// Optional timeout modifier
            //var certificateModifier = new CertificateWebRequestHandlerModifier(options);

            //List<IHttpClientModifier> clientModifiers = new List<IHttpClientModifier>();
            //var timeoutClientModifier = new TimeoutHttpClientModifier(new TimeSpan(0, 0, 20));
            //clientModifiers.Add(timeoutClientModifier);

            ////// This overload takes three client end points - collection, search, and configuration
            //var collectionClient = new CollectionWebApiClient(new Uri(string.Concat(xConnectClientName, "odata")), clientModifiers, new[] { certificateModifier });
            //var searchClient = new SearchWebApiClient(new Uri(string.Concat(xConnectClientName, "odata")), clientModifiers, new[] { certificateModifier });
            //var configurationClient = new ConfigurationWebApiClient(new Uri(string.Concat(xConnectClientName, "configuration")), clientModifiers, new[] { certificateModifier });

            //var cfg = new XConnectClientConfiguration(
            //    new XdbRuntimeModel(CollectionModel.Model), collectionClient, "", configurationClient);

            //try
            //{
            //    await cfg.InitializeAsync();

            //}
            //catch (XdbModelConflictException ce)
            //{
            //    Console.WriteLine("ERROR:" + ce.Message);
            //    return;
            //}

            //using (var client = new XConnectClient(cfg))
            //{
            //    GetValidContactsFromXdb(client);
            //}
        }

        private static void GetValidContactsFromXdb(XConnectClient client)
        {
            HttpServiceHelper obj = new HttpServiceHelper();
            var listOfEmails = OutlookUtility.ReadEmailsFromInbox();
            var emailList = JsonConvert.DeserializeObject<List<OutlookEmailModel>>(listOfEmails);
            if (emailList == null)
                return;

            bool isvalidUser = false;
            foreach (var outlookEmailModel in emailList)
            {
                SearchContacts(client, outlookEmailModel.EmailFrom);
                if (isvalidUser)
                {
                    string LUISAppUrl = ConfigurationManager.AppSettings[Constants.CognitiveServiceOleChatLUISAppUrl];
                    string oleAppId = ConfigurationManager.AppSettings[Constants.CognitiveServiceOleChatOleAppId];
                    string oleAppkey = ConfigurationManager.AppSettings[Constants.CognitiveServiceOleChatOleAppkey];

                    string apiToTrigger = ConfigurationManager.AppSettings[Constants.APIToTriggerGoals];

                    var query = String.Concat(LUISAppUrl, oleAppId, "", oleAppkey,
                        "&verbose=true&timezoneOffset=0&q= looking ]" + outlookEmailModel.EmailBody);
                    var data = obj.GetServiceResponse<LuisResult>(query, false);
                    if (data != null)
                    {
                        //var requestedQuit =
                        //    data.TopScoringIntent.Intent.ToLower().Equals("quit") &&
                        //    data.TopScoringIntent.Score > 0.4;
                        var itendName = data.TopScoringIntent.Intent.ToLower();
                        var urlToTriggerGoal = string.Concat(apiToTrigger, "?Email= ", outlookEmailModel.EmailFrom,
                            "&Intent=", itendName);

                        // Call  sitecore api controller to trigger call;
                        obj.HttpGet(urlToTriggerGoal);
                    }
                }
            }
        }

        /// <summary>
        /// Method to search for valid contacts from XDB
        /// </summary>
        /// <param name="email"></param>
        /// <param name="isvalidUser"></param>
        /// <returns></returns>

        private static void SearchContacts(XConnectClient client, string email)
        {
            var isvalidUser = false;
           // using (XConnectClient client = GetClient())
            {
                var references = new List<IEntityReference<Sitecore.XConnect.Contact>>()
                {
                    // Username
                    new IdentifiedContactReference("", email),
                };
                string emailsFacetKey = Sitecore.XConnect.Collection.Model.CollectionModel.FacetKeys.EmailAddressList;

                // Pass the facet name into the ContactExpandOptions constructor
                var contactsTask = client.Get<Sitecore.XConnect.Contact>(references,
                    new ContactExpandOptions(emailsFacetKey)
                    {
                    });

                IReadOnlyCollection<IEntityLookupResult<Contact>> contacts = contactsTask;

                if (contacts != null && contacts.Any())
                {
                    foreach (var contact in contacts)
                    {
                        // For each contact, retrieve the facet - will return null if contact does not have this facet set
                        EmailAddressList emailsFacetData = contact.Entity.GetFacet<EmailAddressList>(emailsFacetKey);

                        if (emailsFacetData != null)
                        {
                            isvalidUser = true;
                            break;
                        }
                    }
                }

            }

            // return isvalidUser;
        }


        private static XConnectClient GetClient()
        {
            XdbModel[] models = { CollectionModel.Model };
        

            var config = new XConnectClientConfiguration(
                new XdbRuntimeModel(models),
                new Uri("https://xp091.xconnect"),
                new Uri("https://xp091.xconnect"));


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
