<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferedPlans.aspx.cs" Inherits="WebApplication1.OfferedPlans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unsubscribed Plans</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
            <form id="form2" runat="server">
     <!-- Sidebar -->
<div class="sidebar">
  <asp:Button ID="dashboard" runat="server" Text="Dashboard" OnClick="Customer" class="sidebar-btn" />
  <asp:Button ID="plan_Usage" runat="server" Text="Active Plan Usage" OnClick="plan_usage" class="sidebar-btn" />
 <asp:Button ID="cashback_Transactions" runat="server" Text="Cashback Transactions" OnClick="cashback_transaction" class="sidebar-btn" />
 <asp:Button ID="Consumption" runat="server" Text="Consumption" OnClick="consumption" class="sidebar-btn" />
 <asp:Button ID="offered_Servce_plans" runat="server" Text="Offered Service Plans" OnClick="offered_service_plans" class="sidebar-btn" />
 <asp:Button ID="highest_Vouch" runat="server" Text="Highest Voucher" OnClick="highest_vouch" class="sidebar-btn" />
<asp:Button ID="last_Extra" runat="server" Text="Extra Plan Amount" OnClick="last_extra" class="sidebar-btn" />
<asp:Button ID="Last_Remaining" runat="server" Text="Remaining Plan Amount" OnClick="last_remaining" class="sidebar-btn" />
 <asp:Button ID="top_ten_Highest" runat="server" Text="Top Ten Successful Payments" OnClick="top_ten_highest" class="sidebar-btn" />
 <asp:Button ID="unresolved_Tickets" runat="server" Text="Unresolved Tickets" OnClick="unresolved_tickets" class="sidebar-btn" />
 <asp:Button ID="Benefits" runat="server" Text="Benefits" OnClick="benefits" class="sidebar-btn" />
 <asp:Button ID="view_Shops" runat="server" Text="Shops" OnClick="view_shops" class="sidebar-btn" />
 <asp:Button ID="view_Subscribed_plans" runat="server" Text="Subscribed Plans" OnClick="view_subscribed_plans" class="sidebar-btn" />
 <asp:Button ID="renew_Subscription" runat="server" Text="Renew Subscription" OnClick="renew_subscription" class="sidebar-btn" />
 <asp:Button ID="cashback_Selection" runat="server" Text="Cashback Selection" OnClick="cashback_selection" class="sidebar-btn" />
 <asp:Button ID="balance_Recharge" runat="server" Text="Balance Recharge" OnClick="balance_recharge" class="sidebar-btn" />
 <asp:Button ID="voucher_Redeem" runat="server" Text="Redeem Voucher" OnClick="voucher_redeem" class="sidebar-btn" /> 
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
        <div class="container">
        <div class="container">
        
            <h2 class="page-title">Plans Just For You!</h2>
           <!-- <asp:Label ID="Label1" runat="server" Text="Plans Just For You!"></asp:Label>-->
        
        <!--<asp:Label ID="Label2" runat="server" Text="Enter your mobile number to discover them:"></asp:Label>-->
        <p class="centered">Enter your mobile number to discover them</p>
        <asp:Label ID="MobileNumL" runat="server" Text="Mobile Number:"></asp:Label>
        <asp:TextBox ID="MobileNumber" runat="server" placeholder="Enter your mobile number"></asp:TextBox>   
        <asp:Button ID="Fetch" runat="server" Text="Get Plans" OnClick="btnFetchPlans"/>      
        <asp:GridView ID="GridViewUnsubscribedPlans" runat="server" AutoGenerateColumns="true" CssClass="custom-gridview" Visible="false"></asp:GridView>
                    
        <br />
        <asp:Label ID="lblMessage" ForeColor="Red" runat="server" CssClass="error-message"></asp:Label>
            </div>
    </form>
</body>
</html>
