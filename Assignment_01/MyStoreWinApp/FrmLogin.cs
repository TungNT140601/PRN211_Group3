using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment1.BusinessObject;
using Assignment1.DataAccess;
using Assignment1.Repository;


namespace MyStoreWinApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public static string Email = "";
        public static string Password = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MemberDAO memDao = new MemberDAO();
                MemberObject mem = memDao.CheckLogin(txtEmail.Text.ToString(), txtPassword.Text.ToString());
                if (mem != null)
                {
                    Email = txtEmail.Text.ToString();
                    Password = txtPassword.Text.ToString();
                    FrmMemberManagement frm = new FrmMemberManagement();
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    throw new Exception("Wrong email or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Fail");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";

            txtPassword.ForeColor = Color.Black;

            txtPassword.PasswordChar = '●';
        }

    }
}
