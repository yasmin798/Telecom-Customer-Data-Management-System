<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eshops_vouchers.aspx.cs" Inherits="WebApplication1.E_shops_vouchers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-Shops Vouchers</title>
    <link href="styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
           <form id="form2" runat="server">
     <!-- Sidebar -->
<div class="sidebar">
        <asp:Button ID="dashboard" runat="server" Text="Dashboard" OnClick="Admins" class="sidebar-btn" />
        <asp:Button ID="customer_Profiles" runat="server" Text="Customer Profiles" OnClick="customer_profiles" class="sidebar-btn" />
        <asp:Button ID="physical_Store" runat="server" Text="Physical Stores" OnClick="physical_store" class="sidebar-btn" />
        <asp:Button ID="resolved_Tickets" runat="server" Text="Resolved Tickets" OnClick="resolved_tickets" class="sidebar-btn" />
        <asp:Button ID="customer_Service_plans" runat="server" Text="Customers' Service Plans" OnClick="customer_service_plans" class="sidebar-btn" />
        <asp:Button ID="subscribed_Accounts" runat="server" Text="Subscribed Accounts" OnClick="subscribed_accounts" class="sidebar-btn" />
        <asp:Button ID="total_Usage" runat="server" Text="Total Usage" OnClick="total_usage" class="sidebar-btn" />
        <asp:Button ID="remove_Benefits" runat="server" Text="Remove Benefits" OnClick="remove_benefits" class="sidebar-btn" />
        <asp:Button ID="sms_Offers" runat="server" Text="SMS Offers" OnClick="sms_offers" class="sidebar-btn" />
        <asp:Button ID="customer_Wallets" runat="server" Text="Customer Wallets" OnClick="customer_wallets" class="sidebar-btn" />
        <asp:Button ID="payments_Transaction" runat="server" Text="Payments’ Transaction" OnClick="payments_transaction" class="sidebar-btn" />
        <asp:Button ID="cashback_Transactions" runat="server" Text="Cashback Transactions" OnClick="cashback_transactions" class="sidebar-btn" />
        <asp:Button ID="transactions_Points" runat="server" Text="Transactions & Points" OnClick="transactions_points" class="sidebar-btn" />
        <asp:Button ID="cashback_Returned" runat="server" Text="Cashback Returned" OnClick="cashback_returned" class="sidebar-btn" />
        <asp:Button ID="transfer_Amount" runat="server" Text="Transfer Amount" OnClick="transfer_amount" class="sidebar-btn" />
        <asp:Button ID="linked_Wallets" runat="server" Text="Linked Wallets" OnClick="linked_wallets" class="sidebar-btn" />
        <asp:Button ID="update_Points" runat="server" Text="Update Points" OnClick="update_points" class="sidebar-btn" />
    <!-- Add more buttons as needed -->
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
        <div class="page-title" id="PageTitle">
    E-Shops Vouchers
</div>
        <div>
            <asp:GridView ID="GridViewEshopVouchers" runat="server" CssClass="custom-gridview">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
