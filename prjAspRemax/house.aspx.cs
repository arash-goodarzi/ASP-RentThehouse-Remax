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
    public partial class house : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "SELECT * FROM House WHERE agentid=" + Session["idClient"];
                SqlCommand myCmd = new SqlCommand(sql, ClsGlobal.myConnection);

                ClsGlobal.myAdapterHouse = new SqlDataAdapter(myCmd);
                ClsGlobal.myAdapterHouse.Fill(ClsGlobal.myDataSet, "House");
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
            current = myLstHouseTemp.NumberOfHouses;
            Collection2TXT(current.ToString());
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            current++;

            if (current > myLstHouseTemp.NumberOfHouses)
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
            txtAddress.Text="";
            txtPostalCode.Text = "";
            txtPrice.Text = "";
            txtSize.Text = "";
            txtType.Text = "";

            flag = "add";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                ClsHouse myHouseTemp = new ClsHouse();
                current = myLstHouseTemp.NumberOfHouses;
                current++;
                myHouseTemp.HouseID = current.ToString();
                myHouseTemp.HouseAddress = txtAddress.Text;
                myHouseTemp.HousePostalCode = txtPostalCode.Text;
                myHouseTemp.HousePrice = Convert.ToInt32(txtPrice.Text);
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
            else if (flag == "edit")
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            flag = "edit";
            txtAddress.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            initialProgram();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

                myLstHouseTemp.Delete(current.ToString());

                current--;
                Collection2TXT(current.ToString());

        }
    }
}