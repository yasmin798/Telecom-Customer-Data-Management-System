<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSubscribedPlans.aspx.cs" Inherits="CustomerPart3.ViewSubscribedPlans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subscribed Plans</title>
        <link rel="stylesheet" type="text/css" href="styles.css" />

</head>
<body>        <form id="form2" runat="server">
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
 <asp:Button ID="renew_Subscription" runat="server" Text="Renew Subscription" OnClick="renew_subscription" class="sidebar-btn" />
 <asp:Button ID="cashback_Selection" runat="server" Text="Cashback Selection" OnClick="cashback_selection" class="sidebar-btn" />
 <asp:Button ID="balance_Recharge" runat="server" Text="Balance Recharge" OnClick="balance_recharge" class="sidebar-btn" />
 <asp:Button ID="voucher_Redeem" runat="server" Text="Redeem Voucher" OnClick="voucher_redeem" class="sidebar-btn" /> 
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
       <p>
            <!-- Label for Mobile Number with inline style -->
            <asp:Label ID="Label1" runat="server" Text="Enter Mobile Number: " 
                style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px"></asp:Label>
            
            <!-- TextBox with inline style -->
            <asp:TextBox ID="txtMobileNumber" runat="server" 
                style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px"></asp:TextBox>
        </p>
        <asp:Button ID="btnViewPlans" runat="server" OnClick="btnViewPlans_Click" Text="View Subscribed Plans" 
          style="margin-left: 12px"  
            />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" style="margin-left: 14px"></asp:Label>
        <br />
        <asp:GridView ID="gvSubscribedPlans" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="planID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="planID" HeaderText="planID" ReadOnly="True" SortExpression="planID" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="SMS_offered" HeaderText="SMS_offered" SortExpression="SMS_offered" />
                <asp:BoundField DataField="minutes_offered" HeaderText="minutes_offered" SortExpression="minutes_offered" />
                <asp:BoundField DataField="data_offered" HeaderText="data_offered" SortExpression="data_offered" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2 %>" SelectCommand="select * from dbo.Subscribed_plans_5_Months(@MobileNo);">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtMobileNumber" Name="MobileNo" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
