<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbackSelection.aspx.cs" Inherits="CustomerPart3.CashbackSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cashback</title>
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
 <asp:Button ID="renew_Subscription" runat="server" Text="Renew Subscription" OnClick="renew_subscription" class="sidebar-btn" />
 <asp:Button ID="balance_Recharge" runat="server" Text="Balance Recharge" OnClick="balance_recharge" class="sidebar-btn" />
 <asp:Button ID="voucher_Redeem" runat="server" Text="Redeem Voucher" OnClick="voucher_redeem" class="sidebar-btn" /> 
</div>

<!-- Blue line -->
<div class="sidebar-line"></div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter Mobile Number: " style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px"></asp:Label>
            <asp:TextBox ID="txtMobileNo" runat="server" style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="btnShowPayments" runat="server" OnClick="btnShowPayments_Click" OnClientClick="btnShowPayments_Click" Text="Show Payments" Width="350px" style="margin-left: 12px" />
        <p>
            <asp:Label ID="Label5" runat="server" style="margin-left: 14px"></asp:Label>
        </p>
        <asp:GridView ID="gvPayments" runat="server" Visible="False" DataSourceID="SqlDataSourcePayments" AutoGenerateColumns ="False" DataKeyNames="paymentID">
            <Columns>
                <asp:BoundField DataField="paymentID" HeaderText="paymentID" InsertVisible="False" ReadOnly="True" SortExpression="paymentID" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="date_of_payment" HeaderText="date_of_payment" SortExpression="date_of_payment" />
                <asp:BoundField DataField="payment_method" HeaderText="payment_method" SortExpression="payment_method" />
                <asp:BoundField DataField="payment_method1" HeaderText="payment_method1" SortExpression="payment_method1" />
            </Columns>
           
</asp:GridView>

        <p>
            <asp:Label ID="Label2" runat="server" Visible="False" Text="Choose PaymentID Wanted:  " style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" DataSourceID="SqlDataSourceDropDown" DataTextField="paymentID" DataValueField="paymentID" Height="49px" Width="377px" style="max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Visible="False" OnClick="Button1_Click" Text="This is the Payment I want" Width="350px" style="margin-left: 12px" />
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" style="margin-left: 14px"></asp:Label>
        </p>
        <asp:GridView ID="gvBenefits" runat="server" Visible="False" DataKeyNames="benefitID" DataSourceID="SqlDataSourceBenefits" AllowPaging="True" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="benefitID" HeaderText="benefitID" InsertVisible="False" ReadOnly="True" SortExpression="benefitID" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="validity_date" HeaderText="validity_date" SortExpression="validity_date" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="mobileNo" HeaderText="mobileNo" SortExpression="mobileNo" />
            </Columns>
            
        </asp:GridView>
        <br />
        <asp:Label ID="Label4" runat="server" Visible="False" Text="Choose BenefitID Wanted:  " style="font-size: 30px; font-weight: bold; color: #007BFF; display: block; margin-bottom: 0px; padding: 5px; text-align: left; margin-left:6px"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Visible="False" DataSourceID="SqlDataSourceBenefits" DataTextField="benefitID" DataValueField="benefitID" Width="57px" style="width: 500px; max-width: 300px; padding: 10px; font-size: 1rem; border-radius: 5px; border: 1px solid #ccc; margin-bottom: 15px; margin-left: 10px; margin-top: 0px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSubmitCashback" runat="server" OnClick="btnSubmitCashback_Click" OnClientClick="btnSubmitCashback_Click" Text="Submit Cashback" Visible="False" Width="350px" style="margin-left: 12px"/>
        <p>
            &nbsp;&nbsp;
            -------------------------------------------</p>
        <p>
            <asp:Label ID="lblResult" runat="server" style="margin-left: 14px"></asp:Label>
        </p>
        <asp:SqlDataSource ID="SqlDataSourcePayments" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2 %>" SelectCommand="SELECT paymentID, amount, date_of_payment, payment_method, payment_method
FROM Payment 
WHERE status = 'successful' AND mobileNo = @MobileNo

">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtMobileNo" Name="MobileNo" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceDropDown" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2 %>" SelectCommand="SELECT paymentID
FROM Payment 
WHERE status = 'successful' AND mobileNo = @MobileNo
">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtMobileNo" Name="MobileNo" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceBenefits" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2DB_24ConnectionString2 %>" SelectCommand="
select * from benefits b

where b.mobileNo = @MobileNo 
and not exists(

select benefitID from CashBack C

where c.benefitID = b.benefitID and c.WalletID in (select w.walletID from Wallet w 
inner join customer_account a on 
w.nationalID = a.nationalID 
where a.mobileNo = @MobileNo)

)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtMobileNo" Name="MobileNo" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
