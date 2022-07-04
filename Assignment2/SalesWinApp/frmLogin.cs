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
using Microsoft.Extensions.Configuration;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public static MemberObject member = null;
        IMemberRepository memberRepository = new MemberRepository();
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
                if (txtEmail.Text.Equals(AdminEmail()) && txtPassword.Text.Equals(AdminPassword()))
                {
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else if (mem != null)
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
