using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Web.Util;
using System.Globalization;

/// <summary>
/// Summary description for admin
/// </summary>
public class admin
{
    public admin()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string GymsoftConnection()
    {
        string str = ConfigurationManager.ConnectionStrings["TanzeemConnectionString"].ConnectionString.ToString();
        return str;
    }


    public DataTable Getad(string page)
    {
        string query = "SELECT * FROM tbl_propertyads WHERE ad_id='" + page + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable Getproject(string page)
    {
        string query = "SELECT * FROM tbl_premium_projects WHERE id='" + page + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }
    public DataTable GetData(string page)
    {
        string query = "SELECT page_title,Title, Description, Keywords FROM MetaTags WHERE LOWER(Page) = LOWER('" + page + "')";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }

    public string generatepin()
    {
        char[] chars = "1234567890abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ%$^&*-_?<>@#!^=+".ToCharArray();
        string code = string.Empty;
        Random random = new Random();
        for (int i = 0; i < 15; i++)
        {
            int x = random.Next(1, chars.Length);
            //Don't Allow Repetation of Characters
            if (!code.Contains(chars.GetValue(x).ToString()))
                code += chars.GetValue(x);
            else
                i--;
        }
        return code;
    }


    public DataTable GetDatamaster(string page1)
    {
        string query = "SELECT category,metatagdesc,metatagkeywords FROM tbl_category WHERE category = '" + page1 + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }
    public DataTable GetDatamastersub(string page1)
    {
        string query = "SELECT subcategoryname,metatagdesc,metatagkeywords FROM tbl_subcategories WHERE subcategoryname = '" + page1 + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }
  
  



    public int Check_Cart(string cidd, string pid, string size)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select count(*) from tbl_cart where sessionid='" + cidd + "' and pid='" + pid + "' and size='" + size + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        int k = (int)cmd.ExecuteScalar();
        con.Close();
        return k;
    }
    public int insertinto_cart(string sessid, string pid, string size, double mrp, string quantity, double total)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_cart values ('" + sessid + "','" + pid + "','" + size + "','" + quantity + "','" + mrp + "','" + total + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }



    public string get_cart_quantity(string pid, string sessid, string size)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select quantity from tbl_cart where pid='" + pid + "' and sessionid='" + sessid + "' and size='" + size + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string qty = " ";
        while (rd.Read())
        {
            qty = rd["quantity"].ToString();
        }
        rd.Close();
        con.Close();
        return qty;
    }
    public int update_cart(int s, double price, string cart_id, string pid, string size)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string s1 = "update tbl_cart set quantity='" + s + "',total=" + s + "*" + price + " where sessionid='" + cart_id + "' and pid='" + pid + "' and size='" + size + "'";
        SqlCommand cmd = new SqlCommand(s1, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }




    public int update_caart(decimal s, decimal tot, int id2)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string s1 = "update tbl_cart set quantity='" + s + "',total='" + tot + "' where id=" + id2;
        SqlCommand cmd = new SqlCommand(s1, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }

