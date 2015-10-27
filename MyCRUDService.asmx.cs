using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CRUD_ServiceForIOS
{
    /// <summary>
    /// Summary description for MyCRUDService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyCRUDService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(@"Data Source=TOPS49\SQLEXPRESS;Initial Catalog=MyIOSServiceDB;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string InsertNewUser(string FirstName,string LastName)
        {
            string Status = "";

            cmd = new SqlCommand("insert into userinfo values(@Fname,@Lname)",con);
            cmd.Parameters.AddWithValue("@Fname",FirstName);
            cmd.Parameters.AddWithValue("@Lname", LastName);
            con.Open();
            Status= cmd.ExecuteNonQuery().ToString();
            con.Close();

            if(Status!="")
            {
                return "Record Saved";
            }
            else
            {
                return "There should be Error";
            }
        }

        [WebMethod]
        public DataTable GetAllUsers()
        {
            da = new SqlDataAdapter("select * from userinfo",con);
            dt = new DataTable("userinfo");
            da.Fill(dt);
            return dt;
        }
    }
}
