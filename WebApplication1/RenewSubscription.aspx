<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenewSubscription.aspx.cs" Inherits="CustomerPart3.RenewSubscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subscribtion Renewal</title>
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
 <asp:Button ID="offered_Plans" runat="server" Text="Offered Plans" OnClick="offered_plans" class="sidebar-btn" />
 <asp:Button ID="offered_Servce_plans" runat="server" Text="Offered Service Plans" OnClick="offered_service_plans" class="sidebar-btn" />
 <asp:Button ID="highest_Vouch" runat="server" Text="Highest Voucher" OnClick="highest_vouch" class="sidebar-btn" />
 <asp:Button ID="last_Extra" runat="server" Text="Extra Plan Amount" OnClick="last_extra" class="sidebar-btn" />
<asp:Button ID="Last_Remaining" runat="server" Text="Remaining Plan Amount" OnClick="last_remaining" class="sidebar-btn" />
 <asp:Button ID="top_ten_Highest" runat="server" Text="Top Ten Successful Payments" OnClick="top_ten_highest" class="sidebar-btn" />
 <asp:Button ID="unresolved_Tickets" runat="server" Text="Unresolved Tickets" OnClick="unresolved_tickets" class="sidebar-btn" />
 <asp:Button ID="Benefits" runat="server" Text="Benefits" OnClick="benefits" class="sidebar-btn" />
 <asp:Button ID="view_Shops" runat="server" Text="Shops" OnClick="view_shops" class="sidebar-btn" />
 <asp:Button ID="view_Subscribed_plans" runat="server" Text="Subscribed Plans" OnClick="view_subscribed_plans" class="sidebar-btn" />
 <asp:Button ID="cashback_Selection" runat="server" Text="Cashback Selection" OnClick="cashback_selection" class="sidebar-btn" />
 <asp:Button ID="balance_Recharge" runat="server" Text="Balance Recharge" OnClick="balance_recharge" class="sidebar-btn" />
 <asp:Button ID="voucher_Redeem" runat="server" Text="Redeem Voucher" OnClick="voucher_redeem" class="sidebar-btn" /> 
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Mobile Number: "  style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px" Height="47px" ></asp:Label>
            <asp:TextBox ID="txtMobileNo" runat="server"  style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px"></asp:TextBox>
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Select Plan: "  style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px"></asp:Label>
        <asp:DropDownList ID="ddlPlans" runat="server" style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px">
        </asp:DropDownList>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Payment Method:  " style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px;margin-top: 0px; padding-top: 0px" Height="47px"></asp:Label>
            <asp:DropDownList ID="ddlPaymentMethod" runat="server" style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px" >
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Credit</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Payment Amount: " style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px;margin-top: 0px; padding-top: 0px" Height="47px"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server" style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px"></asp:TextBox>
        <p>
            <asp:Button ID="btnRenew" runat="server" OnClick="btnRenew_Click" Text="Renew Subscribtion" Width="310px" style="margin-left: 12px"/>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;---------------------------------------------------------</p>
        <p>
            <asp:Label ID="lblResult" runat="server" style="margin-left: 14px; font-size: 18px"></asp:Label>
        </p>
    </form>
</body>
</html>
