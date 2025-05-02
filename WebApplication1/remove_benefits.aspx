<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remove_benefits.aspx.cs" Inherits="WebApplication1.remove_benefits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove Benefits</title>
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
        <asp:Button ID="sms_Offers" runat="server" Text="SMS Offers" OnClick="sms_offers" class="sidebar-btn" />
        <asp:Button ID="customer_Wallets" runat="server" Text="Customer Wallets" OnClick="customer_wallets" class="sidebar-btn" />
        <asp:Button ID="EShops_Vouchers" runat="server" Text="E-Shops Vouchers" OnClick="Eshops_vouchers" class="sidebar-btn" />
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
                 <div class="main-content">
        <div class="page-title" id="PageTitle">
    Remove Benefits
</div>
     <div class="content-body">
        <div>
            <label>Phone Number</label>
            <asp:TextBox ID="MobileNoTextBox" runat="server"></asp:TextBox>
           <label>Plan ID</label>
            <asp:TextBox ID="PlanIDTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick ="RemoveBenefits" />
            <br />
            <asp:Label ID="ResultLabel" runat="server" Text=" "></asp:Label>
            <br />
        </div>
         </div>
      </div>
    </form>
</body>
</html>
