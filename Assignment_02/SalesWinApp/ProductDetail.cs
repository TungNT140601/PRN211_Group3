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
using DataAccess.Repositories;
namespace SalesWinApp
{
    public partial class ProductDetail : Form
    {
        public ProductDetail()
        {
            InitializeComponent();
        }
        public IProductRepository ProductRepository { get; set; }
        public Product Product { get; set; }
        public bool InsertorUpdate { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategogyId.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitslnStock.Text)
                };
                if (InsertorUpdate == false)
                {
                    ProductRepository.InsertProduct(product);
                }
                else
                {
                    ProductRepository.UpdateProduct(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertorUpdate == false ? "Add new a product" : "Update a product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            txtProductID.ReadOnly = !InsertorUpdate;
            if (InsertorUpdate == true)
            {
                txtProductID.Text = Product.ProductId.ToString();
                txtCategogyId.Text = Product.CategoryId.ToString();
                txtProductName.Text = Product.ProductName;
                txtWeight.Text = Product.Weight;
                txtUnitPrice.Text = Product.UnitPrice.ToString();
                txtUnitslnStock.Text = Product.UnitInStock.ToString();
            }
        }

    }
}
