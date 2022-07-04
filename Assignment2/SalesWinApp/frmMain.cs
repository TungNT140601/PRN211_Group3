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
using Microsoft.Extensions.Configuration;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        private static MemberObject member = frmLogin.member;
        private static string AdminEmail()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true)
                .Build();
            return config["AdminAccount:Email"];
        }
        private static string AdminPassword()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true)
                .Build();
            return config["AdminAccount:Password"];
        }
        public frmMain()
        {
            InitializeComponent();
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
            frmMembers memberForm = new frmMembers();
            member = null;
            memberForm.MdiParent = this;
            memberForm.Show();
        }

        private void btnAddNewMemberAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (member != null)
            {
                lbHello.Text = "Hello " + member.Email + " !";
                btnAddNewMemberAdmin.Enabled = false;
                btnAddNewProductAdmin.Enabled = false;
                btnViewAllOrderAdmin.Enabled = false;
                btnViewProductAdmin.Enabled = false;
                ProductManagement.Enabled = false;
                orderManagement.Enabled = false;
                memberManagementToolStripMenuItem.Enabled = false;
            }
            else
            {
                lbHello.Text = "Hello " + AdminEmail() + " !";
                btnAddNewMemberAdmin.Enabled = true;
                btnAddNewProductAdmin.Enabled = true;
                btnViewAllOrderAdmin.Enabled = true;
                btnViewProductAdmin.Enabled = true;
                ProductManagement.Enabled = true;
                orderManagement.Enabled = true;
                memberManagementToolStripMenuItem.Enabled = true;
            }
        }

        private void btnViewAllProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
