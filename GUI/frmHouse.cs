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
    public partial class frmHouse : Form
    {
        public frmHouse()
        {
            InitializeComponent();
        }

        DataTable tbHouse;
        int current;
        string flag = "";
        ClsHouse myHouseTemp;
        ClsLstHouses myLstHouseTemp = new ClsLstHouses();

        private void Collection2TXT(string indx)
        {
            ClsHouse myHouseTemp = myLstHouseTemp.Find(indx);
            txtAddress.Text = myHouseTemp.HouseAddress;
            txtPostalCode.Text = myHouseTemp.HousePostalCode;
            txtPrice.Text = myHouseTemp.HousePrice.ToString();
            txtSize.Text = myHouseTemp.HouseSize;
            txtType.Text = myHouseTemp.HouseType;
            lblDisplay.Text = "House " + (current) + " on a total of " + myLstHouseTemp.NumberOfHouses;
        }
        private void initialProgram()
        {
            tbHouse = ClsGlobal.myDataSet.Tables["House"];
            current = 1;
            //fill business layer
            string id;
            string address;
            string postalcode;
            int price;
            string size;
            string type;

            foreach (DataRow oneRow in ClsGlobal.myDataSet.Tables["House"].Rows)
            {
                id = oneRow["houseId"].ToString();
                address = oneRow["houseaddress"].ToString();
                postalcode = oneRow["housepostalcode"].ToString();
                price = Convert.ToInt32(oneRow["houseprice"]);
                size = oneRow["housesize"].ToString();
                type = oneRow["housetype"].ToString();
                myHouseTemp = new ClsHouse(type, id, address, postalcode, size, price);
                myLstHouseTemp.Add(myHouseTemp);
            }
            Collection2TXT(current.ToString());
        }

        private void frmHouse_Load(object sender, EventArgs e)
        {
            initialProgram();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            current = 1;

            Collection2TXT(current.ToString());
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            current = myLstHouseTemp.NumberOfHouses;
            Collection2TXT(current.ToString());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            current++;

            if (current > myLstHouseTemp.NumberOfHouses)
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
            txtAddress.Clear();
            txtPostalCode.Clear();
            txtPrice.Clear();
            txtSize.Clear();
            txtType.Clear();

            flag = "add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                ClsHouse myHouseTemp = new ClsHouse();
                current = myLstHouseTemp.NumberOfHouses;
                current++;
                myHouseTemp.HouseID= current.ToString();
                myHouseTemp.HouseAddress = txtAddress.Text;
                myHouseTemp.HousePostalCode = txtPostalCode.Text;
                myHouseTemp.HousePrice = Convert.ToInt32( txtPrice.Text);
                myHouseTemp.HouseSize = txtSize.Text;
                myHouseTemp.HouseType = txtType.Text;

                myLstHouseTemp.Add(myHouseTemp);

                current = myLstHouseTemp.NumberOfHouses;
                Collection2TXT(current.ToString());

                //update database
                DataRow myRow = ClsGlobal.myDataSet.Tables["House"].NewRow();
                myRow["houseid"] = myHouseTemp.HouseID;
                myRow["houseaddress"] = myHouseTemp.HouseAddress;
                myRow["housepostalcode"] = myHouseTemp.HousePostalCode;
                myRow["houseprice"] = myHouseTemp.HousePrice;
                myRow["housesize"] = myHouseTemp.HouseSize;
                myRow["housetype"] = myHouseTemp.HouseType;

                tbHouse.Rows.Add(myRow);
            }
            else
            {

                myLstHouseTemp[current.ToString()].HouseID = current.ToString();
                myLstHouseTemp[current.ToString()].HouseAddress = txtAddress.Text;
                myLstHouseTemp[current.ToString()].HousePostalCode = txtPostalCode.Text;
                myLstHouseTemp[current.ToString()].HousePrice = Convert.ToInt32(txtPrice.Text);
                myLstHouseTemp[current.ToString()].HouseSize = txtSize.Text;
                myLstHouseTemp[current.ToString()].HouseType = txtType.Text;

                Collection2TXT(current.ToString());
            }
            SqlCommandBuilder myBuild = new SqlCommandBuilder(ClsGlobal.myAdapterClient);
            ClsGlobal.myAdapterClient.Update(tbHouse);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txtAddress.Focus();
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
                myLstHouseTemp.Delete(current.ToString());

                current--;
                Collection2TXT(current.ToString());
            }
        }
    }
}
