using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repositories;
using BussinessObject.Models;

namespace SalesWinApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        IMemberRopository memberRopository = new MemberRopository();
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Member? member = new Member();
            try
            {
                FStoreContext context = new FStoreContext();
                if (txtEmail.Text.Equals(context.GetAdminEmail()) && txtPassword.Text.Equals(context.GetAdminPassword()))
                {
                    member = new Member()
                    {
                        MemberId = 0,
                        Email = txtEmail.Text,
                        City = "",
                        Companyname = "",
                        Country = "",
                        Password = txtPassword.Text
                    };
                    FrmMain frmMain = new FrmMain()
                    {
                        IsAdmin = true,
                        member = member
                    };
                    this.Hide();
                    frmMain.Show();
                }
                else
                {
                    member = memberRopository.CheckLogin(txtEmail.Text, txtPassword.Text);
                    if (member != null)
                    {
                        FrmMain frmMain = new FrmMain()
                        {
                            IsAdmin = false,
                            member = member
                        };
                        this.Hide();
                        frmMain.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //FStoreContext context = new FStoreContext();
            //txtEmail.Text = context.GetAdminEmail();
            //txtPassword.Text = context.GetAdminPassword();
        }
    }
}
