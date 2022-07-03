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
using DataAccess;
using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public static MemberObject member = null;
        IMemberRepository memberRepository = new MemberRepository();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = memberRepository.CheckLogin(txtEmail.Text, txtPassword.Text);
                if (mem != null)
                {
                    member = new MemberObject();
                    member = mem;
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else
                {
                    throw new Exception("Wrong email or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error");
            }
        }
    }
}
