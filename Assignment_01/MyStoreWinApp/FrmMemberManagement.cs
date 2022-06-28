using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class FrmMemberManagement : Form
    {
        public FrmMemberManagement()
        {
            InitializeComponent();
        }

        private void FrmMemberManagement_Load(object sender, EventArgs e)
        {
            txtEmail.Text = FrmLogin.Email;
        }
    }
}
