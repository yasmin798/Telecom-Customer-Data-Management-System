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
    public partial class transfer_amount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplayAverageTransferAmount(object sender, EventArgs e)
        {
            string walletId = WalletIdTextBox.Text;
            string startDate = StartDateTextBox.Text;
            string endDate = EndDateTextBox.Text;

            // Validate input for wallet ID and dates
            if (string.IsNullOrWhiteSpace(walletId) || string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate))
            {
                ResultLabel.Text = "Wallet ID, Start Date, and End Date are required.";
                return;
            }

            // Ensure the wallet ID is an integer and dates are valid
            int walletID;
            if (!int.TryParse(walletId, out walletID))
            {
                ResultLabel.Text = "Wallet ID must be a valid integer.";
                return;
            }

            DateTime start, end;
            if (!DateTime.TryParse(startDate, out start) || !DateTime.TryParse(endDate, out end))
            {
                ResultLabel.Text = "Start Date and End Date must be valid dates.";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                // Query the function Wallet_Transfer_Amount
                SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_Transfer_Amount(@walletID, @start_date, @end_date)", conn);
                cmd.Parameters.AddWithValue("@walletID", walletID);
                cmd.Parameters.AddWithValue("@start_date", start);
                cmd.Parameters.AddWithValue("@end_date", end);

                conn.Open();

                // Execute query and fetch the result
                var result = cmd.ExecuteScalar();

                // Check if result is not null and display the average transfer amount
                if (result != null && result != DBNull.Value)
                {
                    int avgAmount = Convert.ToInt32(result);
                    ResultLabel.Text = "The average transfer amount: " + avgAmount.ToString();
                }
                else
                {
                    ResultLabel.Text = "No transaction data found for the given Wallet ID and date range.";
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