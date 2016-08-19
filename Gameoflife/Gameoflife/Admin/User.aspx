﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Gameoflife.Admin.WebForm1" %>
<%@ Register TagPrefix="uc" TagName="MyCustomControl" Src="~/Admin/AdminUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
<uc:MyCustomControl  runat="server" />

    <form id="form1" runat="server">
        
    <div>
    <asp:GridView runat="server" ID="grdUsers">
        <Columns>
            <asp:CommandField ShowDeleteButton="true" ButtonType="Button"/>
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
