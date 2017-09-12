using prjCsRemax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjAspRemax
{
    public partial class agent1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var user = Request.QueryString["txtUsernameAgent"];
                string pass = Request.QueryString["txtPasswordAgent"];
                //
                ClsGlobal.myConnection = new SqlConnection(@"Data Source=K-PAX;Initial Catalog=backupRemax;Integrated Security=True");
                string sql = "SELECT * FROM Agent";
                SqlCommand myCmd = new SqlCommand(sql, ClsGlobal.myConnection);
                ClsGlobal.myAdapterAgent = new SqlDataAdapter(myCmd);
                ClsGlobal.myDataSet = new DataSet();
                ClsGlobal.myAdapterAgent.Fill(ClsGlobal.myDataSet, "Agent");


                bool userExist = false;


                foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Agent"].Rows)
                {
                    string username = oneRow["username"].ToString();
                    string password = oneRow["password"].ToString();
                    if (username == user && password == pass)
                    {
                        //fill client in dataset
                        int idClient = Convert.ToInt32(oneRow["Id"]);
                        Session["idClient"] = idClient;
                        sql = "SELECT * FROM Client WHERE agentid=" + idClient;
                        myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                        ClsGlobal.myAdapterClient = new SqlDataAdapter(myCmd);
                        ClsGlobal.myAdapterClient.Fill(ClsGlobal.myDataSet, "Client");
                        //fill Hous in dataset
                        //int idClient = Convert.ToInt32(oneRow["Id"]);
                        sql = "SELECT * FROM House WHERE agentid=" + idClient;
                        myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                        ClsGlobal.myAdapterHouse = new SqlDataAdapter(myCmd);
                        ClsGlobal.myAdapterHouse.Fill(ClsGlobal.myDataSet, "House");

                        userExist = true;
                    }
                }
                if (userExist == false)
                {
                    Response.Redirect("test.aspx");
                }
            }
        }


    }
}