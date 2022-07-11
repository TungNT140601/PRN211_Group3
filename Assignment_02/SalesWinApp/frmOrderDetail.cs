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
using BusinessObject.Repository;
using DataAccess.Repositories;

namespace SalesWinApp
{
    public partial class frmOrderDetail : Form
    {
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public BindingSource source;
        public TblOrder OrderInfo { get; set }
        public frmOrderDetail()
        {
            InitializeComponent();
        }
        private void LoadOrderDetailList()
        {
            var orderDetails = orderDetailRepository.GetOrderDetails(OrderInfo.OrderId);
            try
            {
                source = new BindingSource();
                source.DataSource = orderDetails;
                if (orderDetails == null)
                {
                    dgvOrderDetails.DataSource = source;
                    throw new Exception("The Order Detail List is Empty!!!");
                }
                else
                {
                    dgvOrderDetails.DataSource = source;
                    dgvOrderDetails.Columns[5].Visible = false;
                    dgvOrderDetails.Columns[6].Visible = false;
                }
                if (orderDetails.Count() == 0)
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
                MessageBox.Show(ex.Message, "Order Detail Management - Load List Order Detail",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmOrderDetail_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmViewOrderDetai fr = new frmViewOrderDetai();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();
    }
}
