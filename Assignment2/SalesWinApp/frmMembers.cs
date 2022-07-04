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

                dgvMember.DataSource = null;
                dgvMember.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car List");
            }
        }
    }
}
