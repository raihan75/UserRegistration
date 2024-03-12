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
    public partial class index : System.Web.UI.Page
    {
        string connectionString = @"Data Source = (local)\sqlexpress; Initial Catalog = UserRegistrationDB; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Clear();
                if (!String.IsNullOrEmpty(Request.QueryString["id"])) {
                    int userId = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID", sqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@UserId",userId);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userId.ToString();
                        txtFirstName.Text = dtbl.Rows[0][1].ToString();
                        txtLastName.Text = dtbl.Rows[0][2].ToString();
                        txtEmail.Text = dtbl.Rows[0][3].ToString();
                        txtMobileNumber.Text = dtbl.Rows[0][4].ToString();
                        ddlGender.Items.FindByValue(dtbl.Rows[0][5].ToString()).Selected = true;
                        txtAddress.Text = dtbl.Rows[0][6].ToString();
                        txtUserName.Text = dtbl.Rows[0][7].ToString();
                        txtPassword.Text = dtbl.Rows[0][8].ToString();
                        txtConfirmPassword.Text = dtbl.Rows[0][8].ToString();
                    }
                }
            }

        }

        protected void Unnamed9_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "") {
                lblErrorMessage.Text = "Please Fill the Mendatory Fields!!";
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblErrorMessage.Text = "Password do not Match!!";
            }
            else
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ContactNumber", txtMobileNumber.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Submitted Successfully";
                    Response.Redirect("Login.aspx");
                }
            }
        }

        void Clear() {
            txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtMobileNumber.Text = txtAddress.Text = txtPassword.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }

    }
}
