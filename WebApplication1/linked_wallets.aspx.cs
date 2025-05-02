using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class linked_wallets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckWalletLink(object sender, EventArgs e)
        {
            string mobileNum = MobileNoTextBox.Text.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(mobileNum))
            {
                ResultLabel.Text = "Mobile Number is required.";
                return;
            }

            // Validate mobile number length
            if (mobileNum.Length != 11)
            {
                ResultLabel.Text = "Mobile Number must be exactly 11 characters.";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                // Query the Wallet_MobileNo function
                SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_MobileNo(@mobile_num)", conn);
                cmd.Parameters.AddWithValue("@mobile_num", mobileNum);

                conn.Open();

                // Execute the query and fetch the result
                var result = cmd.ExecuteScalar();

                // Check if result is not null and display if the mobile is linked to a wallet
                if (result != null && result != DBNull.Value)
                {
                    bool isLinked = Convert.ToBoolean(result);
                    ResultLabel.Text = isLinked ? "The mobile number is linked to a wallet." : "The mobile number is NOT linked to a wallet.";
                }
                else
                {
                    ResultLabel.Text = "No data found for the given mobile number.";
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                ResultLabel.Text = "Error: " + ex.Message;
            }
            finally
            {
                // Ensure the connection is closed
                conn.Close();
            }
        }
        protected void Admins(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("Admin.aspx");
        }
        protected void customer_profiles(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("customer_profiles.aspx");
        }
        protected void physical_store(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("physical_stores.aspx");
        }

        protected void resolved_tickets(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("resolved_tickets.aspx");
        }
        protected void customer_service_plans(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("customer_service_plans.aspx");
        }

        protected void subscribed_accounts(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("subscribed_accounts.aspx");
        }
        protected void total_usage(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("total_usage.aspx");
        }
        protected void remove_benefits(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("remove_benefits.aspx");
        }
        protected void sms_offers(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("sms_offers.aspx");
        }
        protected void customer_wallets(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("customer_wallets.aspx");
        }
        protected void Eshops_vouchers(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("Eshops_vouchers.aspx");
        }
        protected void payments_transaction(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("payments_transaction.aspx");
        }
        protected void cashback_transactions(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("cashback_transactions.aspx");
        }
        protected void transactions_points(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("transactions_points.aspx");
        }
        protected void cashback_returned(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("cashback_returned.aspx");
        }
        protected void transfer_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("transfer_amount.aspx");
        }
       
        protected void update_points(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("update_points.aspx");
        }

    }
}