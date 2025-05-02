using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestwJazz
{
    public partial class TopTenHighest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGetTopPayments_Click(object sender, EventArgs e)
        {
            string mobileNum = txtMobileNum.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNum))
            {
                LoadTopPayments(mobileNum);
            }
            else
            {
                lblError.Text = "Please enter a valid Mobile Number.";
            }
        }

        private void LoadTopPayments(string mobileNum)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Top_Successful_Payments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNum);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Check if there are any rows returned
                    if (dt.Rows.Count > 0)
                    {
                        gvTopPayments.DataSource = dt;
                        gvTopPayments.DataBind();
                        gvTopPayments.Visible = true;
                        lblNoPaymentsMessage.Visible = false; // Hide the no payments message
                    }
                    else
                    {
                        gvTopPayments.Visible = false;
                        lblNoPaymentsMessage.Text = "There are no payments made for this mobile number.";
                        lblNoPaymentsMessage.Visible = true; // Show the no payments message
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error fetching top payments: " + ex.Message;
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
        protected void voucher_redeem(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Response.Redirect("VoucherRedeem.aspx");
        }
    }
}
