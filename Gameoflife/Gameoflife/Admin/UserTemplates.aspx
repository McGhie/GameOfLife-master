<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTemplates.aspx.cs" Inherits="Gameoflife.Admin.WebForm2" %>
<%@ Register TagPrefix="uc" TagName="MyCustomControl" Src="~/Admin/AdminUserControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<uc:MyCustomControl  runat="server"/>
    <form id="form1" runat="server">
    <div>
      <div>  
     <asp:GridView runat="server" ID="grdUserTemplates" CssClass="table table-hover table-striped" Width="80%" OnRowDeleting="GrdUserTemplateDelete">
         <Columns>  
             <asp:CommandField ShowDeleteButton="true" ButtonType="Button"/>
         </Columns>
     </asp:GridView>
     </div>
        <asp:Label runat="server" ID="Index"></asp:Label>
    </div>
    </form>
</body>
</html>
