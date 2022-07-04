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
    public partial class frmMembers : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;
        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            LoadListMembers();
        }

        private void LoadListMembers()
        {
            var members = memberRepository.GetMemberList();
            try
            {
                source = new BindingSource();
                source.DataSource = members;

                txtMemberID.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();


                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMember.DataSource = null;
                dgvMember.DataSource = source;

                if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car List");
            }
        }
        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        private MemberObject GetMember()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    City = txtCity.Text,
                    CompanyName = txtCompanyName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Country = txtCountry.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetail memberDetail = new frmMemberDetail
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmMemberDetail memberDetail = new frmMemberDetail
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMember(),
                MemberRepository = memberRepository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadListMembers();
        }

        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail memberDetail = new frmMemberDetail
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMember(),
                MemberRepository = memberRepository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }
    }
}
