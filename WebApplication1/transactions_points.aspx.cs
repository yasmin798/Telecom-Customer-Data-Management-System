using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class transactions_points : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void DisplayPaymentTransactions(object sender, EventArgs e)
        {
            string mobileNum = MobileNoTextBox.Text;

            // Validate mobile number length
            if (mobileNum.Length != 11)
            {
                ResultLabel.Text = "Mobile Number must be exactly 11 characters.";
                return;
            }

            // Connection string from Web.config
            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                // Initialize the stored procedure
                SqlCommand cmd = new SqlCommand("Account_Payment_Points", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add the mobile number parameter to the stored procedure
                cmd.Parameters.AddWithValue("@mobile_num", mobileNum);

                // Open the connection to the database
                conn.Open();

                // Use SqlDataAdapter to fill data into DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Check if data exists and bind it to the GridView
                if (dt.Rows.Count > 0)
                {
                    GridViewPaymentTransactions.DataSource = dt;
                    GridViewPaymentTransactions.DataBind();
                    GridViewPaymentTransactions.HeaderRow.Cells[0].Text = "NO of Accepted Transactions";
                    GridViewPaymentTransactions.HeaderRow.Cells[1].Text = "Total Amount of earned Points";
                    ResultLabel.Text = string.Empty; // Clear any previous messages
                }
                else
                {
                    ResultLabel.Text = "No payment data found for the given account.";
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