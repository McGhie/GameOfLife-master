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
    <link rel="stylesheet" type="text/css" href="/Content/Site.css">
</head>
<body>
     <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                </div>
                </div>
         </div>
    
   
    <form id="form1" runat="server">
      <div id="adminlogin" class="col-md-offset-5 col-md-7">
           <h3>Administrator Login</h3>
            <asp:TextBox runat="server" ID="UserNameBox" CssClass="form-control" placeHolder="Username"></asp:TextBox>
          <br/>
            <asp:TextBox runat="server" ID="PasswordBox" CssClass="form-control" placeHolder="Password"></asp:TextBox>
          <br/>
            <asp:Button runat="server" ID="AdminLoginButton" Text="Login" CssClass="btn-danger"/>
    </div>  
    </form>
</body>
</html>
