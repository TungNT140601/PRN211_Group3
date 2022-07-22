using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
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
        IMemberRepository memberRepository = new MemberRepository();
        public static string Email = "";
        public static string Password = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MemberObject admin = memberRepository.GetAdminAccount();
                if (admin.Email.Equals(txtEmail.Text))
                {
                    if (admin.Password.Equals(txtPassword.Text))
                    {
                        Email = admin.Email;
                        Password = admin.Password;
                        FrmMemberManagement frm = new FrmMemberManagement();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        throw new Exception("Wrong email or password.");
                    }
                }
                else
                {
                    MemberDAO memDao = new MemberDAO();
                    MemberObject? mem = memDao.CheckLogin(txtEmail.Text.ToString(), txtPassword.Text.ToString());
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

