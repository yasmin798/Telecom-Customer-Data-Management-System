using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            String mobile_num = MobileNumber.Text;
            String pass = Password.Text;
            // SqlCommand cmd = new SqlCommand("AccountLoginValidation", conn);
            SqlCommand cmd = new SqlCommand("SELECT dbo.AccountLoginValidation(@mobile_num, @pass)", conn);
            // cmd.Parameters.Add(new SqlParameter(@mobile_num, mobile_num));
            //cmd.Parameters.Add(new SqlParameter(@pass, pass));
            cmd.Parameters.AddWithValue("@mobile_num", mobile_num);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlParameter success = cmd.Parameters.Add("@output", SqlDbType.Bit);
            success.Direction = ParameterDirection.Output;
            conn.Open();
            var result = cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            // bool isLoginSuccessful = (bool)success.Value;
            // cmd.ExecuteScalar();

            if (result != null && Convert.ToBoolean(result))
            {
                Session["MobileNo"] = mobile_num;
                Response.Redirect("CustomerHomePage.aspx");
            }
            else
            {
                Response.Write("Invalid mobile number or password. Please try again.");
            }
            //  conn.Close();

        }
    }
}