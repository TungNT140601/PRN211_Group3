using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessObject.Models;
using DataAccess.Repositories;

namespace SalesWinApp
{
    public partial class frmSearchProduct : Form
    {
        public frmSearchProduct()
        {
            InitializeComponent();
        }

        public IProductRepository iproductRepository = new ProductRepository();
        public List<Product> Products { get; set; }
        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            txtSearch1.Hide();
            txtSearch2.Hide();
        }
        private int Choose()
        {
            switch (cmbTypeSearch.Text)
            {
                case "Product ID":
                    return 1;
                case "Product Name":
                    return 2;
                case "UnitPrice":
                    return 3;
                case "UnitsInStock":
                    return 4;
            }
            return 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchError errors = new SearchError();
                bool found = false;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                switch (Choose())
                {
                    case 1:
                        string memberId = txtSearch1.Text;
                        if (regex.IsMatch(memberId) == false || memberId.Trim().Equals("") || int.Parse(memberId) < 0)
                        {
                            found = true;
                            errors.memberIdError = "Member ID must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.memberIdError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = new List<Product>();
                            Products.Add(iproductRepository.GetProductByID(Convert.ToInt32(memberId)));
                            
                        }
                        break;
                    case 2:
                        string name = txtSearch1.Text;
                        if (string.IsNullOrEmpty(name) || name.Equals(" "))
                        {
                            found = true;
                            errors.MemberNameError = "name can not be empty";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.MemberNameError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = iproductRepository.GetProductByName(name);
                        }
                        break;
                    case 3:
                        string price1 = txtSearch1.Text;
                        string price2 = txtSearch2.Text;
                        if (regex.IsMatch(price1) == false || price1.Trim().Equals("") || decimal.Parse(price1) < 0)
                        {
                            found = true;
                            errors.UnitPriceError += "price 1 must be the number format and greater than 0!";
                        }
                        if (regex.IsMatch(price2) == false || price2.Trim().Equals("") || decimal.Parse(price2) < 0)
                        {
                            found = true;
                            errors.UnitPriceError += "price 2 must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.UnitPriceError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = iproductRepository.GetProductByPrice(Convert.ToDecimal(price1), Convert.ToDecimal(price2));
                        }
                        break;
                    case 4:
                        string stock1 = txtSearch1.Text;
                        string stock2 = txtSearch2.Text;
                        if (regex.IsMatch(stock1) == false || stock1.Trim().Equals("") || int.Parse(stock1) < 0)
                        {
                            found = true;
                            errors.UnitsInStockError += "units 1 must be the number format and greater than 0!";
                        }
                        if (regex.IsMatch(stock2) == false || stock2.Trim().Equals("") || int.Parse(stock2) < 0)
                        {
                            found = true;
                            errors.UnitsInStockError += "units 2 must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.UnitsInStockError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = iproductRepository.GetProductByStock(Convert.ToInt32(stock1), Convert.ToInt32(stock2));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choose() == 1 || Choose() == 2)
            {
                txtSearch1.Show();
                txtSearch2.Hide();
            }
            else if (Choose() == 3 || Choose() == 4)
            {
                txtSearch1.Show();
                txtSearch2.Show();
            }
        }

        public record SearchError()
        {
            public string? memberIdError { get; set; }
            public string? MemberNameError { get; set; }
            public string? UnitPriceError { get; set; }
            public string? UnitsInStockError { get; set; }

        }
    }
}
