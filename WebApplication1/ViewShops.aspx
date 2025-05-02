<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewShops.aspx.cs" Inherits="CustomerPart3.ViewShops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Shops</title>
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
 <asp:Button ID="view_Subscribed_plans" runat="server" Text="Subscribed Plans" OnClick="view_subscribed_plans" class="sidebar-btn" />
 <asp:Button ID="renew_Subscription" runat="server" Text="Renew Subscription" OnClick="renew_subscription" class="sidebar-btn" />
 <asp:Button ID="cashback_Selection" runat="server" Text="Cashback Selection" OnClick="cashback_selection" class="sidebar-btn" />
 <asp:Button ID="balance_Recharge" runat="server" Text="Balance Recharge" OnClick="balance_recharge" class="sidebar-btn" />
 <asp:Button ID="voucher_Redeem" runat="server" Text="Redeem Voucher" OnClick="voucher_redeem" class="sidebar-btn" /> 
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
        <div>
           

          <div class="page-title" id="PageTitle">
              Shop Details
          </div>
           

        </div>
        <div class="gridview-container">
        <asp:GridView ID="GridViewShops" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="shopID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="shopID" HeaderText="shopID" InsertVisible="False" ReadOnly="True" SortExpression="shopID" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            </Columns>
        </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT * FROM [shop]"></asp:SqlDataSource>
    </form>
</body>
</html>
