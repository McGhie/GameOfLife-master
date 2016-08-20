<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadTemplate.aspx.cs" Inherits="Gameoflife.Admin.UploadTemplate" %>
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
    <asp:FileUpload runat="server" ID="Uploader"/>
    </div>
        <asp:Label runat="server" ID="UploadLabel" Text="default"></asp:Label>
        <asp:Button runat="server" ID="Save" OnClick="ButtonClick"/>
    </form>
</body>
</html>
