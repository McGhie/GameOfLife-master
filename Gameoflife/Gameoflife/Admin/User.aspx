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
    <asp:GridView runat="server" ID="grdUsers" CssClass="table table-hover table-striped" Width="80%">
        <Columns>
             <asp:TemplateField HeaderText="Delete?">
                        <ItemTemplate>
                            <span onclick="return confirm('Are you sure to Delete the record?')">
                                <asp:LinkButton ID="lnkB" runat="Server" Text="Delete" CommandName="Delete"></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
        </Columns>
        
                
    </asp:GridView>
    </div>
    </form>
</body>
</html>
