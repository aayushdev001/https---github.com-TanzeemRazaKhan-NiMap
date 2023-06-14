using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departments : System.Web.UI.Page
{
    admin a = new admin();
    string connetionString = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
                DataTable dummy = new DataTable();
                dummy.Columns.Add("Product ID");
                dummy.Columns.Add("Product Name"); 
                dummy.Columns.Add("Category");
                dummy.Columns.Add("Category ID");
                dummy.Columns.Add("Edit");
                dummy.Columns.Add("Delete");
                dummy.Rows.Add();
                gvv.DataSource = dummy;
                gvv.DataBind();
                gvv.UseAccessibleHeader = true;
                gvv.HeaderRow.TableSection = TableRowSection.TableHeader;
                if(Request.QueryString["action"]!=null && Request.QueryString["id"] != null)
                {
                    litid2.Text = "Are you sure to delete record?";
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "OpenConfirmDialog('');", true);
                }
            
        }

    }
    [WebMethod(EnableSession = true)]
    public static List<Customer> GetData()
    {
        admin a = new admin();
        List<Customer> customers = new List<Customer>();
        string constr = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString;
        string query = "select id,productcode,productname,category from tbl_Product Order by id desc";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {

            customers.Add(new Customer
            {
                productcode = sdr["productcode"].ToString(),
                productname = sdr["productname"].ToString(),
                category = sdr["category"].ToString(),       
                id = Convert.ToInt32(sdr["id"].ToString())
            });
        }
        sdr.Close();
        con.Close();
        return customers;
    }
    public class Customer
    {
        public string productcode { get; set; }
        public string productname { get; set; }
        public string category { get; set; }     
        public int id { get; set; }
    }
      

    protected void BtnDelete_Click1(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null && Request.QueryString["id"] != null)
        {
            a.execute_query("delete from tbl_Product where id='" + Request.QueryString["id"].ToString() + "' ");
            Response.Redirect("View-Product-Detail.aspx", false);
        }
    }
}