using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjCsRemax.GUI
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        //globa variable
        DataTable tbAgent;
        int current;
        string flag;
        ClsAgent myAgentTemp;
        ClsLstAgents myLstAgentTemp = new ClsLstAgents();

        //method
        private void Collection2TXT(string indx)
        {
            ClsAgent myAgentTemp = myLstAgentTemp.Find(indx);
            txtFirstName.Text = myAgentTemp.FirstName.ToString();
            txtLastName.Text =myAgentTemp.LastName;
            txtUserName.Text = myAgentTemp.Username;
            txtPassword.Text =myAgentTemp.Password;
            txtPhone.Text = myAgentTemp.Phone;
            lblDisplay.Text = "Agent " + (current) + " on a total of " + myLstAgentTemp.NumberOfAgents;
        }



        //private void TAB2TXT(int indx)
        //{
        //    txtFirstName.Text = tbAgent.Rows[indx]["firstname"].ToString();
        //    txtLastName.Text = tbAgent.Rows[indx]["lastname"].ToString();       
        //    txtUserName.Text = tbAgent.Rows[indx]["username"].ToString();
        //    txtPassword.Text = tbAgent.Rows[indx]["password"].ToString();
        //    txtPhone.Text = tbAgent.Rows[indx]["phone"].ToString();

        //    lblDisplay.Text = "Agent " + (current + 1) + " on a total of " + tbAgent.Rows.Count;
        //}

        private void initialProgram()
        {
            tbAgent = ClsGlobal.myDataSet.Tables["Agent"];
            current = 1;
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

                myAgentTemp = new ClsAgent(firstname, lastname, id, username, password, position, phone,clientId,houseId);
                myLstAgentTemp.Add(myAgentTemp);
            }
            Collection2TXT(current.ToString());
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
           
            initialProgram();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            current = 1;
            //TAB2TXT(current);
            Collection2TXT(current.ToString());
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //current = tbAgent.Rows.Count-1;
            //TAB2TXT(current);
            current = myLstAgentTemp.NumberOfAgents;
            Collection2TXT(current.ToString());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            current++;
            //if (current>tbAgent.Rows.Count-1)
            //{
            //    current--;
            //}
            //TAB2TXT(current);
            if (current > myLstAgentTemp.NumberOfAgents)
            {
                current--;
            }
            Collection2TXT(current.ToString());
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            current--;
            //if (current<0)
            //{
            //    current++;
            //}
            //TAB2TXT(current);
            if (current<1)
            {
                current++;
            }
            Collection2TXT(current.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();

            flag = "add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag=="add")
            {
                ClsAgent myAgentTemp = new ClsAgent();
                current = myLstAgentTemp.NumberOfAgents;
                current++;
                myAgentTemp.Id = current .ToString();
                myAgentTemp.FirstName = txtFirstName.Text;
                myAgentTemp.LastName = txtLastName.Text;
                myAgentTemp.Username = txtUserName.Text;
                myAgentTemp.Password = txtPassword.Text;
                myAgentTemp.Phone = txtPhone.Text;
                myAgentTemp.Position = txtPosition.Text;
                myLstAgentTemp.Add(myAgentTemp);

                current = myLstAgentTemp.NumberOfAgents;
                Collection2TXT(current.ToString());

                //update database
                DataRow myRow=ClsGlobal.myDataSet.Tables["Agent"].NewRow();
                myRow["id"] = myAgentTemp.Id;
                myRow["firstname"] = myAgentTemp.FirstName;
                myRow["lastname"] = myAgentTemp.LastName;
                myRow["username"] = myAgentTemp.Username;
                myRow["password"] = myAgentTemp.Password;
                myRow["phone"] = myAgentTemp.Phone;
                myRow["position"] = myAgentTemp.Position;
                 myRow["clientId"]= 0;
                 myRow["houseId"] = 0;
                tbAgent.Rows.Add(myRow);


                
            }
            else
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txtFirstName.Focus();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            initialProgram();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes))
            { 
                myLstAgentTemp.Delete(current.ToString());
            
                current--;
                Collection2TXT(current.ToString());

                //ClsGlobal.myDataSet.Tables["Agent"].Rows[current].Delete(); //tbAgent.Rows[current].Delete();
                //current = 1;
                //Collection2TXT(current.ToString());



                //SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterAgent);
                //ClsGlobal.myAdapterAgent.Update(ClsGlobal.myDataSet.Tables["Agent"]);
            }
            //SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterAgent);
            //ClsGlobal.myAdapterAgent.Update(tbAgent);
            //current = 1;

        }
    }
}
