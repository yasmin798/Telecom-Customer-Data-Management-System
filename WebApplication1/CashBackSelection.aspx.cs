using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Web.Configuration;

namespace CustomerPart3
{
    public partial class CashbackSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = true;
            txtMobileNo.Visible = true;
            btnShowPayments.Visible = true;
        }

        protected void btnShowPayments_Click(object sender, EventArgs e)
        {
            SqlDataSourcePayments.DataBind();
            gvPayments.DataBind();

            if (gvPayments.Rows.Count == 0)
            {
                // No benefits available, display the message
                Label5.Text = "Invalid Number Entered!";
                Label5.ForeColor = System.Drawing.Color.Red;
                gvPayments.Visible = false;
                Label2.Visible = false;
                DropDownList1.Visible = false;
                Button1.Visible = false;

            }
            else
            {
                // Clear any previous messages
                Label5.Text = "";
                Label3.Text = "";
                gvPayments.Visible = true;
                Label2.Visible = true;
                DropDownList1.Visible = true;
                Button1.Visible = true;
            }

            // Hide the benefits GridView initially
            gvBenefits.Visible = false;


            Label4.Visible = false;
            DropDownList2.Visible = false;

            // Hide the submit button until a payment is selected
            btnSubmitCashback.Visible = false;
            Label3.Text = "";
        }


        protected void btnSubmitCashback_Click(object sender, EventArgs e)
        {
            // Get the values from the UI
            string mobileNo = txtMobileNo.Text;
            int paymentID = int.Parse(DropDownList1.SelectedValue);  // Selected payment ID
            int benefitID = int.Parse(DropDownList2.SelectedValue);  // Selected benefit ID

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

            // Set up the connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create a new SQL command to call the stored procedure
                SqlCommand cmd = new SqlCommand("Payment_wallet_cashback", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the procedure
                cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                cmd.Parameters.AddWithValue("@payment_id", paymentID);
                cmd.Parameters.AddWithValue("@benefit_id", benefitID);

                try
                {
                    // Open the connection and execute the command
                    conn.Open();
                    cmd.ExecuteNonQuery();  // Execute the stored procedure

                    // Set the success message in the label
                    lblResult.Text = "Cashback successfully processed!";
                    lblResult.ForeColor = System.Drawing.Color.Green;  // Set text color to green
                    Label1.Visible = false;
                    txtMobileNo.Visible = false;
                    btnShowPayments.Visible = false;
                    Label5.Visible = false;
                    gvPayments.Visible = false;
                    Label2.Visible = false;
                    DropDownList1.Visible = false;
                    Button1.Visible = false;
                    Label3.Visible = false;
                    gvBenefits.Visible = false;
                    Label4.Visible = false;
                    DropDownList2.Visible = false;
                    btnSubmitCashback.Visible = false;
                }
                catch (Exception ex)
                {
                    // If there's an error, set the label to show the error message
                    lblResult.Text = "Error: " + ex.Message;
                    lblResult.ForeColor = System.Drawing.Color.Red;  // Set text color to red
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            gvBenefits.Visible = true;
            btnSubmitCashback.Visible = true;
            Label4.Visible = true;
            DropDownList2.Visible = true;
            SqlDataSourceBenefits.DataBind();

            // Optionally, you can also explicitly rebind the GridView to ensure it reflects the updated data
            gvBenefits.DataBind();
            DropDownList2.DataBind();
            SqlDataSourceBenefits.DataBind();
            if (gvBenefits.Rows.Count == 0)
            {
                // No benefits available, display the message
                Label3.Text = "No available benefits for this payment.";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Clear any previous messages
                Label3.Text = "";
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