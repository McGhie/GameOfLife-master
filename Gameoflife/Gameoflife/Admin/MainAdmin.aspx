<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainAdmin.aspx.cs" Inherits="Gameoflife.Admin.MainAdmin" %>
<%@ Register TagPrefix="uc" TagName="MyCustomControl" Src="~/Admin/AdminUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyCustomControl  runat="server" />
       <asp:Button runat="server" ID="UserButton" Text="User"/>
        <asp:Button runat="server" ID="UserTemplateButton" Text="User Templates"/>
    </form>
</body>
</html>
