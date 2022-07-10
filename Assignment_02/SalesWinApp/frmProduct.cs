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
    public partial class frmProduct : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;
        public frmProduct()
        {
            InitializeComponent();
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductDetail frmProductDetails = new ProductDetail
            {
                Text = "Update product",
                InsertorUpdate = true,
                Product = GetProductObject(),
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearText()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtCategogyId.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitslnStock.Text = string.Empty;
        }

        // Get Products 
        private Product GetProductObject()
        {

            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategogyId.Text),
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitslnStock.Text),
                    Weight = txtWeight.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get products");
            }
            return product;
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        // Load List Products
        public void LoadProductList()
        {
            var products = productRepository.GetProducts();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtProductID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtCategogyId.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtCategogyId.DataBindings.Add("Text", source, "CategoryId");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                if (products.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        // Hàm Add Products
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductDetail frmProductDetails = new ProductDetail
            {
                Text = "Add a new product",
                InsertorUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }
        // Hàm Delete Products
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var product = GetProductObject();
                productRepository.DeleteProduct(product.ProductId);
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        // Hàm update Products
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDetail frmProductDetails = new ProductDetail
            {
                Text = "Update products",
                InsertorUpdate = true,
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        // Hàm search Products
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Product> products = (List<Product>)productRepository.GetProducts();
            List<Product>? pro = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductName.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    pro.Add(product);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = pro;

                txtProductID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                if (pro.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Search Product List");
            }
        }
    }
}
