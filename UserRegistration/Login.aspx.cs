using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace UserRegistration
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = @"Data Source = (local)\sqlexpress; Initial Catalog = UserRegistrationDB; Integrated Security = True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) 
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("LogInProcess",sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                int result = (int)sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (result == 1)
                {
                    Session["UserName"] = txtUserName.Text.Trim();
                    Response.Redirect("Index.aspx");
                }
                else {
                    lblErrorMessage.Text = "Incorrect User Credentials!!!";
                }
            }

        }
    }
}