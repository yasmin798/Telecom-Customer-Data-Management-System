<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link rel="stylesheet" type="text/css" href="Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h2>Log In:</h2> 
             <label for="username">Mobile Number</label>
        <asp:TextBox ID="MobileNumber" runat="server" placeholder="Enter your mobile number" ></asp:TextBox>
        <br />
       <label for="username">Password</label>
            <asp:TextBox ID="Password" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Password" placeholder="Enter your password" ></asp:TextBox>
        <asp:Button ID="signin" runat="server" OnClick="Login" Text="Login"  />
            </div>
    </form>
</body>
</html>
