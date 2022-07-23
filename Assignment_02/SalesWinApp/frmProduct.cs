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
        public bool IsAdmin { get; set; }
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
            txtUnitsInStock.Text = string.Empty;
        }

        // Get Products 
        private Product GetProductObject()
        {

            Product? product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCategogyId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitsInStock.Text),
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
            var products = productRepository.GetProductList();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtProductID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtCategogyId.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtCategogyId.DataBindings.Add("Text", source, "CategoryId");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitsInStock.DataBindings.Add("Text", source, "UnitInStock");

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





        //Add Products
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
        //Delete Products
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var product = GetProductObject();
                productRepository.DeleteProduct(product.ProductId);
                var members1 = productRepository.GetProductList();
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        //update Products
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDetail frmProductDetails = new ProductDetail
            {
                Text = "Update products",
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

        private void LoadProductList(List<Product> products)
        {
            try
            {


                source = new BindingSource();
                source.DataSource = products;
                txtProductID.DataBindings.Clear();
                txtCategogyId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategogyId.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitsInStock.DataBindings.Add("Text", source, "UnitInStock");

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
                MessageBox.Show(ex.Message);
            }
        }

        //search Products
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchProduct frmSearchProduct = new frmSearchProduct();
            if (frmSearchProduct.ShowDialog() == DialogResult.OK)
            {
                List<Product> products = new List<Product>();
                LoadProductList(products);
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
