using Microsoft.Extensions.Configuration;
using BusinessObject;
using DataAccess;
using DataAccess.Repository;
namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public static string Email = "";
        public static string Password = "";
        private static string GetEmailAdmin()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true)
                .Build();


            return config["AdminAccount:Email"];
        }
        private static string GetPasswordAdmin()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true)
                .Build();


            return config["AdminAccount:Password"];
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string emailAd = GetEmailAdmin();
                string passwordAd = GetPasswordAdmin();
                if (emailAd.Equals(txtEmail.Text))
                {
                    if (passwordAd.Equals(txtPassword.Text))
                    {
                        Email = emailAd;
                        Password = passwordAd;
                        frmMain frm = new frmMain();
                        frm.Show();
                        this.Hide();
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
                        frmMain frm = new frmMain();
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}