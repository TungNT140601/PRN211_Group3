using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Assignment1.BusinessObject;
using Assignment1.DataAccess;
using Assignment1.Repository;


namespace MyStoreWinApp
{
    public partial class FrmMemberManagement : Form
    {
        FrmLogin frmLogin = new FrmLogin();
        private static string Email = FrmLogin.Email;
        public FrmMemberManagement()
        {
            InitializeComponent();
        }

        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;

        private void FrmMemberManagement_Load(object sender, EventArgs e)
        {
            MemberObject admin = memberRepository.GetAdminAccount();
            if (Email == admin.Email)
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                txtContryFilter.ReadOnly = false;
                txtFilterCity.ReadOnly = false;
                txtSearch.ReadOnly = false;
                btnSearch.Enabled = true;
                btnSort.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSearch.Enabled = false;
                btnSort.Enabled = false;
                txtContryFilter.ReadOnly = true;
                txtFilterCity.ReadOnly = true;
                txtSearch.ReadOnly = true;
                LoadMemberList();
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmMemberDetail frmMemberDetail = new FrmMemberDetail
            {
                Text = "Update member",
                InsertOrUpdate = true,
                Member = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmMemberDetail frmMemberDetail = new FrmMemberDetail
            {
                Text = "Add new Member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<MemberObject> members = (List<MemberObject>)memberRepository.GetMembers();
            List<MemberObject>? pro = new List<MemberObject>();
            foreach (var member in members)
            {
                if (member.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    pro.Add(member);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = pro;

                txtID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ID");
                txtName.DataBindings.Add("Text", source, "Name");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (pro.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Member List");
            }
        }

        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        private void LoadMemberList()
        {
            MemberObject admin = memberRepository.GetAdminAccount();
            var members = memberRepository.GetMembers();
            if (Email == admin.Email)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = members;

                    txtID.DataBindings.Clear();
                    txtName.DataBindings.Clear();
                    txtCountry.DataBindings.Clear();
                    txtCity.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();

                    txtID.DataBindings.Add("Text", source, "ID");
                    txtName.DataBindings.Add("Text", source, "Name");
                    txtCountry.DataBindings.Add("Text", source, "Country");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                    if (members.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                        btnNew.Enabled = true;
                        btnSort.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        btnNew.Enabled = true;
                        btnSort.Enabled = true;
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
                    foreach (var member in members)
                    {
                        if (member.Email == Email)
                        {
                            source = new BindingSource();
                            source.DataSource = member;

                            txtID.DataBindings.Clear();
                            txtName.DataBindings.Clear();
                            txtCountry.DataBindings.Clear();
                            txtCity.DataBindings.Clear();
                            txtEmail.DataBindings.Clear();
                            txtPassword.DataBindings.Clear();

                            txtID.DataBindings.Add("Text", source, "ID");
                            txtName.DataBindings.Add("Text", source, "Name");
                            txtCountry.DataBindings.Add("Text", source, "Country");
                            txtCity.DataBindings.Add("Text", source, "City");
                            txtEmail.DataBindings.Add("Text", source, "Email");
                            txtPassword.DataBindings.Add("Text", source, "Password");

                            dgvMemberList.DataSource = null;
                            dgvMemberList.DataSource = source;
                            btnDelete.Enabled = false;
                            btnNew.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load Member List");
                }
            }
        }

        private void ClearText()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                memberRepository.DeleteMember(member.ID);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete member");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<MemberObject> members = (List<MemberObject>)memberRepository.GetMembers();
            var newList = members.OrderByDescending(x => x.Name).ToList();
            try
            {
                source = new BindingSource();
                source.DataSource = newList;

                txtID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ID");
                txtName.DataBindings.Add("Text", source, "Name");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (newList.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sort Member List");
            }
        }

        private void txtContryFilter_TextChanged(object sender, EventArgs e)
        {
            List<MemberObject> members = (List<MemberObject>)memberRepository.GetMembers();
            List<MemberObject> result = new List<MemberObject>();
            foreach (var member in members)
            {
                if (member.Country.ToLower().Contains(txtContryFilter.Text.ToLower()))
                {
                    result.Add(member);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = result;

                txtID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ID");
                txtName.DataBindings.Add("Text", source, "Name");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (result.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Country");
            }
        }

        private void txtFilterCity_TextChanged(object sender, EventArgs e)
        {
            List<MemberObject> members = (List<MemberObject>)memberRepository.GetMembers();
            List<MemberObject> result = new List<MemberObject>();
            foreach (var member in members)
            {
                if (member.City.ToLower().Contains(txtFilterCity.Text.ToLower()))
                {
                    result.Add(member);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = result;

                txtID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ID");
                txtName.DataBindings.Add("Text", source, "Name");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (result.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter City");
            }
        }
    }
}
