<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTemplates.aspx.cs" Inherits="Gameoflife.Admin.WebForm2" %>
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
       <div>  
     <asp:GridView runat="server" ID="grdUserTemplates">
         <Columns>
             <asp:CommandField ShowDeleteButton="true" ButtonType="Button"/>
         </Columns>
          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" VerticalAlign="Top" />

                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />

                <AlternatingRowStyle BackColor="White" />
     </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
