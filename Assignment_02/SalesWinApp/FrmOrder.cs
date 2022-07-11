using BussinessObject.Models;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class FrmOrder : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;
        public bool IsAdmin { get; set; }
        public Member Member { get; set; }
        public FrmOrder()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewOrderDetail orderDetail = new ViewOrderDetail
            {
                Text = "Update order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository

            };
            if (orderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
            }
        }

        private void ClearText()
        {
            txtOrderId.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
            txtFreight.Text = string.Empty;
        }

        private TblOrder GetOrderObject()
        {
            TblOrder tblorder = null;
            MemberDAO memberDAO = new MemberDAO();
            try
            {
                tblorder = new TblOrder
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    Member = Member,
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                };

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Order");
            }
            return tblorder;
        }

        public void LoadOrderList()
        {
            var orders = orderRepository.GetOrders();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtOrderId.DataBindings.Clear();
                txtMemberId.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderId.DataBindings.Add("Text", source, "OrderId");
                txtMemberId.DataBindings.Add("Text", source, "Member.MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dataGridViewOrder.DataSource = null;
                dataGridViewOrder.DataSource = source;

                if (orders.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Load order list");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var order = GetOrderObject();
                orderRepository.DeleteOrder(order.OrderId);
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ViewOrderDetail orderDetail = new ViewOrderDetail
            {
                Text = "Add order",
                InsertOrUpdate = false,
                OrderRepository = orderRepository

            };
            if (orderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ViewOrderDetail orderDetail = new ViewOrderDetail
            {
                Text = "Update order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository

            };
            if (orderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
            }
        }
    }
}
