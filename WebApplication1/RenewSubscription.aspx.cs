using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerPart3
{
    public partial class RenewSubscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT planID, name FROM Service_plan", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlPlans.DataSource = reader;
                    ddlPlans.DataTextField = "name"; // Display plan name
                    ddlPlans.DataValueField = "planID"; // Use planID as the value
                    ddlPlans.DataBind();

                    reader.Close();
                }
            }
        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobileNo.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                // If either field is empty, show a warning message
                lblResult.Text = "Mobile Number & Amount Fields Should Not Be Empty!";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string mobileNo = txtMobileNo.Text;
                string planID = ddlPlans.SelectedValue;
                string paymentMethod = ddlPaymentMethod.SelectedValue;
                decimal amount = decimal.Parse(txtAmount.Text);

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Customer_Account WHERE mobileNo = @mobileNo", conn);
                    checkCmd.Parameters.AddWithValue("@mobileNo", mobileNo);
                    SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters to match the procedure's inputs
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                    cmd.Parameters.AddWithValue("@plan_ID", planID);

                    try
                    {
                        conn.Open();
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            lblResult.Text = "Invalid Number Entered";
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            return; // Stop further execution if the number is invalid
                        }

                        cmd.ExecuteNonQuery();
                        lblResult.Text = "Subscription renewed successfully!";
                        lblResult.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "Error: " + ex.Message;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                    }
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