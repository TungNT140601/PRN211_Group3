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
using Assignment1.Repository;

namespace MyStoreWinApp
{
    public partial class FrmMemberDetail : Form
    {
        public FrmMemberDetail()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public MemberObject Member { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };
                MemberRepository.InsertMember(member);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";

            txtPassword.ForeColor = Color.Black;

            txtPassword.PasswordChar = '●';
        }
    }
}
