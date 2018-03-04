using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Sitecore.XConnect.Operations;
using Sitecore.XConnect.Client;
using Hackathon.Feature.XConnectUtility.Models;

namespace Hackathon.Feature.XConnectUtility.sitecore.admin
{
    public partial class XConnectDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && !Sitecore.Context.User.IsAdministrator)
            {
                lblMessage.Text = "You don't have permission to view this page";
                ListView1.Visible = false;
            }
            else
            {
                ListView1.Visible = true;
                lblMessage.Text = "";
                ListBind();
            }
            
        }

        void ListBind()
        {
            List<ListViewModel> list = new List<ListViewModel>();

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var goalGuid = Guid.Parse("C22B6C5B-3065-46B4-8E10-A559AED540D2");

                    IAsyncQueryable<Sitecore.XConnect.Contact> queryable = client.Contacts
                        .Where(c => c.Interactions.Any(f => f.Events.OfType<Goal>().Any(a => a.DefinitionId == goalGuid)))
                        .Where(c => c.Interactions.Any(x => x.StartDateTime >= startDate.ToUniversalTime() && x.StartDateTime <= endDate.ToUniversalTime()))
                        .WithExpandOptions(new Sitecore.XConnect.ContactExpandOptions()
                        {
                            Interactions = new Sitecore.XConnect.RelatedInteractionsExpandOptions()
                            {
                                Limit = 100 // Returns top 100 of all contact's interactions - interactions not affected by query
                            }
                        });

                    var enumerable = queryable.GetBatchEnumeratorSync(100);

                    while (enumerable.MoveNext())
                    {
                        foreach (var contact in enumerable.Current)
                        {
                            Sitecore.XConnect.Collection.Model.EmailAddressList obj = contact.Emails();
                            list.Add(new ListViewModel
                            {
                                id = contact.Id.Value.ToString(),
                                FirstName = contact.Personal().FirstName,
                                LastName = contact.Personal().LastName,
                                Email = obj.PreferredEmail.SmtpAddress.ToString()
                            });


                            // Do something with contacts
                        }
                    }
                }
                catch (XdbExecutionException ex)
                {
                    // Handle exception
                }
            }

            ListView1.DataSource = list;
            ListView1.DataBind();
        }

    }
}