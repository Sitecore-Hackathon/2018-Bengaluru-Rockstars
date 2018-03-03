using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Feature.XConnectUtility.Models;
using Sitecore.Data;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using System.Threading.Tasks;

namespace Hackathon.Feature.XConnectUtility.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private static Database _db;
        private static Database MasterDb => _db ?? (_db = Context.ContentDatabase ?? Factory.GetDatabase("master"));

        bool IServiceRepository.TriggerGoals(EmailIntents list)
        {
            //createContacts();

            Item root = MasterDb.GetItem(Constants.IntentRoot);

            bool success = true;

            foreach (var emailIntent in tempList().EmailIntentList) // list.EmailIntentList
            {
                foreach (Item child in root.Children)
                {
                    if (child.Fields[Templates.Intent.Fields.IntentText] != null &&
                        child.Fields[Templates.Intent.Fields.IntentText].Value == emailIntent.Intent)
                    {
                        var goal = child.Fields[Templates.Intent.Fields.Goal] != null ? child.Fields[Templates.Intent.Fields.Goal].Value : null;
                        var goalId = Guid.Parse(goal.ToString());

                        var contact = SearchContact(emailIntent.EmailId);

                       // CreateInteraction(contact, goalId);
                    }
                }
            }

            return success;
        }

        private void CreateInteraction(Task<Contact> contact, Guid goalId)
        {
            using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                   Guid channelId = Guid.Parse("86c7467a-d019-460d-9fa9-85d6d5d77fc4"); // Replace with real channel ID GUID
                    string userAgent = "XConnect Rocks";

                    // Interaction
                    var interaction = new Interaction(contact, InteractionInitiator.Brand, channelId, userAgent);

                    var fakeItemID = Guid.Parse("5746c4f3-7e16-40d9-ba1d-14c70875724c"); // Replace with real item ID

                    Sitecore.XConnect.Collection.Model.CampaignEvent pageView = new CampaignEvent()
                    {
                        Duration = new TimeSpan(0, 0, 30),
                        Url = "/test/url/test/url?query=testing"
                    };

                    interaction.Events.Add(pageView);

                    client.AddInteraction(interaction);

                    client.Submit();
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }
        }

        EmailIntents tempList()
        {
            EmailIntents list = new EmailIntents();

            list.EmailIntentList = new List<EmailIntent>();

            list.EmailIntentList.Add(new EmailIntent { EmailId = "ddsundaria@gmail.com", EmailSubject = "test mail", Intent = "Requested for Demo" });
            list.EmailIntentList.Add(new EmailIntent { EmailId = "aji@gmail.com", EmailSubject = "test mail", Intent = "Interested in Products " });
            list.EmailIntentList.Add(new EmailIntent { EmailId = "jisha@gmail.com", EmailSubject = "test mail", Intent = "Product" });

            return list;
        }

        Contact SearchContact(string emailId)
        {
            //System.Threading.Tasks.Task<Contact> contact = null;
            Contact returnValue = null;

            using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var enumerator = client.Contacts.Where(x => x.Identifiers.Any(i => i.Identifier == emailId)).GetBatchEnumeratorSync(10); // Get the first 10 results
                    
                    // Total count of contacts (all batches)
                    var totalContacts = enumerator.TotalCount;

                    // Cycle through batches
                    while (enumerator.MoveNext())
                    {
                        // Cycle through batch of 10
                        foreach (var contact in enumerator.Current)
                        {
                            returnValue = contact;
                        }
                    }

                }
                catch (XdbExecutionException ex)
                {
                    return null;
                }
                
            }

            return returnValue;
        }

        void CreateContacts()
        {
            var list = tempList();
            foreach (var a in list.EmailIntentList)
            {
                using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var identifier = new ContactIdentifier("email", a.EmailId, ContactIdentifierType.Known);

                        var contact = new Contact(identifier);

                        client.AddContact(contact);
                        client.Submit();
                    }
                    catch (XdbExecutionException ex)
                    {

                    }
                }
            }
        }

    }
}