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
        
    <div class="well col-md-6 col-md-offset-3">
    <h3>Upload Template</h3>
    <asp:FileUpload runat="server" ID="Uploader"/>
    <br/>
    <br/>
        <asp:Label runat="server" ID="UploadSuccess"></asp:Label>
    <asp:Button runat="server" ID="Save" OnClick="ButtonClick" CssClass="btn-warning" Text="Upload Template" />
    </div>
       
        </form>
    
</body>
</html>
