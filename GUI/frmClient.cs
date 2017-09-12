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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

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
            lblDisplay.Text = "CLient " + (current) + " on a total of " + myLstClientTemp.NumberOfClients;
        }
        private void initialProgram()
        {
            tbClient = ClsGlobal.myDataSet.Tables["Client"];
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


        private void frmClient_Load(object sender, EventArgs e)
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
            current = myLstClientTemp.NumberOfClients;
            Collection2TXT(current.ToString());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            current++;

            if (current > myLstClientTemp.NumberOfClients)
            {
                current--;
            }
            Collection2TXT(current.ToString());
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            current--;

            //TAB2TXT(current);
            if (current < 1)
            {
                current++;
            }
            Collection2TXT(current.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtClientAddress.Clear();
            txtPhoneNumber.Clear();

            flag = "add";
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                tbClient.Rows.Add(myRow);
            }
            else
            {
                
                myLstClientTemp[current.ToString()].Id = current.ToString();
                myLstClientTemp[current.ToString()].FirstName = txtFirstName.Text;
                myLstClientTemp[current.ToString()].LastName = txtLastName.Text;
                myLstClientTemp[current.ToString()].ClientAddress = txtClientAddress.Text;
                myLstClientTemp[current.ToString()].ClientPhoneNumber = txtPhoneNumber.Text;

                Collection2TXT(current.ToString());


            }
            SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterClient);
            ClsGlobal.myAdapterClient.Update(tbClient);
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
                myLstClientTemp.Delete(current.ToString());

                current--;
                Collection2TXT(current.ToString());
            }
        }
    }
}
