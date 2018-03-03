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

            foreach (var emailIntent in  list.EmailIntentList)
            {
                foreach (Item child in root.Children)
                {
                    if (child.Fields[Templates.Intent.Fields.IntentText] != null &&
                        child.Fields[Templates.Intent.Fields.IntentText].Value == emailIntent.Intent)
                    {
                        var goal = child.Fields[Templates.Intent.Fields.Goal] != null ? child.Fields[Templates.Intent.Fields.Goal].Value : null;
                         
                        var goalId = Guid.Parse(goal.ToString());

                        var contact = SearchContact(emailIntent.EmailId);

                        CreateInteraction(contact, goalId, emailIntent.EmailSubject);
                    }
                }
            }

            return success;
        }

        private void CreateInteraction(Contact contact, Guid goalId, string goalData)
        {
            using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var newContact = new Sitecore.XConnect.Contact();
                    client.AddContact(newContact);

                    // Create new interaction for this contact
                    Guid channelId = Guid.NewGuid(); // Replace with channel ID from Sitecore
                    string userAgent = "Mozilla/5.0 (Nintendo Switch; ShareApplet) AppleWebKit/601.6 (KHTML, like Gecko) NF/4.0.0.5.9 NintendoBrowser/5.1.0.13341";
                    var interaction = new Sitecore.XConnect.Interaction(newContact, InteractionInitiator.Brand, channelId, userAgent);


                    // Create new instance of goal
                    Sitecore.XConnect.Goal goal = new Goal(goalId, DateTime.UtcNow);
                    {
                    };
                    goal.Data = goalData;
                    // Add goal to interaction
                    interaction.Events.Add(goal);

                    // Add interaction operation to client
                    client.AddInteraction(interaction);

                    // Submit interaction
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
                    var enumerator = client.Contacts.Where(x => x.Identifiers.Any(i => i.Identifier == emailId)).GetBatchEnumeratorSync(1); // Get the first 10 results
                    
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