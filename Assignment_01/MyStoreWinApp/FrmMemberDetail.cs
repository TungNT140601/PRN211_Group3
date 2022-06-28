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
        public Boolean InsertOrUpdate { get; set; }

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
                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(member);
                }
                else
                {

                    DialogResult dr = MessageBox.Show("Are you sure you want to update", "Are you sure?", MessageBoxButtons.YesNo); //Gets users input by showing the message box

                    if (dr == DialogResult.Yes) //Creates the yes function
                    {
                        MemberRepository.UpdateMember(member); //Exits off the application

                    }

                    else if (dr == DialogResult.No)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (InsertOrUpdate == false)
            {
                txtPassword.Text = "";

                txtPassword.ForeColor = Color.Black;

                txtPassword.PasswordChar = '●';
            }
        }

        private void FrmMemberDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtCountry.SelectedIndex = txtCountry.FindString(Member.Country);
                txtID.Text = Member.ID.ToString();
                txtName.Text = Member.Name;
                txtEmail.Text = Member.Email;
                txtPassword.Text = Member.Password;
                txtCity.Text = Member.City;
                txtID.ReadOnly = true;
            }
        }
    }
}
