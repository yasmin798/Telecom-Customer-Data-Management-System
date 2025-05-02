using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace CustomerPart3
{
    public partial class BalanceRecharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobileNoRecharge.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                // Set a warning message if either field is empty
                lblRechargeResult.Text = "Mobile Number And Amount of Recharge should not be Empty!";
                lblRechargeResult.ForeColor = System.Drawing.Color.Red; // Set text color to red
                return; // Exit the method to prevent further processing
            }
            // Get values from the UI elements
            string mobileNo = txtMobileNoRecharge.Text;
            decimal amount = decimal.Parse(txtAmount.Text);  // Ensure the amount is a valid decimal value
            string paymentMethod = ddlPaymentMethod.SelectedValue;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

            // Set up the connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                // Create a new SQL command to call the stored procedure
                SqlCommand cmd = new SqlCommand("Initiate_balance_payment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the procedure
                cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Payment_Method", paymentMethod);

                try
                {
                    // Open the connection and execute the command
                    conn.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Customer_Account WHERE mobileNo = @mobileNo", conn);
                    checkCmd.Parameters.AddWithValue("@mobileNo", mobileNo);
                    int count = (int)checkCmd.ExecuteScalar(); // Get the count of matching rows
                    if (count == 0)
                    {
                        lblRechargeResult.Text = "Invalid Mobile Number Entered";
                        lblRechargeResult.ForeColor = System.Drawing.Color.Red; // Set text color to red
                        return; // Exit if the number is invalid
                    }
                    cmd.ExecuteNonQuery();  // Execute the stored procedure

                    // Set the success message in the label
                    lblRechargeResult.Text = "Recharge successful!";
                    lblRechargeResult.ForeColor = System.Drawing.Color.Green;  // Set text color to green
                }
                catch (Exception ex)
                {
                    // If there's an error, set the label to show the error message
                    lblRechargeResult.Text = "Error: " + ex.Message;
                    lblRechargeResult.ForeColor = System.Drawing.Color.Red;  // Set text color to red
                }
            }
        }
        protected void Customer(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("CustomerHomePage.aspx");
        }
        protected void plan_usage(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("ActivePlanUsage.aspx");
        }
        protected void cashback_transaction(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("CashbackTransactions.aspx");
        }
        protected void consumption(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("Consumption.aspx");
        }
        protected void offered_plans(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("OfferedPlans.aspx");
        }
        protected void offered_service_plans(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("OfferedServicePlans.aspx");
        }
        protected void highest_vouch(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("HighestVouch.aspx");
        }
        protected void last_extra(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("LastExtra.aspx");
        }
        protected void last_remaining(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("LastRemaining.aspx");
        }
        protected void top_ten_highest(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("TopTenHighest.aspx");
        }
        protected void unresolved_tickets(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("UnresolvedTickets.aspx");
        }
        protected void benefits(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("BenefitsView.aspx");
        }
        protected void view_subscribed_plans(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("ViewSubscribedPlans.aspx");
        }
        protected void view_shops(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("ViewShops.aspx");
        }
        protected void renew_subscription(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("RenewSubscription.aspx");
        }
        protected void cashback_selection(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("CashbackSelection.aspx");
        }
        protected void voucher_redeem(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("VoucherRedeem.aspx");
        }
    }
}