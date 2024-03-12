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
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = (local)\sqlexpress; Initial Catalog = UserRegistrationDB; Integrated Security = True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("login.aspx");
            }
            lblUserDetails.Text = "User Name :" + Session["UserName"];
            if(!IsPostBack){
                btnDelete.Enabled = false;
            }
            FillGridViewData();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear() {

            hfProductId.Value = "";
            txtProductName.Text = txtQuantity.Text = txtPrice.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ProductAddOrUpdate",sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ProductId",hfProductId.Value==""?0:Convert.ToInt32(hfProductId.Value));
            sqlCmd.Parameters.AddWithValue("@Name",txtProductName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
            sqlCmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPrice.Text));
            sqlCmd.ExecuteNonQuery();
            string productId = hfProductId.Value;
            sqlCon.Close();
            Clear();
            if (productId == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblSuccessMessage.Text = "Updated Successfully";
            FillGridViewData();

        }

        public void FillGridViewData() {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ProductViewALL",sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvProduct.DataSource = dtbl;
            gvProduct.DataBind();
        
        }

        protected void lnk_onClick(object sender, EventArgs e) {
            int productId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ProductViewById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ProductId", productId);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfProductId.Value = productId.ToString();
            txtProductName.Text = dtbl.Rows[0]["Name"].ToString();
            txtQuantity.Text = dtbl.Rows[0]["Quantity"].ToString();
            txtPrice.Text = dtbl.Rows[0]["Price"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ProductDeleteById",sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ProductId",Convert.ToInt32(hfProductId.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridViewData();
            lblSuccessMessage.Text = "Deleted Succesfully";
        }
    } 
}