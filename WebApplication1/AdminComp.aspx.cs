using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminComp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string user = "admin123";
            string pass = "pass123";
            string users = username.Text;
            string passw = password.Text;
            if (user == users && pass == passw)
            {
                // Successful login, redirect to Dashboard
                Response.Redirect("Admin.aspx");
            }

            // Failed login, show error message
            //LblMessage.Text = "Your action was successful!";
            //LblMessage.Visible = true;
        }
    } 
 }   