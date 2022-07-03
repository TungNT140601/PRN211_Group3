using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails
            {
                Text = "Update product",
                InsertorUpdate = true,
                Product = GetProductObject(),
                ProductRepository = productRepository
            };
            if(frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }    
        }
        private void ClearText()
        {
            txtProductId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtCategoryId.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitslnStock.Text = string.Empty;
        }

        private ProductObject GetProductObject(){

            ProductObject product = null;
            try
            {
                product = new ProductObject
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    UnitPrice = txtUnitPrice.Text,
                    UnitslnStock = int.Parse(txtUnitslnStock.Text),
                    Weight = txtWeight.Text,
                };  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get products");
            }
            return product;
        }

        public void LoadProductList()
        {
            var products = productRepository.GetProducts();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtProductId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();

                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                if(products.Count() == 0)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails
            {
                Text = "Add product",
                InsertorUpdate = false,
                ProductRepository = productRepository
            };
            if(frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var product = GetProductObject();
                productRepository.DeletePro(product.ProductId);
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var product = GetProductObject();
        //        productRepository.UpdatePro(product.ProductId, product.ProductName, product.CategoryId, product.Weight, product.UnitPrice, product.UnitslnStock);
        //        LoadProductList();       
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Update product");
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductObject> products = (List<ProductObject>)productRepository.GetProducts();
            List<ProductObject>? pro = new List<ProductObject>();
            foreach(var product in products)
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

                txtProductId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitslnStock.DataBindings.Clear();

                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitslnStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                if(pro.Count() == 0)
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
