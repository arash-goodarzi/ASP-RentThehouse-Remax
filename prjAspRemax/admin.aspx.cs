using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using prjCsRemax;
using System.Data;

namespace prjAspRemax
{
    public partial class admin : System.Web.UI.Page
    {
        //globa variable
        DataTable tbAgent;
        static int current;
        static string flag;
        ClsAgent myAgentTemp;
        ClsLstAgents myLstAgentTemp = new ClsLstAgents();

        //method
        private void Collection2TXT(string indx)
        {
            ClsAgent myAgentTemp = myLstAgentTemp.Find(indx);
            txtFirstName.Text = Convert.ToString( myAgentTemp.FirstName);
            txtLastName.Text = Convert.ToString(myAgentTemp.LastName);
            txtUserName.Text = Convert.ToString(myAgentTemp.Username);
            txtPassword.Text = Convert.ToString(myAgentTemp.Password);
            txtPhone.Text = Convert.ToString(myAgentTemp.Phone);
        }

        private void initialProgram()
        {
            tbAgent = ClsGlobal.myDataSet.Tables["Agent"];
            
            //TAB2TXT(current);
            //fill business layer
            string id;
            string firstname;
            string lastname;
            string username;
            string password;
            string phone;
            string position = "Agent";
            int houseId;
            int clientId;


            foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Agent"].Rows)
            {
                id = oneRow["id"].ToString();
                firstname = oneRow["firstname"].ToString();
                lastname = oneRow["lastname"].ToString();
                username = oneRow["username"].ToString();
                password = oneRow["password"].ToString();
                phone = oneRow["phone"].ToString();
                clientId = Convert.ToInt32(oneRow["clientId"]);
                houseId = Convert.ToInt32(oneRow["houseId"]);

                myAgentTemp = new ClsAgent(firstname, lastname, id, username, password, position, phone, clientId, houseId);
                myLstAgentTemp.Add(myAgentTemp);
            }
            Collection2TXT(current.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                flag = "";
                current = 1;
                var user = Request.QueryString["txtUsernameAdmin"];
                string pass = Request.QueryString["txtPasswordAdmin"];


                ClsGlobal.myConnection = new SqlConnection(@"Data Source=K-PAX;Initial Catalog=backupRemax;Integrated Security=True");
                string sql = "SELECT * FROM Admin";
                SqlCommand myCmd = new SqlCommand(sql, ClsGlobal.myConnection);
                ClsGlobal.myAdapterAdmin = new SqlDataAdapter(myCmd);
                ClsGlobal.myDataSet = new DataSet();
                ClsGlobal.myAdapterAdmin.Fill(ClsGlobal.myDataSet, "Admin");

                //for agent
                sql = "SELECT * FROM Agent";
                myCmd = new SqlCommand(sql, ClsGlobal.myConnection);
                ClsGlobal.myAdapterAgent = new SqlDataAdapter(myCmd);
                ClsGlobal.myAdapterAgent.Fill(ClsGlobal.myDataSet, "Agent");


                bool userExist = false;
                foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Admin"].Rows)
                {
                    string username = oneRow["username"].ToString();
                    string password = oneRow["password"].ToString();
                    if (username == user && password == pass)
                    {
                        Session["adminId"] = oneRow["Id"].ToString();
                        userExist = true;
                    }
                }
                if (userExist == false)
                {
                    Response.Redirect("test.aspx");
                }
            }
            else
            {
                
            }
            initialProgram();
            Label1.Text = current.ToString();
            Label2.Text = myLstAgentTemp.NumberOfAgents.ToString();
            GridView1.DataSource = myLstAgentTemp.Agents;
            GridView1.DataBind();

        }
        
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            current = 1;
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            current = myLstAgentTemp.NumberOfAgents;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            current++;
            if (current > myLstAgentTemp.NumberOfAgents)
            {
                current--;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            current--;
            if (current < 1)
            {
                current++;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";

            flag = "add";
            current = (myLstAgentTemp.NumberOfAgents + 1);
            Label1.Text = current.ToString();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                ClsAgent myAgentTemp = new ClsAgent();
                //Label1.Text = current.ToString();
                current = myLstAgentTemp.NumberOfAgents;
                //Label2.Text = current.ToString();
                myAgentTemp.Id = current.ToString();
                myAgentTemp.FirstName = txtFirstName.Text;
                myAgentTemp.LastName = txtLastName.Text;
                myAgentTemp.Username = txtUserName.Text;
                myAgentTemp.Password = txtPassword.Text;
                myAgentTemp.Phone = txtPhone.Text;
                myAgentTemp.Position = txtPosition.Text;
                myAgentTemp.HouseId = 0;
                myAgentTemp.ClientId = 0;
                ListBox1.Items.Add(myAgentTemp.ToString());
                myLstAgentTemp.Add(myAgentTemp);

                current = myLstAgentTemp.NumberOfAgents;
                Collection2TXT(current.ToString());
                
            }
            else if (flag == "edit")
            {
                myLstAgentTemp[current.ToString()].Id = current.ToString();
                myLstAgentTemp[current.ToString()].FirstName = txtFirstName.Text;
                myLstAgentTemp[current.ToString()].LastName = txtLastName.Text;
                myLstAgentTemp[current.ToString()].Username = txtUserName.Text;
                myLstAgentTemp[current.ToString()].Password = txtPassword.Text;
                myLstAgentTemp[current.ToString()].Phone = txtPhone.Text;
                myLstAgentTemp[current.ToString()].Position = txtPosition.Text;
                Collection2TXT(current.ToString());
            }

            SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterAgent);
            ClsGlobal.myAdapterAgent.Update(tbAgent);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txtFirstName.Focus();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            initialProgram();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
                myLstAgentTemp.Delete(current.ToString());
                current--;
                Collection2TXT(current.ToString());
        }
    }
}