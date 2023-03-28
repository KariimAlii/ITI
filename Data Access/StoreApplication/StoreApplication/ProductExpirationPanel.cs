using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Product-Expiration Report Panel
    public partial class StoreAppForm : Form
    {
        private void ProductExpReport_DisplayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int requiredPeriodInMonths = int.Parse(ProductExpReport_PeriodTextbox.Text);
                TimeSpan expirationPeriod = new TimeSpan(requiredPeriodInMonths * 30, 0, 0, 0);
                DateTime endDate = currentDate + expirationPeriod;
                List<Product> expiredProducts = new List<Product>();
                var productList = context.Products.Select(p => p).ToList();
                foreach (var product in productList)
                {
                    if ((product.Manufacture_Date + new TimeSpan(product.Expiration_Duration * 30, 0, 0, 0)) >= endDate)
                    {
                        expiredProducts.Add(product);
                    }
                }
                ProductExpReport_DataGridView.DataSource = expiredProducts;
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void ProductExpirationReportBtn_Click(object sender, EventArgs e)
        {
            ProductExpirationPanel.BringToFront();
        }
    }
}
