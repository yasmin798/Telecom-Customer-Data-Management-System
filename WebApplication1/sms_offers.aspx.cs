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
    public partial class sms_offers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplaySMSOffers(object sender, EventArgs e)
        {
            string mobileNum = MobileNoTextBox.Text;

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
                // Query the table-valued function
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account_SMS_Offers(@mobile_num)", conn);
                cmd.Parameters.AddWithValue("@mobile_num", mobileNum);

                conn.Open();

                // Execute query and bind results to a GridView
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SMSOffersGridView.DataSource = dt;
                    SMSOffersGridView.DataBind();
                    ResultLabel.Text = string.Empty; // Clear any previous messages
                }
                else
                {
                    ResultLabel.Text = "No SMS offers found for the given Mobile Number.";
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