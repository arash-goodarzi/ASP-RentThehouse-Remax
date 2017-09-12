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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        bool test = false;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserAdmin.Focus();
            //for admin
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
            
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //take the data from textbox
            string user = this.txtUserAdmin.Text.Trim();
            string pass = this.txtPassAdmin.Text.Trim();
            
            //we directly connect to database for validation of username and password for admin(be cause it is not need we create object 
            //ClsGlobal.myAdmin=new ClsAdmin()
            foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Admin"].Rows)
            {
                string username= oneRow["username"].ToString();
                string password= oneRow["password"].ToString();
                if (username == user && password==pass)
                {
                    frmAdmin myAdmin = new frmAdmin();
                    myAdmin.Show();
                    test = true;
                }
            }
            if (test == false)
            {
                MessageBox.Show("Your username or password is wrong");
                txtUserAdmin.Clear();
                txtPassAdmin.Clear();
            }
            test = false;

        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            //take the data from textbox
            string user = this.txtUserAgent.Text.Trim();
            string pass = this.txtPassAgent.Text.Trim();

            foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["Agent"].Rows)
            {
                string username = oneRow["username"].ToString();
                string password = oneRow["password"].ToString();
                if (username == user && password == pass)
                {
                    //fill client in dataset
                    int idClient = Convert.ToInt32( oneRow["Id"]);
                    string sql = "SELECT * FROM Client WHERE agentid=" + idClient ;
                    SqlCommand myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                    ClsGlobal.myAdapterClient = new SqlDataAdapter(myCmd);
                    ClsGlobal.myAdapterClient.Fill(ClsGlobal.myDataSet, "Client");
                    //fill Hous in dataset
                    //int idClient = Convert.ToInt32(oneRow["Id"]);
                    sql = "SELECT * FROM House WHERE agentid=" + idClient;
                    myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                    ClsGlobal.myAdapterHouse = new SqlDataAdapter(myCmd);
                    ClsGlobal.myAdapterHouse.Fill(ClsGlobal.myDataSet, "House");




                    //another form
                    frmAgent myAgent = new frmAgent();
                    myAgent.Show();
                    test = true;
                }
            }
            if (test == false)
            {
                MessageBox.Show("Your username or password is wrong");
                txtUserAgent.Clear();
                txtPassAgent.Clear();
            }


        }
    }
}
