<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminComp.aspx.cs" Inherits="WebApplication1.AdminComp" %>

<!DOCTYPE html>
<link href="Login.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Admin Login</h2>

            <!-- Username field -->
            <label for="username">Username</label>
            <asp:TextBox ID="username" runat="server" placeholder="Enter your username"></asp:TextBox>

            <!-- Password field -->
            <label for="password">Password</label>
            <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>

            <asp:Button ID="login" runat="server" Text="Login" onClick="Login" />
        </div>
    </form>
</body>
</html>
