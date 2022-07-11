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
using DataAccess.Repositories;
namespace SalesWinApp
{
    public partial class FrmMemberDetail : Form
    {
        public FrmMemberDetail()
        {
            InitializeComponent();
        }
        public IMemberRopository MemberRopository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member MemberInfo { get; set; }
        private void FrmMemberDetail_Load(object sender, EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfo.MemberId.ToString();
                txtEmail.Text = MemberInfo.Email;
                txtCompanyName.Text = MemberInfo.Companyname;
                txtCity.Text = MemberInfo.City;
                txtCountry.Text = MemberInfo.Country;
                txtPassword.Text = MemberInfo.Password;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    Companyname = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                if (InsertOrUpdate == false)
                {
                    var m = new Member();
                    m = MemberRopository.CheckEmail(m.Email);
                    if (m != null)
                    {
                        throw new Exception("Error Email exits!!!!");
                    }
                    else
                    {
                        MemberRopository.AddMember(member);
                    }

                }
                else
                {
                    var m = new Member();
                    m = MemberRopository.CheckEmail(m.Email);
                    if (m != null)
                    {
                        throw new Exception("Error Email exits!!!!");
                    }
                    else
                    {
                        MemberRopository.UpdateMember(member);
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add New Member" : "Update Member");
            }
        }
    }
}