    public int checkrow_intable(string qry)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;

    }
   

    public int insert_Content(string tablename, string content)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into " + tablename + "  values ('" + content + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public string getinquiryid()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(inquiryid) As 'srno' FROM tbl_inquiry";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }

  public string getidfrom_premium_projects()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(id) As 'srno' FROM tbl_premium_projects";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }



    public int Update_Content(string tablename,string columnname,string content, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update " + tablename + " set " + columnname + "='" + content + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int Delete_Content(string tablename)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from " + tablename;
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }








   
    public int getid_by_Name(string stp)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT MenuID from tbl_menu where Name='" + stp + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string menuid = " ";
        while (rd.Read())
        {
            menuid = rd["MenuID"].ToString();
        }
        rd.Close();

        con.Close();
        int id = Convert.ToInt32(menuid);
        return id;
    }

    public string GetNameByParentID(string menuid)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT Name from tbl_menu where MenuID='" + menuid + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string name = " ";
        while (rd.Read())
        {
            name = rd["Name"].ToString();
        }
        rd.Close();

        con.Close();
        return name;
    }




   
    public int insert_tbl_menu(string category, string url, int parentid)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_menu(Name,Url,ParentID) values('" + category + "','" + url + "','" + parentid + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int check_insert_subcategory(string subcategory)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select count(*) from tbl_menu where Name='" + subcategory + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        int k = (int)cmd.ExecuteScalar();
        con.Close();
        return k;
    }

   

    public int check_insert_category(string category, int parentid)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select count(*) from tbl_menu where ParentID='" + parentid + "' AND Name='" + category + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        int j = (int)cmd.ExecuteScalar();
        con.Close();
        return j;
    }
    public int insert_tbl_menu1(string subcategory, string url, int j)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_menu(Name,Url,ParentID) values('" + subcategory + "','" + url + "','" + j + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

   
    public int insert_mfgregistration(string srno, string mdate, string mtime, string adminuser, string fname, string lname, string cname, string address, string phone_no, string fax_no, string website, string emailid, string username, string password, string manucode, string permit, string status)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_tbl_manufacture_registation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@msrno", SqlDbType.NVarChar, 50);
        param.Value = srno;
        param = cmd.Parameters.Add("@mdate", SqlDbType.NVarChar, 50);
        param.Value = mdate;
        param = cmd.Parameters.Add("@mtime", SqlDbType.NVarChar, 50);
        param.Value = mtime;

        param = cmd.Parameters.Add("@adminuser", SqlDbType.NVarChar, 50);
        param.Value = adminuser;
        param = cmd.Parameters.Add("@mfirstname", SqlDbType.NVarChar, 50);
        param.Value = fname;
        param = cmd.Parameters.Add("@mlastname", SqlDbType.NVarChar, 50);
        param.Value = lname;
        param = cmd.Parameters.Add("@companyname", SqlDbType.NVarChar, 50);
        param.Value = cname;
        param = cmd.Parameters.Add("@maddress", SqlDbType.NVarChar, 50);
        param.Value = address;
        param = cmd.Parameters.Add("@mphoneno", SqlDbType.BigInt);
        param.Value = phone_no;
        param = cmd.Parameters.Add("@mfaxno", SqlDbType.BigInt);
        param.Value = fax_no;
        param = cmd.Parameters.Add("@website", SqlDbType.NVarChar, 50);
        param.Value = website;
        param = cmd.Parameters.Add("@memailid", SqlDbType.NVarChar, 50);
        param.Value = emailid;
        param = cmd.Parameters.Add("@musername", SqlDbType.NVarChar, 50);
        param.Value = username;
        param = cmd.Parameters.Add("@mpassword", SqlDbType.NVarChar, 50);
        param.Value = password;
        param = cmd.Parameters.Add("@manufacturercode", SqlDbType.NVarChar, 50);
        param.Value = manucode;
        param = cmd.Parameters.Add("@mpermit", SqlDbType.NVarChar, 50);
        param.Value = permit;
        param = cmd.Parameters.Add("@mstatus", SqlDbType.NVarChar, 50);
        param.Value = status;
        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    


    public int insert_customer_registraion(string srno, DateTime dt, string ip, string fname, string lname, string gender, string state, string city, string address,string postalcode,  string contacno, string email, string pswd,string status,string permit)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("tbl_customer_registration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@srno", SqlDbType.NVarChar, 50);
        param.Value = srno;
        param = cmd.Parameters.Add("@dates", SqlDbType.DateTime);
        param.Value = dt;
        param = cmd.Parameters.Add("@ip", SqlDbType.NVarChar, 50);
        param.Value = ip;
        param = cmd.Parameters.Add("@firstname", SqlDbType.NVarChar, 50);
        param.Value = fname;
        param = cmd.Parameters.Add("@lastname", SqlDbType.NVarChar, 50);
        param.Value = lname;
        param = cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 50);
        param.Value = gender;
        param = cmd.Parameters.Add("@state", SqlDbType.NVarChar, 50);
        param.Value = state;
        param = cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50);
        param.Value = city;
        param = cmd.Parameters.Add("@address", SqlDbType.NVarChar);
        param.Value = address;
        param = cmd.Parameters.Add("@postalcode", SqlDbType.NVarChar, 50);
        param.Value = postalcode;
       
        param = cmd.Parameters.Add("@contactno", SqlDbType.NVarChar, 50);
        param.Value = contacno;
        param = cmd.Parameters.Add("@emailid", SqlDbType.NVarChar, 50);
        param.Value = email;
        param = cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50);
        param.Value = pswd;
        param = cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50);
        param.Value = status;
        param = cmd.Parameters.Add("@permit", SqlDbType.NVarChar, 50);
        param.Value = permit;


        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public SqlDataReader GetDatareader(string str)
    {
        SqlDataReader rd;
        SqlConnection con = new SqlConnection(GymsoftConnection());
        // String stconn = ConfigurationManager.ConnectionStrings["AMBE"].ConnectionString.ToString();

        SqlCommand cmd = new SqlCommand(str, con);
        con.Open();
        rd = cmd.ExecuteReader();
        //cs.CloseConnection();
        return rd;
    }

 
  
    public int delete_item(int pk)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "delete from tbl_cart where id=" + pk;
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
   
    public int insert_product(string srno, string pcode,  string catagory, string subcatagory, string path, string companyname,string weight, string mrpprice, string ourprice,  string featuredescription, string newarrival)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_product", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@srno", SqlDbType.NVarChar, 50);
        param.Value = srno;
        param = cmd.Parameters.Add("@productcode", SqlDbType.VarChar, 50);
        param.Value = pcode;
       
        param = cmd.Parameters.Add("@catagory", SqlDbType.VarChar, 50);
        param.Value = catagory;
        param = cmd.Parameters.Add("@subcatagory", SqlDbType.VarChar, 50);
        param.Value = subcatagory;
        param = cmd.Parameters.Add("@image", SqlDbType.VarChar, 1000);
        param.Value = path;
       
        param = cmd.Parameters.Add("@companyname", SqlDbType.VarChar, 50);
        param.Value = companyname;

        param = cmd.Parameters.Add("@weight", SqlDbType.VarChar, 50);
        param.Value = weight;

        param = cmd.Parameters.Add("@mrpprice", SqlDbType.Money);
        param.Value = mrpprice;
        param = cmd.Parameters.Add("@ourprice", SqlDbType.Money);
        param.Value = ourprice;
       
        param = cmd.Parameters.Add("@featuredescription", SqlDbType.VarChar, 50);
        param.Value = featuredescription;
        param = cmd.Parameters.Add("@newarrival", SqlDbType.VarChar, 50);
        param.Value = newarrival;

        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public string[] getcustomer_detailsbysrrno(string srno)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "select * from tbl_customer_registration where srno=" + srno;
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string[] arrname = new string[15];

        while (rd.Read())
        {




            arrname[0] = rd["firstname"].ToString();
            arrname[1] = rd["lastname"].ToString();
            arrname[2] = rd["city"].ToString();
            arrname[3] = rd["zipcode"].ToString();
            arrname[4] = rd["address"].ToString();
            arrname[5] = rd["emailid"].ToString();
            arrname[6] = rd["mobileno"].ToString();
            arrname[7] = rd["username"].ToString();
            arrname[8] = rd["password"].ToString();


        }
        con.Close();
        return arrname;
    }


    public int update_admin_pass(string auserame, string newpassword)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "UPDATE tbl_dkshopperlogin set dkpassword='" + newpassword + "' WHERE dkusername='" + auserame + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }



    public string getprno_product()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(ad_id) As 'srno' FROM tbl_propertyads";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }

    public string getprno_product1()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(id) As 'srno' FROM tbl_franchisee_registration";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }




    public int check_procode(string str1)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("select count(*) from tbl_product where productcode='" + str1 + "'", con);
        con.Open();

        int n2 = (int)cmd.ExecuteScalar();
        return n2;
    }




   



    public int ins_paymentoptions(string cnt)
    {
        // string con11 = ConfigurationManager.ConnectionStrings["travel"].ConnectionString.ToString();
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_paymentcontent (paymentcontent) values ('" + cnt + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int ins_returnpolicy(string cnt)
    {
        // string con11 = ConfigurationManager.ConnectionStrings["travel"].ConnectionString.ToString();
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_returnpolicy (returnpolicy) values ('" + cnt + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int ins_shippingpolicy(string cnt)
    {
        // string con11 = ConfigurationManager.ConnectionStrings["travel"].ConnectionString.ToString();
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_shippingpolicy (shippingpolicy) values ('" + cnt + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int ins_privacypolicy(string cnt)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_privacypolicy (privacypolicy) values ('" + cnt + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int ins_termsandconditions(string cnt)
    {
        // string con11 = ConfigurationManager.ConnectionStrings["travel"].ConnectionString.ToString();
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_termsandconditions (termsandconditions) values ('" + cnt + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }


    public int upd_paymentoptions(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_paymentcontent set paymentcontent='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int upd_returnpolicy(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_returnpolicy set returnpolicy='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int upd_shippingpolicy(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_shippingpolicy set shippingpolicy='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int upd_privacypolicy(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_privacypolicy set privacypolicy='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int upd_termsandconditions(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_termsandconditions set termsandconditions='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int deletePaymentOptions()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_paymentcontent";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int deletereturnpolicy()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_returnpolicy";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int deleteshippingpolicy()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_shippingpolicy";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int deleteprivacypolicy()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_privacypolicy";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int deletetermsandconditions()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_termsandconditions";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }


    public int insert_tbl_subscribers(string p)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_subscribers(subscriberemail) values('" + p + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int insert_tbl_leftbanner_management(string path, string p)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_leftbanner_management(image,url) values('" + path + "','" + p + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int getTotalCount(string sel1)
    {
        //String con = ConfigurationManager.ConnectionStrings["travel"].ConnectionString.ToString();
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(sel1, objcon);
        objcon.Open();
        int count = (int)cmd.ExecuteScalar();
        objcon.Close();
        return count;

    }

    public int insert_tbl_rightbanner_management(string path, string p)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_rightbanner_management(image,url) values('" + path + "','" + p + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }


    //Nirav Code Starts Here

    public string getproductimage(string id)
    {
        string img = "select product_image from tbl_product where pid='" + id + "'";
        SqlConnection objconn = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(img, objconn);
        objconn.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string imgg = " ";
        while (rd.Read())
        {
            imgg = rd["product_image"].ToString();
        }
        rd.Close();
        objconn.Close();
        return imgg;

    }

    public int delete_productimage(string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_product where pid='" + id + "'";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int checkrow1_intable(string qry)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;
    }

    public string[] getproduct_details(string pid)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "select * from tbl_product where pid=" + pid;
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string[] arrname = new string[20];

        while (rd.Read())
        {




            arrname[0] = rd["username"].ToString();
            arrname[1] = rd["cataory"].ToString();
            arrname[2] = rd["sub_catagory"].ToString();
            arrname[3] = rd["product_image"].ToString();
            arrname[4] = rd["company_name"].ToString();
            arrname[5] = rd["mrp_price"].ToString();
            arrname[6] = rd["our_price"].ToString();

            arrname[7] = rd["free_shipping"].ToString();
            arrname[8] = rd["shipping_charge"].ToString();
            arrname[9] = rd["delivered_in"].ToString();
            arrname[10] = rd["warantyperiod"].ToString();
            arrname[11] = rd["avaibility"].ToString();
            arrname[12] = rd["headinglable"].ToString();
            arrname[13] = rd["featuretitle"].ToString();
            arrname[14] = rd["featuredescription"].ToString();
            arrname[15] = rd["newarrival"].ToString();

        }
        con.Close();
        return arrname;
    }

   

    public int ins_subscribercontent(string home)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_subcriber_content (subscribercontent) values ('" + home + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int upd_subscribercontent(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_subcriber_content set subscribercontent='" + home + "' where id=1";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int deletesubscribercontent()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_subscriber_content";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }



    public int ins_faq(string home1, string home)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_faq (question,answer) values ('" + home1 + "','" + home + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int upd_faq(string home1, string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_faq set question='" + home1 + "',answer='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int deletefaq()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_faq";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }


    public int insert_tbl_brands(string p, string path)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_brands(brandname,brandimage) values('" + p + "','" + path + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }





    public int ins_tbl_storelocator(string p, string p_2, string p_3, string p_4, string p_5)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_storelocator (city,storename,address,contactno,emailid) values ('" + p + "','" + p_2 + "','" + p_3 + "','" + p_4 + "','" + p_5 + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    //Nirav Code Ends Here

    public int insert_tbl_faq(string p, string p_2)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_faq (question,answer) values ('" + p + "','" + p_2 + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    //Satish Code Ends Here



    public int ins_refferfriend(string home)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_manage_referedfriend (content) values ('" + home + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int upd_refferfriend(string home, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_manage_referedfriend set content='" + home + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }



    public int deleterefferfriend()
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "delete from  tbl_subscriber_content";
        SqlCommand cmd = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }



    public int insert_insurvey(string fname, string lname, string uname, string phone, string shopex, string rating, string rdctsat, string pricesat, string feedback, string code)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_survey values('" + fname + "','" + lname + "','" + uname + "','" + phone + "','" + shopex + "','" + rating + "','" + rdctsat + "','" + pricesat + "','" + feedback + "','" + code + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int delete_survey(string strField1)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "DELETE FROM tbl_survey WHERE id='" + strField1 + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        int rowaffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowaffected;
    }



    public int chechbrowsercode(string code, string uname)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select count(*) from tbl_shopkeepers where shopkeepercode='" + code + "' and susername='" + uname + "' and spermit='Active'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        int k = (int)cmd.ExecuteScalar();
        con.Close();
        return k;
    }


  

    public int insert_in_firstpage_image(string cat, string path)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_firstpageimage values ('" + cat + "','" + path + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public string find_pswd(string email)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select password  FROM tbl_customer_registration where emailid='" + email + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "";

        while (rd.Read())
        {
            srno = rd["password"].ToString();
        }

        con.Close();
        return srno;
    }

  

    public int insert_tbl_Animation(string path)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_Animation values('" + path + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int Insert_tbl_contacts(string address, string emailid, string phone_no)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string s = "update tbl_contacts set address='" + address + "', emailid='" + emailid + "',phone_no='" + phone_no + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }


   


    public int insert_faq(string topic, string descn)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_faq values('" + topic + "','" + descn + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_banner(string topic)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_animationbanner values('" + topic +  "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_banner1(string topic)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_lhsanimationbanner values('" + topic + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_banner12(string topic)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_rhsanimationbanner values('" + topic + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int insert_services(string topic, string image, string descn)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_services values('" + topic + "','" + image + "','" + descn + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_States(string states)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_states values('" + states +  "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int upadate_faq(string topicn, string des, string id)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string s = "update tbl_faq set question='" + topicn + "',answer='" + des + "' where id='" + id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }


  

    public int update_product_image(string photo, string pidval)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "update tbl_product set image='" + photo + "' where pid='" + pidval + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_tbl_subscribers(string p, string p_2)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_subcribers(name,email) values('" + p + "','" + p_2 + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }



    public string GetNameByEmailId(string email)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT fullname from tbl_member_registration where emailid='" + email + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string fname = " "; 
        //string lname = " ";
        while (rd.Read())
        {
            fname = rd["fullname"].ToString();
            //lname = rd["lastname"].ToString();
        }
        rd.Close();

        con.Close();
        //string name = fname + " " + lname;
        return fname;
    }

    public string GetFranchiseeCodeByName(string username)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT franchiseecode from tbl_franchisee_registration where username='" + username + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string franchiseecode = " ";
        while (rd.Read())
        {
            franchiseecode = rd["franchiseecode"].ToString();
         
        }
        rd.Close();

        con.Close();

        return franchiseecode;
    }

  


    public int update_active(string uname)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_customer_registration set permit='Active' where emailid='" + uname + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }





    //----------------------------------------------------------------------------------------------------------------------
    public int insert_applyads(string date, string time, string firm, string propreitorname, string contactname, string officeaddress, string franchiseename, string franchiseecode,string emailid, string state, string city, string pincode, string bussinessdesc, string innershopimage, string outershopimage, string amountrec, string amountpending, string adstartdate, string adenddate, string comment,string status)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_applyads", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@date", SqlDbType.Date);
        param.Value = date;
        param = cmd.Parameters.Add("@time", SqlDbType.VarChar, 50);
        param.Value = time;

        param = cmd.Parameters.Add("@firmname", SqlDbType.VarChar, 50);
        param.Value = firm;
        param = cmd.Parameters.Add("@propreitorname", SqlDbType.VarChar, 50);
        param.Value = propreitorname;
        param = cmd.Parameters.Add("@contactname", SqlDbType.VarChar, 1000);
        param.Value = contactname;

        param = cmd.Parameters.Add("@officeaddress", SqlDbType.VarChar);
        param.Value = officeaddress;

        param = cmd.Parameters.Add("@franchiseename", SqlDbType.VarChar, 100);
        param.Value = franchiseename;

        param = cmd.Parameters.Add("@franchiseecode", SqlDbType.VarChar, 100);
        param.Value = franchiseecode;
        param = cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 100);
        param.Value = emailid;

        param = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
        param.Value = state;

        param = cmd.Parameters.Add("@city", SqlDbType.VarChar, 50);
        param.Value = city;
        param = cmd.Parameters.Add("@pincode", SqlDbType.VarChar, 50);
        param.Value = pincode;

        param = cmd.Parameters.Add("@businessdescription", SqlDbType.VarChar);
        param.Value = bussinessdesc;

        param = cmd.Parameters.Add("@innershopphoto", SqlDbType.VarChar);
        param.Value = innershopimage;

        param = cmd.Parameters.Add("@outershopphoto", SqlDbType.VarChar);
        param.Value = outershopimage;

        param = cmd.Parameters.Add("@amountrecieved", SqlDbType.Money);
        param.Value = amountrec;

        param = cmd.Parameters.Add("@amountpending", SqlDbType.Money);
        param.Value = amountpending;

        param = cmd.Parameters.Add("@adstartdate", SqlDbType.Date);
        param.Value = adstartdate;

        param = cmd.Parameters.Add("@addateend", SqlDbType.Date);
        param.Value = adenddate;

        param = cmd.Parameters.Add("@comment", SqlDbType.VarChar);
        param.Value = comment;

        param = cmd.Parameters.Add("@status", SqlDbType.VarChar,50);
        param.Value = status;
        
        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }






    public int Update_Ad_Status(string id,string status)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_applyads set status='" + status + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int Update_Franchisee_Status(string id, string status)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_franchisee_registration set status='" + status + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int Update_Member_Status(string id, string status)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_member_registration set status='" + status + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int insert_member_registration(string applicationno, string date, string time, string franchiseecode,string emailid, string modeofid, string firstname, string lastname, string dob, string age, string gender, string maritalstatus, string mothername, string address, string landlineno, string mobileno, string country, string state, string city, string pincode, string passportphoto, string idproofimage, string paymentmode, string amount, string bank, string branch, string accountno, string ifcscode, string username, string password, string status)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_member_registration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@applicationformno", SqlDbType.VarChar, 100);
        param.Value = applicationno;
        param = cmd.Parameters.Add("@date", SqlDbType.Date);
        param.Value = date;
        param = cmd.Parameters.Add("@time", SqlDbType.VarChar, 50);
        param.Value = time;

        param = cmd.Parameters.Add("@franchiseecode", SqlDbType.VarChar, 100);
        param.Value = franchiseecode;
        param = cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 100);
        param.Value = emailid;
        param = cmd.Parameters.Add("@modeofid", SqlDbType.VarChar, 50);
        param.Value = modeofid;
        param = cmd.Parameters.Add("@firstname", SqlDbType.VarChar, 100);
        param.Value = firstname;

        param = cmd.Parameters.Add("@lastname", SqlDbType.VarChar,100);
        param.Value = lastname;

        param = cmd.Parameters.Add("@dob", SqlDbType.Date);
        param.Value = dob;

        param = cmd.Parameters.Add("@age", SqlDbType.Int);
        param.Value = age;
        param = cmd.Parameters.Add("@gender", SqlDbType.VarChar, 50);
        param.Value = gender;

        param = cmd.Parameters.Add("@maritalstatus", SqlDbType.VarChar, 50);
        param.Value = maritalstatus;
        param = cmd.Parameters.Add("@mothername", SqlDbType.VarChar,100);
        param.Value = mothername;

        param = cmd.Parameters.Add("@address", SqlDbType.VarChar);
        param.Value = address;

        param = cmd.Parameters.Add("@landlineno", SqlDbType.VarChar,50);
        param.Value = landlineno;

        param = cmd.Parameters.Add("@mobileno", SqlDbType.VarChar,50);
        param.Value = mobileno;

        param = cmd.Parameters.Add("@country", SqlDbType.VarChar, 50);
        param.Value = country;

        param = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
        param.Value = state;

        param = cmd.Parameters.Add("@city", SqlDbType.VarChar, 50);
        param.Value = city;

        param = cmd.Parameters.Add("@pincode", SqlDbType.VarChar, 50);
        param.Value = pincode;

        param = cmd.Parameters.Add("@passportphoto", SqlDbType.VarChar);
        param.Value = passportphoto;

        param = cmd.Parameters.Add("@idphoto", SqlDbType.VarChar);
        param.Value = idproofimage;

        param = cmd.Parameters.Add("@paymentmode", SqlDbType.VarChar,50);
        param.Value = paymentmode;

        param = cmd.Parameters.Add("@amount", SqlDbType.Money);
        param.Value = amount;


        param = cmd.Parameters.Add("@bank", SqlDbType.VarChar,100);
        param.Value = bank;

        param = cmd.Parameters.Add("@branch", SqlDbType.VarChar, 100);
        param.Value = branch;


        param = cmd.Parameters.Add("@account", SqlDbType.VarChar, 100);
        param.Value = accountno;

        param = cmd.Parameters.Add("@ifcscode", SqlDbType.VarChar,50);
        param.Value = ifcscode;

        param = cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
        param.Value = username;

        param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 100);
        param.Value = password;

        param = cmd.Parameters.Add("@status", SqlDbType.VarChar, 50);
        param.Value = status;




        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int insert_franchisee_registration(string applicationno, string date, string time, string franchiseecode,string email, string territory, string authoriseperson, string mothername, string resaddress, string officeaddress, string contact, string pan, string bank, string accountno, string branch, string ifcs, string idproofimage, string addressproofimage, string passportphoto, string username, string password, string status)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_franchisee_registration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
        param = cmd.Parameters.Add("@franchiseeapplicationno", SqlDbType.VarChar, 100);
        param.Value = applicationno;
        param = cmd.Parameters.Add("@date", SqlDbType.Date);
        param.Value = date;
        param = cmd.Parameters.Add("@time", SqlDbType.VarChar, 100);
        param.Value = time;

        param = cmd.Parameters.Add("@franchiseecode", SqlDbType.VarChar, 100);
        param.Value = franchiseecode;
        param = cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 100);
        param.Value = email;
        param = cmd.Parameters.Add("@territory", SqlDbType.VarChar, 100);
        param.Value = territory;
        param = cmd.Parameters.Add("@authorisedperson", SqlDbType.VarChar, 100);
        param.Value = authoriseperson;

        param = cmd.Parameters.Add("@mothername", SqlDbType.VarChar, 100);
        param.Value = mothername;

        param = cmd.Parameters.Add("@residentialaddress", SqlDbType.VarChar);
        param.Value = resaddress;

        param = cmd.Parameters.Add("@officeaddress", SqlDbType.VarChar);
        param.Value = officeaddress;
        param = cmd.Parameters.Add("@contactno", SqlDbType.VarChar, 100);
        param.Value = contact;

        param = cmd.Parameters.Add("@pancarddrivinglicenseno", SqlDbType.VarChar, 100);
        param.Value = pan;
        param = cmd.Parameters.Add("@bankname", SqlDbType.VarChar, 100);
        param.Value = bank;

        param = cmd.Parameters.Add("@accountno", SqlDbType.VarChar, 100);
        param.Value = accountno;

        param = cmd.Parameters.Add("@branch", SqlDbType.VarChar, 100);
        param.Value = branch;
        param = cmd.Parameters.Add("@ifcscode", SqlDbType.VarChar, 100);
        param.Value = ifcs;

        param = cmd.Parameters.Add("@idproof", SqlDbType.VarChar);
        param.Value = idproofimage;

        param = cmd.Parameters.Add("@addressproof", SqlDbType.VarChar);
        param.Value = addressproofimage;

        param = cmd.Parameters.Add("@photo", SqlDbType.VarChar);
        param.Value = passportphoto;

        param = cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
        param.Value = username;

        param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 100);
        param.Value = password;

        param = cmd.Parameters.Add("@status", SqlDbType.VarChar, 100);
        param.Value = status;

        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }


    public int insert_tbl_msgs(string date,string time,string from, string to,string subject, string attachfile, string msg,string status )
    {
       
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("insert_tbl_msgs", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
      
        param = cmd.Parameters.Add("@date", SqlDbType.Date);
        param.Value = date;
        param = cmd.Parameters.Add("@time", SqlDbType.VarChar, 50);
        param.Value = time;

        param = cmd.Parameters.Add("@sender", SqlDbType.VarChar, 50);
        param.Value = from;
        param = cmd.Parameters.Add("@reciever", SqlDbType.VarChar, 50);
        param.Value = to;
        param = cmd.Parameters.Add("@subject", SqlDbType.VarChar, 50);
        param.Value = subject;

        param = cmd.Parameters.Add("@attachfile", SqlDbType.VarChar, 50);
        param.Value = attachfile;

        param = cmd.Parameters.Add("@message", SqlDbType.VarChar);
        param.Value = msg;

        param = cmd.Parameters.Add("@status", SqlDbType.VarChar, 50);
        param.Value = status;

        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int DeleteMsgs(int chkid)
    {
        string delquery = "Delete from tbl_msgs where id=" + chkid + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }


    public int Approve_Member(string username, string password,string status, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_member_registration set status='" + status + "',username='" + username + "',password='" + password + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int insert_ad(string sdt, string edt, string caption, string state, string city, string adimage,string status)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_ads(startdate,enddate,caption,state,city,adimage,status) values('" + sdt + "','" + edt + "','" + caption + "','" + state + "','" + city + "','" + adimage + "','" + status + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int Delete_banner(string p)
    {
        string delquery = "Delete from tbl_animationbanner where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }

    public int Delete_banner1(string p)
    {
        string delquery = "Delete from tbl_lhsanimationbanner where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }
    public int Delete_banner12(string p)
    {
        string delquery = "Delete from tbl_rhsanimationbanner where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }

    public int Delete_AdImage(string p)
    {
        string delquery = "Delete from tbl_ads where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }
    public int insert_feedback(string dt,string p, string p_2, string p_3, string p_4, string p_5)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "insert into tbl_feedback (date,name,emailid,phoneno,rating,comment) values ('" + dt + "','" + p + "','" + p_2 + "','" + p_3 + "','" + p_4 + "','" + p_5 + "')";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int insert_City(string state, string cy)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_statecity values('" + state + "','" + cy + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int Delete_City(string p)
    {
        string delquery = "Delete from tbl_statecity where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }

    public int Update_City(string id, string state, string city)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_statecity set state='" + state + "', city='" + city + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
  
    //public string ShowPopupMessage(string messageType)
    //{
    //    string img = "";
    //    switch (messageType)
    //    {
    //        case "Error":
    //            img = "Error.png";
    //            break;
    //        case "Message":
    //            img = "Information.png";
    //            break;
    //        case "Warning":
    //            img = "Warning.png";
    //            break;
    //        case "Success":
    //            img = "Success.png";
    //            break;
    //        default:
    //            img = "Information.png";
    //            break;
    //    }

    //    return img;
       

    //}
    //public enum PopupMessageType
    //{
    //    Error,
    //    Message,
    //    Warning,
    //    Success
    //}
    public string calculateage(string year, string month, string day)
    {
        int intYear, intMonth, intDate;
        intYear = Convert.ToInt32(year);
        intMonth = Convert.ToInt32(month);
        intDate = Convert.ToInt32(day);
        DateTime dtt = new DateTime(intYear, intMonth, intDate);
        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(dtt);
        intDate = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDate, 365, out intResult);
        //intMonth = Math.DivRem(intResult, 30, out intResult);
        //intDate = intResult;
        return intYear.ToString();
    }


    public int update_Ad_image(string photo, string pidval)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "update tbl_ads set adimage='" + photo + "' where id='" + pidval + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int update_member_registration(string id,string emailid, string modeofid, string firstname, string lastname, string dob, string age, string gender, string maritalstatus, string mothername, string address, string landlineno, string mobileno, string country, string state, string city, string pincode, string paymentmode, string amount, string bank, string branch, string accountno, string ifcscode,string username,string password)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand("update_member_registration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlParameter param = new SqlParameter();
       
        param = cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 100);
        param.Value = emailid;
        param = cmd.Parameters.Add("@modeofid", SqlDbType.VarChar, 50);
        param.Value = modeofid;
        param = cmd.Parameters.Add("@firstname", SqlDbType.VarChar, 100);
        param.Value = firstname;

        param = cmd.Parameters.Add("@lastname", SqlDbType.VarChar, 100);
        param.Value = lastname;

        param = cmd.Parameters.Add("@dob", SqlDbType.Date);
        param.Value = dob;

        param = cmd.Parameters.Add("@age", SqlDbType.Int);
        param.Value = age;
        param = cmd.Parameters.Add("@gender", SqlDbType.VarChar, 50);
        param.Value = gender;

        param = cmd.Parameters.Add("@maritalstatus", SqlDbType.VarChar, 50);
        param.Value = maritalstatus;
        param = cmd.Parameters.Add("@mothername", SqlDbType.VarChar, 100);
        param.Value = mothername;

        param = cmd.Parameters.Add("@address", SqlDbType.VarChar);
        param.Value = address;

        param = cmd.Parameters.Add("@landlineno", SqlDbType.VarChar, 50);
        param.Value = landlineno;

        param = cmd.Parameters.Add("@mobileno", SqlDbType.VarChar, 50);
        param.Value = mobileno;

        param = cmd.Parameters.Add("@country", SqlDbType.VarChar, 50);
        param.Value = country;

        param = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
        param.Value = state;

        param = cmd.Parameters.Add("@city", SqlDbType.VarChar, 50);
        param.Value = city;

        param = cmd.Parameters.Add("@pincode", SqlDbType.VarChar, 50);
        param.Value = pincode;

        param = cmd.Parameters.Add("@paymentmode", SqlDbType.VarChar, 50);
        param.Value = paymentmode;

        param = cmd.Parameters.Add("@amount", SqlDbType.Money);
        param.Value = amount;


        param = cmd.Parameters.Add("@bank", SqlDbType.VarChar, 100);
        param.Value = bank;

        param = cmd.Parameters.Add("@branch", SqlDbType.VarChar, 100);
        param.Value = branch;


        param = cmd.Parameters.Add("@account", SqlDbType.VarChar, 100);
        param.Value = accountno;

        param = cmd.Parameters.Add("@ifcscode", SqlDbType.VarChar, 50);
        param.Value = ifcscode;


        param = cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
        param.Value = username;

        param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 100);
        param.Value = password;

        param = cmd.Parameters.Add("@id", SqlDbType.Int);
        param.Value = id;

      



        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int update_PassportPhoto(string photo, string pidval)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "update tbl_member_registration set passportphoto='" + photo + "' where id='" + pidval + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }


    public int update_IdPhoto(string photo, string pidval)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "update tbl_member_registration set idphoto='" + photo + "' where id='" + pidval + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    //public int increment_count(string cs)
    //{
       
    //    SqlConnection con = new SqlConnection(GymsoftConnection());
    //    string ins = "insert into tbl_count(count) values('" + cs + "')";
    //    SqlCommand cmd = new SqlCommand(ins, con);
    //    con.Open();
    //    int rowseffected = (int)cmd.ExecuteNonQuery();
    //    con.Close();
    //    return rowseffected;
    //}

    public int initialise_point(string member, string date, string point)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_member_adview(member,date,points)values ('" + member + "','" + date + "','" + point + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int update_point(string id, string point)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "update tbl_member_adview set points='" + point + "' where id='" + id + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public string getCityBymember(string sc)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(sc, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string city = "";
        while (rd.Read())
        {
            city = rd["city"].ToString();
        }
        rd.Close();

        con.Close();

        return city;
    }


    public string getModeBymember(string sc)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(sc, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string mode = "";
        while (rd.Read())
        {
            mode = rd["modeofid"].ToString();
        }
        rd.Close();

        con.Close();

        return mode;
    }



    public int Update_Message_Status(string id, string status)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_msgs set status='" + status + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int insert_Holiday(string topic, string descn)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_holiday values('" + topic + "','" + descn + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int update_Holiday(string topicn, string des, string id)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string s = "update tbl_holiday set holidaydate='" + topicn + "',message='" + des + "' where id='" + id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }



    public int Update_Member_Adview(string username, string us)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_member_adview set member='" + username + "' where member='" + us + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }




    public int Delete_Holiday(string p)
    {
        string delquery = "Delete from tbl_holiday where id=" + p + "";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmddel = new SqlCommand(delquery, con);
        con.Open();
        int roweffect = cmddel.ExecuteNonQuery();
        con.Close();
        return roweffect;
    }


    public int insert_assign_memberpayout(string year, string month, string startdate, string enddate, string payout)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_assign_memberpayout(year,month,startdate,enddate,payout) values('" + year + "','" + month + "','" + startdate + "','" + enddate + "','" + payout + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_assign_agnipayout(string year, string month, string startdate, string enddate, string payout)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_assign_agnipayout(year,month,startdate,enddate,payout) values('" + year + "','" + month + "','" + startdate + "','" + enddate + "','" + payout + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int update_assign_memberpayout(string year, string month, string startdate, string enddate, string payout,string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_assign_memberpayout set year='" + year + "',month='" + month + "',startdate='" + startdate + "',enddate='" + enddate + "',payout='" + payout +"' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }
    public int update_assign_agnipayout(string year, string month, string startdate, string enddate, string payout, string id)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_assign_agnipayout set year='" + year + "',month='" + month + "',startdate='" + startdate + "',enddate='" + enddate + "',payout='" + payout + "' where id='" + id + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public string getStartdateByMonth(string month)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT startdate,enddate,payout from tbl_assign_memberpayout where month='" + month + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string startdate = " ";
        string enddate = " ";
        string payout = " ";
        while (rd.Read())
        {
            startdate = rd["startdate"].ToString();
            enddate = rd["enddate"].ToString();
            payout = rd["payout"].ToString();
        }
        rd.Close();

        con.Close();
        return startdate + ">" + enddate + ">" + payout;
    }


    public string getAgniStartdateByMonth(string month)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "SELECT startdate,enddate,payout from tbl_assign_agnipayout where month='" + month + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string startdate = " ";
        string enddate = " ";
        string payout = " ";
        while (rd.Read())
        {
            startdate = rd["startdate"].ToString();
            enddate = rd["enddate"].ToString();
            payout = rd["payout"].ToString();
        }
        rd.Close();

        con.Close();
        return startdate + ">" + enddate + ">" + payout;
    }


    public int insert_memberpayout(string member, string year, string monthname, string monthstartdate, string monthenddate, string startdate, string enddate, string payout, string wd, string hd, string td, string total)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_memberpayout(member,year,month,monthstartdate,monthenddate,workstartdate,worktilldate,payout,workingdays,holidays,totaldays,totalpayout)values('" + member + "','" + year + "','" + monthname + "','" + monthstartdate + "','" + monthenddate + "','" + startdate + "','" + enddate + "','" + payout + "','" + wd + "','" + hd + "','" + td + "','" + total + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }
    public int insert_agni_memberpayout(string member, string year, string monthname, string monthstartdate, string monthenddate, string startdate, string enddate, string payout, string wd, string hd, string td, string total)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_agni_memberpayout(member,year,month,monthstartdate,monthenddate,workstartdate,worktilldate,payout,workingdays,holidays,totaldays,totalpayout)values('" + member + "','" + year + "','" + monthname + "','" + monthstartdate + "','" + monthenddate + "','" + startdate + "','" + enddate + "','" + payout + "','" + wd + "','" + hd + "','" + td + "','" + total + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int insert_memberpayout_february(string member, string year, string monthname, string monthstartdate, string monthenddate, string startdate, string enddate, string payout, string wd, string hd, string td, string total)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_memberpayout_february(member,year,month,monthstartdate,monthenddate,workstartdate,worktilldate,payout,workingdays,holidays,totaldays,totalpayout)values('" + member + "','" + year + "','" + monthname + "','" + monthstartdate + "','" + monthenddate + "','" + startdate + "','" + enddate + "','" + payout + "','" + wd + "','" + hd + "','" + td + "','" + total + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }



    public int Update_agni_memberpayout(string member, string year, string monthname, string monthstartdate, string monthenddate, string workstartdate, string workenddate, string wd, string hd, string td, string total)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_agni_memberpayout set monthstartdate='" + monthstartdate + "',monthenddate='" + monthenddate + "',workstartdate='" + workstartdate + "',worktilldate='" + workenddate + "',workingdays='" + wd + "',holidays='" + hd + "',totaldays='" + td + "',totalpayout='" + total + "' where year='" + year + "' and month='" + monthname + "' and member='" + member + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int Update_memberpayout(string member, string year, string monthname, string monthstartdate, string monthenddate, string workstartdate, string workenddate, string wd, string hd, string td, string total)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_memberpayout set monthstartdate='" + monthstartdate + "',monthenddate='" + monthenddate + "',workstartdate='" + workstartdate + "',worktilldate='" + workenddate + "',workingdays='" + wd + "',holidays='" + hd + "',totaldays='" + td + "',totalpayout='" + total + "' where year='" + year + "' and month='" + monthname + "' and member='" + member + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int Update_memberpayout_february(string member, string year, string monthname, string monthstartdate, string monthenddate, string workstartdate, string workenddate, string wd, string hd, string td, string total)
    {
        SqlConnection objcon = new SqlConnection(GymsoftConnection());
        string del = "update tbl_memberpayout_february set monthstartdate='" + monthstartdate + "',monthenddate='" + monthenddate + "',workstartdate='" + workstartdate + "',worktilldate='" + workenddate + "',workingdays='" + wd + "',holidays='" + hd + "',totaldays='" + td + "',totalpayout='" + total + "' where year='" + year + "' and month='" + monthname + "' and member='" + member + "'";
        SqlCommand cmd11 = new SqlCommand(del, objcon);
        objcon.Open();
        int roweffect = cmd11.ExecuteNonQuery();
        objcon.Close();
        return roweffect;
    }

    public int insert_partner(string adimage, string content)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_partner values('" + adimage + "','" + content + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public int insert_associates(string topic, string image, string descn)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "insert into tbl_associates values('" + topic + "','" + image + "','" + descn + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }


    public int execute_query(string query)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
      
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        int rowsaffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowsaffected;
    }

    public string getregno()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(gymregno) As 'srno' FROM tbl_gym_registration";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }


    public int insert_timetable(string cooks, string p_1, string p_2, string p_3, string p_4, string brek, string p_5, string p_6, string p_7, string p_8, string p_9, string p_10, string p_11)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());


        string ins = "insert into tbl_timetable values('" + cooks + "','" + p_1 + "','" + p_2 + "','" + p_3 + "','" + p_4 + "','" + brek + "','" + p_5 + "','" + p_6 + "','" + p_7 + "','" + p_8 + "','" + p_9 + "','" + p_10 + "','" + p_11 + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = (int)cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }

    public string getSchoolregnoByusername(string p)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select gymregno  FROM tbl_gym_registration where username='" + p + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string regno = "";
        while (rd.Read())
        {
            regno = rd["gymregno"].ToString();
        }

        con.Close();
        return regno;
    }



    




    public string getstaffregno()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(staffregno) As 'srno' FROM tbl_staff_registration";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }



    public string getstudentregno()
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = " Select Max(applicationno) As 'srno' FROM tbl_student_registration";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string srno = "0";

        while (rd.Read())
        {
            srno = rd["srno"].ToString();
        }

        con.Close();
        return srno;
    }

    public int checkrow_intable1(string qy)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(qy, con);
        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;
    }
    public string Encrypt(string clearText)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[clearText.Length];
        encode = Encoding.UTF8.GetBytes(clearText);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }
    public string Decrypt(string cipherText)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        cipherText = cipherText.Replace('-', '+').Replace('_', '/').PadRight(4 * ((cipherText.Length + 3) / 4), '=');
        byte[] todecode_byte = Convert.FromBase64String(cipherText);
        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }

    public int logincheck(string tablename, string username, string password)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "Select count(*) from " + tablename + " where adminname =@username COLLATE SQL_Latin1_General_CP1_CS_AS and pass_word=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.Parameters.AddWithValue("@username ", username);
        cmd.Parameters.AddWithValue("@password ", password);

        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;


    }

    public int loginchecksubadmin(string tablename, string username, string password)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "Select count(*) from " + tablename + " where emailid =@username COLLATE SQL_Latin1_General_CP1_CS_AS and password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.Parameters.AddWithValue("@username ", username);
        cmd.Parameters.AddWithValue("@password ", password);

        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;


    }

    public int transportlogincheck(string tablename, string username, string password)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "Select count(*) from " + tablename + " where emailid =@username COLLATE SQL_Latin1_General_CP1_CS_AS and password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.Parameters.AddWithValue("@username ", username);
        cmd.Parameters.AddWithValue("@password ", password);

        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;


    }

    public int memberlogincheck(string tablename, string username, string password)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "Select count(*) from " + tablename + " where branchid =@username COLLATE SQL_Latin1_General_CP1_CS_AS and password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.Parameters.AddWithValue("@username ", username);
        cmd.Parameters.AddWithValue("@password ", password);

        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;


    }

    public void sendmail(string frommail, string toemail, string subject,string message)
    {
        System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage("noreply@builderbooking.com", toemail, subject, message);
        MyMailMessage.IsBodyHtml = true;
        // System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("no.rply10dollarstore@gmail.com", "kurti007@121");
        System.Net.NetworkCredential mailauthentication = new System.Net.NetworkCredential("noreply@builderbooking.com", "0@7Xrm9h");
        SmtpClient mailClient = new SmtpClient("webmail.builderbooking.com", 25);
        ////Enable SSL
        //mailClient.EnableSsl = true;

        mailClient.UseDefaultCredentials = false;
        mailClient.Credentials = mailauthentication;
        mailClient.Send(MyMailMessage);
        //System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage("noreply@builderbooking.com", toemail, subject, message);
        //MyMailMessage.IsBodyHtml = true;
        //// System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("no.rply10dollarstore@gmail.com", "kurti007@121");
        //System.Net.NetworkCredential mailauthentication = new System.Net.NetworkCredential("noreply@builderbooking.com", "0@7Xrm9h");
        //SmtpClient mailClient = new SmtpClient("webmail.builderbooking.com", 25);
        //////Enable SSL
        ////mailClient.EnableSsl = true;

        //mailClient.UseDefaultCredentials = false;
        //mailClient.Credentials = mailauthentication;
        //mailClient.Send(MyMailMessage);
      
    }
    public int logincheck1(string tablename, string emailid, string password)
    {

        SqlConnection con = new SqlConnection(GymsoftConnection());
        string qry = "Select count(*) from " + tablename + " where emailid =@emailid COLLATE SQL_Latin1_General_CP1_CS_AS and password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.Parameters.AddWithValue("@emailid ", emailid);
        cmd.Parameters.AddWithValue("@password ", password);

        int count = (int)cmd.ExecuteScalar();
        con.Close();
        return count;


    }

    public int clear_gridview(string h)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string ins = "delete from tbl_cart where sessionid='" + h + "'";
        SqlCommand cmd = new SqlCommand(ins, con);
        con.Open();
        int rowseffected = cmd.ExecuteNonQuery();
        con.Close();
        return rowseffected;
    }



    public DataTable Getmetatagdata(string page)
    {
        string query = "SELECT pagename,pagetitle,metatagekeywords,metatagedescription FROM tbl_page WHERE pagename = '" + page + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable Getmetatagdata1(string page)
    {
        string query = "SELECT pagename,pagetitle,metatagekeywords,metatagedescription FROM tbl_extrapage WHERE pagename = '" + page + "'";
        SqlConnection con = new SqlConnection(GymsoftConnection());
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        con.Open();
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;


    }

    public string geturlbypagename(string pagename)
    {
        
      
        string xxc = "";
        string adtop = " select count(*) from tbl_advertisement where pagename='" + pagename + "' and status='Active'";
        int countadtop = checkrow_intable(adtop);
        if (countadtop == 0)
        {
            xxc = "N.A";
           // ImgBannerTop.ImageUrl = "~/images/photo.jpg";
        }
        if (countadtop > 0)
        {

            


            string sqladtop = "select image,url,enddate,srno,city from tbl_advertisement where pagename='" + pagename + "'   and status='Active'";
            SqlDataReader rdadtop = GetDatareader(sqladtop);
            string image = "", url = "", edate = "", srno = "", city = "";
            while (rdadtop.Read())
            {
                image = rdadtop["image"].ToString();
                url = rdadtop["url"].ToString();
                edate = rdadtop["enddate"].ToString();
                srno = rdadtop["srno"].ToString();
                city = rdadtop["city"].ToString();
            }
            rdadtop.Close();

            //string adtcity = " select count(*) from tbl_advertisement where city='" + city + "' and status='Active'";
            //int countcity = checkrow_intable(adtcity);
            //if (countadtop == 0)
            //{
            //    xxc = "N.A";
            //}
            //else
            //{

              

                string[] dbjedate = edate.Split(' ');
                string[] arredate = dbjedate[0].Split('/');
                string enddate = arredate[2].ToString() + "-" + arredate[0].ToString() + "-" + arredate[1].ToString();
                DateTime currentdate = DateTime.Now;
                TimeSpan diffok = Convert.ToDateTime(enddate) - currentdate;

                decimal diff = Convert.ToDecimal(diffok.TotalDays);
                // xxc = diff.ToString();
                if (diff > 0)
                {
                    xxc = image + "|" + url;
                }
                else
                {
                    string update = "update tbl_advertisement set status='" + "Suspended" + "' where  pagename='" + pagename + "'   and srno='" + srno + "'";
                    int gh = execute_query(update);
                    xxc = "N.A";
                }
            //}

        }

        return xxc;

    }

    public string geturlbypagenamecity(string pagename, string city)
    {
        string xxc = "";
        string adtop = " select count(*) from tbl_advertisement where pagename='" + pagename + "' and CHARINDEX(city,'" + city + "') > 0   and status='Active'";
        int countadtop = checkrow_intable(adtop);
        if (countadtop == 0)
        {
            xxc = "N.A";
            // ImgBannerTop.ImageUrl = "~/images/photo.jpg";
        }
        if (countadtop > 0)
        {

            string sqladtop = "select image,url,enddate,srno,city from tbl_advertisement where pagename='" + pagename + "'   and status='Active'";
            SqlDataReader rdadtop = GetDatareader(sqladtop);
            string image = "", url = "", edate = "", srno = "";
            while (rdadtop.Read())
            {
                image = rdadtop["image"].ToString();
                url = rdadtop["url"].ToString();
                edate = rdadtop["enddate"].ToString();
                srno = rdadtop["srno"].ToString();
               
            }
            rdadtop.Close();

            //string adtcity = " select count(*) from tbl_advertisement where city='" + city + "' and status='Active'";
            //int countcity = checkrow_intable(adtcity);
            //if (countadtop == 0)
            //{
            //    xxc = "N.A";
            //}
            //else
            //{



            string[] dbjedate = edate.Split(' ');
            string[] arredate = dbjedate[0].Split('/');
            string enddate = arredate[2].ToString() + "-" + arredate[0].ToString() + "-" + arredate[1].ToString();
            DateTime currentdate = DateTime.Now;
            TimeSpan diffok = Convert.ToDateTime(enddate) - currentdate;

            decimal diff = Convert.ToDecimal(diffok.TotalDays);
            // xxc = diff.ToString();
            if (diff > 0)
            {
                xxc = image + "|" + url;
            }
            else
            {
                string update = "update tbl_advertisement set status='" + "Suspended" + "' where  pagename='" + pagename + "'   and srno='" + srno + "'";
                int gh = execute_query(update);
                xxc = "N.A";
            }
            //}

        }

        return xxc;

    }


    public string[] GetMetatags(string pagename)
    {
        SqlConnection con = new SqlConnection(GymsoftConnection());
        string chk = "select * from MetaTags where Page='" + pagename + "'";
        SqlCommand cmd = new SqlCommand(chk, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        string[] array = new string[4];
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                array[0] = rd["page_title"].ToString();
                array[1] = rd["Title"].ToString();
                array[2] = rd["Description"].ToString();
                array[3] = rd["Keywords"].ToString();
            }
            rd.Close();
            con.Close();
        }
        else
        {
            array[0] = " ";
        }

        return array;
    }

    public string GetCurrentPageName()
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
        string[] arr2 = pageName.Split('.');       
        if(arr2.Length==1)
        {
            pageName = pageName + ".aspx";
        }
        return pageName;


    }
}


