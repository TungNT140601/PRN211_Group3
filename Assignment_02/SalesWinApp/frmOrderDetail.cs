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
using DataAccess;
using DataAccess.Repositories;

namespace SalesWinApp
{
    public partial class frmOrderDetail : Form
    {
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public IOrderRepository orderRepository = new OrderRepository();
        public BindingSource source;
        public TblOrder OrderInfo { get; set; }
        public frmOrderDetail()
        {
            InitializeComponent();
        }
        private void ClearText()
        {
            txtOrderID.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscount.Text = string.Empty;

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
            int orderID = int.Parse(txtOrderID.Text);
            int productID = int.Parse(cbProduct.Text);
            try
            {
                orderDetailRepository.DeleteOrderDetail(orderID, productID);
                LoadOrderDetailList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a order detail - Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmViewOrderDetail frmViewOrderDetail = new frmViewOrderDetail
            {
                Text = "Add a order",
                InsertOrUpdate = false,
                OrderDetailRepository = orderDetailRepository
            };
            if (frmViewOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderDetailList();
                source.Position = source.Count - 1;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            //dgvOrderDetails.CellDoubleClick += DgvOrderDetails_CellDoubleClick;
            LoadOrderDetailList();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private OrderDetail GetOrderDetailObject()
        {
            OrderDetail? orderDetail = null;
            try
            {
                IOrderRepository orderRepository = new OrderRepository();
                IProductRepository productRepository = new ProductRepository();
                orderDetail = new OrderDetail
                {
                    Order = orderRepository.GetOrderByID(int.Parse(txtOrderID.Text)),
                    Product = productRepository.GetProductByID(int.Parse(cbProduct.Text)),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = double.Parse(txtDiscount.Text),
                    UnitPrice = decimal.Parse(txtPrice.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order Detail");
            }
            return orderDetail;
        }
        private void DgvOrderDetails_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmViewOrderDetail frmViewOrderDetail = new frmViewOrderDetail
            {
                Text = "Update a order detail",
                InsertOrUpdate = true,
                OrderDetailInfo = GetOrderDetailObject(),
                OrderDetailRepository = orderDetailRepository
            };
            if (frmViewOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderDetailList();
                source.Position = source.Count - 1;
            }
        }

        private void dgvOrderDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtOrderID.Clear();
            txtPrice.Clear();
            txtDiscount.Clear();
            txtQuantity.Clear();
            txtOrderID.Text = dgvOrderDetails.Rows[index].Cells[0].Value.ToString();
            cbProduct.Text = dgvOrderDetails.Rows[index].Cells[1].Value.ToString();
            txtDiscount.Text = dgvOrderDetails.Rows[index].Cells[4].Value.ToString();
            txtQuantity.Text = dgvOrderDetails.Rows[index].Cells[3].Value.ToString();
            txtPrice.Text = dgvOrderDetails.Rows[index].Cells[2].Value.ToString();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dgvOrderDetails_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
