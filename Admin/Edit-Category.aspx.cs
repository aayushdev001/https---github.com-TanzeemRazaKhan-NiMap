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
                SqlDataReader rd = a.GetDatareader("select categoruycode,cattegoryname from tbl_Category where id='" + pid + "'");
                while (rd.Read())
                {
                    txtfirst.Text = rd["categoruycode"].ToString();
                    txtlast.Text = rd["cattegoryname"].ToString();                  
                }
                rd.Close();

               
            }
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString;
        cmd.Connection = conn;
        string insqry = "update tbl_Category set categoruycode=@categoruycode,cattegoryname=@cattegoryname where id='" + Request.QueryString["id"].ToString() + "'";

        //string insqry = "insert into tbl_Category Values(@categoruycode, @cattegoryname)";
        cmd = new SqlCommand(insqry, conn);      
        cmd.Parameters.AddWithValue("@categoruycode", txtfirst.Text);
        cmd.Parameters.AddWithValue("@cattegoryname", txtlast.Text);      
        //cmd.Parameters.AddWithValue("@status", "Enabled");
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        //Response.Redirect("View-Employee-Detail.aspx");
    }
}