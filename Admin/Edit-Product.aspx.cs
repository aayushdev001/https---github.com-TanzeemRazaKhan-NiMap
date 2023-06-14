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
        if (Page.IsPostBack == false)
        {
            if (Request.QueryString["id"] != null)
            {

                int pid = Convert.ToInt32(Request.QueryString["id"].ToString());
                SqlDataReader rd = a.GetDatareader("select productcode,productname,category from tbl_Product where id='" + pid + "'");
                while (rd.Read())
                {
                    txtfirst.Text = rd["productcode"].ToString();
                    txtlast.Text = rd["productname"].ToString();
                    ddlcategory.SelectedValue = rd["category"].ToString();
                }
                rd.Close();
            }
            {
                SqlDataReader rdd = a.GetDatareader("select cattegoryname from tbl_Category");
                ddlcategory.DataSource = rdd;
                ddlcategory.Items.Clear();               
                ddlcategory.DataTextField = "cattegoryname";               
                ddlcategory.DataBind();
                
            }
        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString;
        cmd.Connection = conn;
        string insqry = "update tbl_Product set productcode=@productcode,productname=@productname,category=@category where id='" + Request.QueryString["id"].ToString() + "'";      
        cmd = new SqlCommand(insqry, conn);      
        cmd.Parameters.AddWithValue("@productcode", txtfirst.Text);
        cmd.Parameters.AddWithValue("@productname", txtlast.Text);
        cmd.Parameters.AddWithValue("@category", ddlcategory.SelectedValue);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        //Response.Redirect("View-Employee-Detail.aspx");
    }
}