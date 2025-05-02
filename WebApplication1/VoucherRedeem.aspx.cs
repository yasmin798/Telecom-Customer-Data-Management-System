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
    public partial class VoucherRedeem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRedeemVoucher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobileNoVoucher.Text) || string.IsNullOrWhiteSpace(txtVoucherID.Text))
            {
                // Set a warning message if either field is empty
                lblVoucherResult.Text = "Mobile Number And Voucher ID Fields Should not be left Empty";
                lblVoucherResult.ForeColor = System.Drawing.Color.Red; // Set text color to red
                return; // Exit the method to prevent further processing
            }
            // Get values from the UI elements
            string mobileNo = txtMobileNoVoucher.Text;  // Mobile number entered by the user
            int voucherID;

            // Check if voucherID is a valid integer
            if (int.TryParse(txtVoucherID.Text, out voucherID))
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

                // Set up the connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Create a new SQL command to call the stored procedure
                    SqlCommand cmd = new SqlCommand("Redeem_voucher_points", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the procedure
                    cmd.Parameters.AddWithValue("@Mobile_Num", mobileNo);
                    cmd.Parameters.AddWithValue("@voucher_id", voucherID);

                    try
                    {
                        // Open the connection and execute the command
                        conn.Open();
                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Customer_Account WHERE mobileNo = @mobileNo", conn);
                        checkCmd.Parameters.AddWithValue("@mobileNo", mobileNo);
                        int count = (int)checkCmd.ExecuteScalar(); // Get the count of matching rows

                        // If no rows are returned, the number is invalid
                        if (count == 0)
                        {
                            lblVoucherResult.Text = "Invalid Mobile Number Entered";
                            lblVoucherResult.ForeColor = System.Drawing.Color.Red; // Set text color to red
                            return; // Exit if the number is invalid
                        }



                        // Query to check if the voucher ID exists in the Voucher table
                        SqlCommand checkVoucherCmd = new SqlCommand("SELECT COUNT(*) FROM Voucher WHERE voucherID = @voucherID", conn);
                        checkVoucherCmd.Parameters.AddWithValue("@voucherID", voucherID);
                        int count2 = (int)checkVoucherCmd.ExecuteScalar(); // Get the count of matching rows

                        // If no rows are returned, the voucher ID is invalid
                        if (count2 == 0)
                        {
                            lblVoucherResult.Text = "Invalid VoucherID Entered";
                            lblVoucherResult.ForeColor = System.Drawing.Color.Red; // Set text color to red
                            return; // Exit if the voucher ID is invalid
                        }


                        cmd.ExecuteNonQuery();  // Execute the stored procedure
                                                // Check the output message from the stored procedure

                        // If no error, display the success message
                        lblVoucherResult.Text = "Voucher redeemed successfully!";
                        lblVoucherResult.ForeColor = System.Drawing.Color.Green; // Set text color to green

                    }
                    catch (Exception ex)
                    {
                        // If there's an error, set the label to show the error message
                        lblVoucherResult.Text = "Error: " + ex.Message;
                        lblVoucherResult.ForeColor = System.Drawing.Color.Red;  // Set text color to red
                    }
                }
            }
            else
            {
                // If the voucher ID is invalid, show an error message
                lblVoucherResult.Text = "Please enter a valid voucher ID.";
                lblVoucherResult.ForeColor = System.Drawing.Color.Red;  // Set text color to red
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
        protected void balance_recharge(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("BalanceRecharge.aspx");
        }

    }
}