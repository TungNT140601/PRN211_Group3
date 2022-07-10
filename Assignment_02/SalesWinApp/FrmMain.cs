using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessObject.Models;

namespace SalesWinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public bool IsAdmin { get; set; }
        public Member member { get; set; }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            member = null;
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
