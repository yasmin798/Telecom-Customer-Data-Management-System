<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication1.LoginPage" %>

<!DOCTYPE html>
<link href="Login.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
     <h2>Login</h2>

      <asp:Button ID="Admin" runat="server" Text="Admin" onClick="admin" />

     <asp:Button ID="Customer" runat="server" Text="Customer" onClick="customer" />
 </div>
    </form>
</body>
</html>
