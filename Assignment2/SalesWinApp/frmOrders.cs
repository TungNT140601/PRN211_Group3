﻿using BusinessObject;
using DataAccess;
using DataAccess.Repository;
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
    public partial class frmOrders : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadOrderList();
            
        }
        private void DataGridViewOrders_CellDoubleCleck(object sender, DataGridViewCellEventArgs e)
        {
            OrderDetail orderDetail = new OrderDetail
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

        private OrderObject GetOrderObject()
        {
            MemberDAO memberDAO = new MemberDAO();
            OrderObject orderObject = null;
            try
            {
                orderObject = new OrderObject
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    Member = memberDAO.GetMemberByID(int.Parse(txtMemberId.Text)),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                };

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Order");
            }
            return orderObject;
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
                txtMemberId.DataBindings.Add("Text", source, "Member");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dataGridViewOrders.DataSource = null;
                dataGridViewOrders.DataSource = source;

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
            OrderDetail orderDetail = new OrderDetail
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
            OrderDetail orderDetail = new OrderDetail
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
