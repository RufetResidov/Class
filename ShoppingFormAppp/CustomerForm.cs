using ShoppingFormAppp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingFormAppp
{
    public partial class CustomerForm : Form
    {
        ShoppingContext db = new ShoppingContext();
        Product selectedProduct;
        User activeUser;
        public CustomerForm(User us)
        {
            activeUser = us;
            InitializeComponent();
        }
        public void FillCategoryCombo()
        {
            cmbCategories.Items.AddRange(db.Categories.Select(x => x.Fullname).ToArray());
        }
        public void FillOrderListGrid()
        {
            dtgSellCustomer.DataSource = db.Orders.Select(x => new { 
            x.Product.Name,
            x.Count,
            x.PurchaseDate,
            x.TotalPrice
            }).ToList();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "SalamCoder " +activeUser.Fullname;
            FillCategoryCombo();
            FillOrderListGrid();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrice.Visible = false;
            cmbProducts.Text = "";
            string categoryName = cmbCategories.Text;
            int catId = db.Categories.FirstOrDefault(x => x.Fullname == categoryName).Id;
            var productList = db.Products.Where(x => x.CategoryId == catId).Select(x => x.Name).ToArray();
            cmbProducts.Items.Clear();
            cmbProducts.Items.AddRange(productList);

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = db.Products.FirstOrDefault(x => x.Name == cmbProducts.Text);
            lblPrice.Text = selectedProduct.Price + "Azn";
            lblPrice.Visible = true;
        }

    

        private void nmQuantity_ValueChanged_1(object sender, EventArgs e)
        {
            nmQuantity.Maximum = (decimal)selectedProduct.Quantity;
            lblPrice.Text = selectedProduct.Price * nmQuantity.Value + "Azn";

        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Order ord = new()
            {
                UserId = activeUser.Id,
                ProductId = selectedProduct.Id,
                Count = (int)nmQuantity.Value,
                PurchaseDate = DateTime.Now,
                TotalPrice =(decimal)(selectedProduct.Price*nmQuantity.Value)
            };
            selectedProduct.Quantity -= (int)nmQuantity.Value;
            db.Orders.Add(ord);
            db.SaveChanges();
            MessageBox.Show("Product sell succesfully", "succesfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       
    }
}
