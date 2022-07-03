using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        private static MemberObject member = frmLogin.member;
        public frmMain()
        {
            InitializeComponent();
        }

        private void viewAllProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnViewProductAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewProductAdmin_Click(object sender, EventArgs e)
        {

        }

        private void viewHistoryOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnViewAllOrderAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnViewAllMemberAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewMemberAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbHello.Text = "Hello " + member.City + " !";
        }
    }
}
