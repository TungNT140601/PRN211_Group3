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
    public partial class ViewOrderDetail : Form
    {
        public IOrderRepository OrderRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public TblOrder OrderInfo { get; set; }
        public Member Membert { get; set; }
        public ViewOrderDetail()
        {
            InitializeComponent();
        }

        private void ViewOrderDetail_Load(object sender, EventArgs e)
        {
            txtOrderId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtOrderId.Text = OrderInfo.OrderId.ToString();
                txtMemberId.Text = Membert.MemberId.ToString();
                txtOrderDate.Text = OrderInfo.OrderDate.ToString();
                txtRequiredDate.Text = OrderInfo.RequiredDate.ToString();
                txtShippedDate.Text = OrderInfo.ShippedDate.ToString();
                txtFreight.Text = OrderInfo.Freight.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberDAO memberDAO = new MemberDAO();
            try
            {
                var order = new TblOrder
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    Member = memberDAO.GetMemberByID(int.Parse(txtMemberId.Text)),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepository.AddOrder(order);
                }
                else
                {
                    OrderRepository.UpdateOrder(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order" : "Update a order");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
