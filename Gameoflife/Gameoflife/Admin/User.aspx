<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Gameoflife.Admin.WebForm1" %>
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
             <asp:TemplateField HeaderText="Delete?">

                        <ItemTemplate>

                            <span onclick="return confirm('Are you sure to Delete the record?')">

                                <asp:LinkButton ID="lnkB" runat="Server" Text="Delete" CommandName="Delete"></asp:LinkButton>

                            </span>

                        </ItemTemplate>

                    </asp:TemplateField>

        </Columns>
           <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" VerticalAlign="Top" />

                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />

                <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </div>
    </form>
</body>
</html>
