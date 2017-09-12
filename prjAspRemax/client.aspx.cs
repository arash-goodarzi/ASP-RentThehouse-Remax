using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using prjCsRemax;

namespace prjAspRemax
{
    public partial class agent : System.Web.UI.Page
    {
        //globa variable
        DataTable tbClient;
        int current;
        string flag = "";
        ClsClient myClientTemp;
        ClsLstClients myLstClientTemp = new ClsLstClients();
        private void Collection2TXT(string indx)
        {
            ClsClient myClientTemp = myLstClientTemp.Find(indx);
            txtFirstName.Text = myClientTemp.FirstName;
            txtLastName.Text = myClientTemp.LastName;
            txtClientAddress.Text = myClientTemp.ClientAddress;
            txtPhoneNumber.Text = myClientTemp.ClientPhoneNumber;

        }
        private void initialProgram()
        {
            //tbClient = ClsGlobal.myDataSet.Tables["Client"];
            current = 1;
            //fill business layer
            string id;
            string firstname;
            string lastname;
            string clientAddress;
            string clientPhoneNumber;


            foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Client"].Rows)
            {
                id = oneRow["id"].ToString();
                firstname = oneRow["firstname"].ToString();
                lastname = oneRow["lastname"].ToString();
                clientAddress = oneRow["clientaddress"].ToString();
                clientPhoneNumber = oneRow["clientphonenumber"].ToString();


                myClientTemp = new ClsClient(firstname, lastname, id, clientPhoneNumber, clientAddress);
                myLstClientTemp.Add(myClientTemp);
            }
            Collection2TXT(current.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    //int idClient = Convert.ToInt32( oneRow["Id"]);
                    string sql = "SELECT * FROM Client WHERE agentid=" + Session["idClient"] ;
                    SqlCommand myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                    ClsGlobal.myAdapterClient = new SqlDataAdapter(myCmd);
                    ClsGlobal.myAdapterClient.Fill(ClsGlobal.myDataSet, "Client");
            }
            initialProgram();
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            current = 1;
            Collection2TXT(current.ToString());
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            current = myLstClientTemp.NumberOfClients;
            Collection2TXT(current.ToString());
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            current++;

            if (current > myLstClientTemp.NumberOfClients)
            {
                current--;
            }
            Collection2TXT(current.ToString());
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            current--;

            //TAB2TXT(current);
            if (current < 1)
            {
                current++;
            }
            Collection2TXT(current.ToString());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtClientAddress.Text = "";
            txtPhoneNumber.Text = "";

            flag = "add";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                ClsClient myClientTemp = new ClsClient();
                current = myLstClientTemp.NumberOfClients;
                current++;
                myClientTemp.Id = current.ToString();
                myClientTemp.FirstName = txtFirstName.Text;
                myClientTemp.LastName = txtLastName.Text;
                myClientTemp.ClientAddress = txtClientAddress.Text;
                myClientTemp.ClientPhoneNumber = txtPhoneNumber.Text;
                myClientTemp.AgentId = Convert.ToInt32(Session["idClient"]);
                myLstClientTemp.Add(myClientTemp);

                current = myLstClientTemp.NumberOfClients;
                Collection2TXT(current.ToString());

                //update database
                DataRow myRow = ClsGlobal.myDataSet.Tables["Client"].NewRow();
                myRow["id"] = myClientTemp.Id;
                myRow["firstname"] = myClientTemp.FirstName;
                myRow["lastname"] = myClientTemp.LastName;
                myRow["clientaddress"] = myClientTemp.ClientAddress;
                myRow["clientphonenumber"] = myClientTemp.ClientPhoneNumber;
                myRow["agentid"] = myClientTemp.AgentId;

                tbClient.Rows.Add(myRow);
            }
            else if(flag == "edit")
            {

                myLstClientTemp[current.ToString()].Id = current.ToString();
                myLstClientTemp[current.ToString()].FirstName = txtFirstName.Text;
                myLstClientTemp[current.ToString()].LastName = txtLastName.Text;
                myLstClientTemp[current.ToString()].ClientAddress = txtClientAddress.Text;
                myLstClientTemp[current.ToString()].ClientPhoneNumber = txtPhoneNumber.Text;
                myLstClientTemp[current.ToString()].AgentId = Convert.ToInt32(Session["idClient"]);
                Collection2TXT(current.ToString());


            }
            SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterClient);
            ClsGlobal.myAdapterClient.Update(tbClient);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txtFirstName.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            initialProgram();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            myLstClientTemp.Delete(current.ToString());

            current--;
            Collection2TXT(current.ToString());
        }
    }
}