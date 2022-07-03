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
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }

        public IProductRepository ProductRepository { get; set; }
        public ProductObject Product { get; set; }  
        public Boolean InsertorUpdate { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new ProductObject
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = txtUnitPrice.Text,
                    UnitslnStock = int.Parse(txtUnitslnStock.Text)
                };
                if(InsertorUpdate == false)
                {
                    ProductRepository.InsertPro(product);
                }
                else
                {
                    ProductRepository.UpdatePro(product);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,InsertorUpdate==false?"Add new a product": "Update a product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            if(InsertorUpdate == true)
            {
                txtCategoryId.Text = Product.ProductId.ToString();
                txtProductName.Text = Product.ProductName;
                txtCategoryId.Text = Product.CategoryId.ToString();
                txtWeight.Text = Product.Weight;
                txtUnitPrice.Text = Product.UnitPrice;
                txtUnitslnStock.Text = Product.UnitslnStock.ToString();
                txtProductID.ReadOnly = true;
            }    
        }
    }
}
