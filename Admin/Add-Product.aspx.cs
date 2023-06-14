using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Add_Branch : System.Web.UI.Page
{
    admin a = new admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataReader rdd = a.GetDatareader("select cattegoryname from tbl_Category");
            ddlcategory.DataSource = rdd;
            ddlcategory.Items.Clear();
            ddlcategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            ddlcategory.DataTextField = "cattegoryname";
            //ddlcategory.ClearSelection();
            ddlcategory.DataBind();
            ddlcategory.Attributes.Remove(("disabled"));
            //rdd.Close();
        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString;
        cmd.Connection = conn;
        string insqry = "insert into tbl_Product Values(@productcode,@productname,@category)";
        cmd = new SqlCommand(insqry, conn);      
        cmd.Parameters.AddWithValue("@productcode", txtfirst.Text);
        cmd.Parameters.AddWithValue("@productname", txtlast.Text);
        cmd.Parameters.AddWithValue("@category", ddlcategory.SelectedValue);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Add-Product.aspx");
    }
}