using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Product Panel
    public partial class StoreAppForm : Form
    {
        public void loadProducts()
        {
            List<Product> products = new List<Product>();
            var query = context.Products.Select(p => p);
            foreach (var product in query)
            {
                products.Add(product);
            }
            ProductDataGrid.DataSource = products;
        }
        private void ProductAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Product newProduct = new Product()
                {
                    ID = int.Parse(ProductIDTextBox_Add.Text),
                    Name = ProductNameTextBox_Add.Text,
                    Manufacture_Date = ProductManuDate_Add.Value,
                    Expiration_Duration = int.Parse(ProductExpirDurTextbox_Add.Text)
                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                loadProducts();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void ProductUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(ProductDataGrid.SelectedCells[0].RowIndex.ToString());
                var productId = ProductDataGrid[0, rowIndex].Value;
                var selectedProduct = context.Products.Find(productId);
                selectedProduct.Name = ProductNameTextbox_Update.Text;
                selectedProduct.Manufacture_Date = ProductManuDate_Update.Value;
                selectedProduct.Expiration_Duration = int.Parse(ProductExpirDur_Update.Text);
                context.SaveChanges();
                loadProducts();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void ProductDeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(ProductDataGrid.SelectedCells[0].RowIndex.ToString());
            var productId = ProductDataGrid[0, rowIndex].Value;
            var selectedProduct = context.Products.Find(productId);
            context.Products.Remove(selectedProduct);
            context.SaveChanges();
            loadProducts();
        }

        private void ProductDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(ProductDataGrid.SelectedCells[0].RowIndex.ToString());
            var productId = ProductDataGrid[0, rowIndex].Value;
            var selectedProduct = context.Products.Find(productId);
            ProductNameTextbox_Update.Text = selectedProduct.Name;
            ProductManuDate_Update.Value = selectedProduct.Manufacture_Date;
            ProductExpirDur_Update.Text = selectedProduct.Expiration_Duration.ToString();
        }
    }
}
