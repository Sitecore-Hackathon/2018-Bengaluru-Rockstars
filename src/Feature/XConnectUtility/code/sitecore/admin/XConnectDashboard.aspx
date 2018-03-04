<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XConnectDashboard.aspx.cs" Inherits="Hackathon.Feature.XConnectUtility.sitecore.admin.XConnectDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>XConnectRocks Dashboard</h1>
        <asp:Label ID="lblMessage" runat="server" />
        <div>
            <asp:ListView ID="ListView1" runat="server"></asp:ListView>
        </div>
    </form>
</body>
</html>
