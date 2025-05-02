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
    public partial class cashback_returned : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void DisplayCashbackAmount(object sender, EventArgs e)
        {
            string walletId = WalletIdTextBox.Text;
            string planId = PlanIdTextBox.Text;

            // Validate input for wallet ID and plan ID
            if (string.IsNullOrWhiteSpace(walletId) || string.IsNullOrWhiteSpace(planId))
            {
                ResultLabel.Text = "Both Wallet ID and Plan ID are required.";
                return;
            }

            // Ensure the wallet ID and plan ID are integers
            int walletID, planID;
            if (!int.TryParse(walletId, out walletID) || !int.TryParse(planId, out planID))
            {
                ResultLabel.Text = "Wallet ID and Plan ID must be valid integers.";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                // Initialize the stored procedure call to the Wallet_Cashback_Amount function
                SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_Cashback_Amount(@walletID, @planID)", conn);
                cmd.Parameters.AddWithValue("@walletID", walletID);
                cmd.Parameters.AddWithValue("@planID", planID);

                conn.Open();

                // Execute query and fetch the result
                var result = cmd.ExecuteScalar();

                // Check if result is not null and display the cashback amount
                if (result != null)
                {
                    int cashbackAmount = Convert.ToInt32(result);
                    ResultLabel.Text = "The total cashback returned: " + cashbackAmount.ToString();
                }
                else
                {
                    ResultLabel.Text = "No cashback data found for the given Wallet ID and Plan ID.";
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
        protected void transfer_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("transfer_amount.aspx");
        }
        protected void linked_wallets(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("linked_wallets.aspx");
        }
        protected void update_points(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("update_points.aspx");
        }

    }
}