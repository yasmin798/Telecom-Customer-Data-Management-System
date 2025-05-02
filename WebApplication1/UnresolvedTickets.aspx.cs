using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestwJazz
{
    public partial class UnresolvedTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGetUnresolvedTickets_Click(object sender, EventArgs e)
        {
            string nationalID = txtNationalID.Text.Trim();

            if (!string.IsNullOrEmpty(nationalID))
            {
                LoadUnresolvedTickets(nationalID);
            }
            else
            {
                lblError.Text = "Please enter a valid National ID.";
            }
        }

        private void LoadUnresolvedTickets(string nationalID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Call the stored procedure 'Ticket_Account_Customer'
                    SqlCommand cmd = new SqlCommand("Ticket_Account_Customer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the required parameter
                    cmd.Parameters.AddWithValue("@NID", int.Parse(nationalID));

                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int unresolvedCount))
                    {
                        lblHeader.Visible = true;
                        lblUnresolvedCount.Visible = true;

                        lblUnresolvedCount.Text = unresolvedCount.ToString();
                        lblError.Text = string.Empty;
                    }
                    else
                    {
                        lblHeader.Visible = false;
                        lblUnresolvedCount.Visible = false;

                        lblError.Text = "No unresolved tickets found for this National ID.";
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error fetching unresolved tickets: " + ex.Message;
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
