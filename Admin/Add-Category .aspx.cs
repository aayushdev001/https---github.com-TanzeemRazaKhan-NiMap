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
        
    
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString;
        cmd.Connection = conn;
        string insqry = "insert into tbl_Category Values(@categoruycode, @cattegoryname)";
        cmd = new SqlCommand(insqry, conn);      
        cmd.Parameters.AddWithValue("@categoruycode", txtfirst.Text);
        cmd.Parameters.AddWithValue("@cattegoryname", txtlast.Text);      
        //cmd.Parameters.AddWithValue("@status", "Enabled");
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Add-Category .aspx");
    }
}