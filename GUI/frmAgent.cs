using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjCsRemax.GUI
{
    public partial class frmAgent : Form
    {
        public frmAgent()
        {
            InitializeComponent();
        }

        private void btnHoudes_Click(object sender, EventArgs e)
        {
            frmHouse myHouse = new frmHouse();
            myHouse.Show();
        }

        private void houseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHouse myHouse = new frmHouse();
            myHouse.Show();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClient myClient = new frmClient();
            myClient.Show();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            frmClient myClient = new frmClient();
            myClient.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgent_Load(object sender, EventArgs e)
        {

        }
    }
}
