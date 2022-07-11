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
    public partial class FrmMember : Form
    {
        public FrmMember()
        {
            InitializeComponent();
        }
        IMemberRopository memberRopository = new MemberRopository();
        BindingSource source;
        public Member Member { get; set; }
        public bool IsAdmin { get; set; }
        private void FrmMember_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void LoadListMembers()
        {
            if (IsAdmin == true)
            {
                var members = memberRopository.GetMembers();
                try
                {
                    source = new BindingSource();
                    source.DataSource = members;

                    txtMemberID.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtCompanyName.DataBindings.Clear();
                    txtCity.DataBindings.Clear();
                    txtCountry.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();


                    txtMemberID.DataBindings.Add("Text", source, "MemberID");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtCountry.DataBindings.Add("Text", source, "Country");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;

                    if (members.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load Member List");
                }
            }
            else
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = Member;

                    txtMemberID.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtCompanyName.DataBindings.Clear();
                    txtCity.DataBindings.Clear();
                    txtCountry.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();


                    txtMemberID.DataBindings.Add("Text", source, "MemberID");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtCountry.DataBindings.Add("Text", source, "Country");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                    btnUpdate.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load Member List");
                }
            }
        }
        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        private Member GetMembers()
        {
            Member? m = null;
            try
            {
                m = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    Companyname = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Members");
            }
            return m;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadListMembers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = GetMembers();
                memberRopository.DeleteMember(mem.MemberId);
                LoadListMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Member");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmMemberDetail memberDetail = new FrmMemberDetail
            {
                Text = "Add New Member",
                InsertOrUpdate = false,
                MemberRopository = memberRopository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmMemberDetail memberDetail = new FrmMemberDetail
            {
                Text = "Update New Member",
                InsertOrUpdate = true,
                MemberInfo = GetMembers(),
                MemberRopository = memberRopository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmMemberDetail memberDetail = new FrmMemberDetail
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMembers(),
                MemberRopository = memberRopository
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListMembers();
            }
        }
    }
}
