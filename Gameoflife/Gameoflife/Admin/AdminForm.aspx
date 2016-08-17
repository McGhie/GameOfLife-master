<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="Gameoflife.Admin.AdminForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1.0" /><title>
	Game of Life - Administration
</title><link rel="stylesheet" href="/Content/Site.css" /><link rel="stylesheet" href="/Content/bootstrap.min.css" />
    <script src="~/Scripts/modernizr-2.8.3.js"></script>
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</head>
<body>
     <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                </div>
         </div>
    
    <h3>Administrator Login</h3>
    <form id="form1" runat="server">
      <div>
          <p>Username:</p>
    <asp:TextBox runat="server" ID="UserNameBox"></asp:TextBox>
          <p>Password:</p>
    <asp:TextBox runat="server" ID="PasswordBox"></asp:TextBox>
          
    <asp:Button runat="server" ID="AdminLoginButton" Text="Login"/>
          
    <asp:Label runat="server" ID="EmailLabel" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
