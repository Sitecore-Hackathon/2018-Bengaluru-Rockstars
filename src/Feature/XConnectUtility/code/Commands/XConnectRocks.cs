using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;


namespace Hackathon.Feature.XConnectUtility.Commands
{
    [Serializable]
    public class XConnectRocks : Command
    {
        public override void Execute(CommandContext context)
        {
            context.Parameters.Add("height", "500");
            context.Parameters.Add("width", "810");

            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

             ModalDialogOptions mdo = new ModalDialogOptions($"/Sitecore/Admin/XConnectDashboard.aspx")
            {
                Header = "XConnect Rocks dashboard",
                Height = "500",
                Width = "810",
                Message = "- for todays",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }
    }
}