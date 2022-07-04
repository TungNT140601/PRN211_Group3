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

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }
        private void LoadProductList()
        {
            var products = productRepository.GetProducts();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car List");
            }
        }
    }
}
