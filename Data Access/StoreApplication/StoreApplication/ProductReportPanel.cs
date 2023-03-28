using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Product Report Panel
    public partial class StoreAppForm : Form
    {
        public void loadProductReport(int requiredProductId,int requiredStoreId, DateTime startDate , DateTime endDate)
        {
            try
            {
                List<Product> products = new List<Product>();
                var query = context.SupplyPermissions
                            .Select(s => s)
                            .Where(s => s.Store_ID == requiredStoreId &&
                                        s.Product_ID == requiredProductId &&
                                        s.Date >= startDate &&
                                        s.Date <= endDate
                            );
                foreach (var s in query)
                {
                    Product requiredProduct = context.Products.Find(s.Product_ID);
                    products.Add(requiredProduct);
                }
                ProductReport_DataGridView.DataSource = products;
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void ProductReport_DisplayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int requiredStoreId = int.Parse(ProductReport_StoreIdCombobox.SelectedItem.ToString());
                int requiredProductId = int.Parse(ProductReport_IdCombobox.SelectedItem.ToString());
                DateTime startDate = ProductReport_FromDate.Value;
                DateTime endDate = ProductReport_ToDate.Value;
                loadProductReport(requiredProductId,requiredStoreId, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void ProductReportPanelBtn_Click(object sender, EventArgs e)
        {
            ProductReport_IdCombobox.Items.Clear();
            ProductReportPanel.BringToFront();
            var query = context.Products.Select(p => p);
            foreach (var product in query)
            {
                ProductReport_IdCombobox.Items.Add(product.ID);
            }
        }
        private void ProductReport_IdCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductReport_StoreIdCombobox.Items.Clear();
            var requiredProductId= int.Parse(ProductReport_IdCombobox.SelectedItem.ToString());
            var query = context.SupplyPermissions.Select(s => s).Where(s => s.Product_ID == requiredProductId);
            foreach (var s in query)
            {
                ProductReport_StoreIdCombobox.Items.Add(s.Store_ID);
            }
            var requiredProduct = context.Products.Find(requiredProductId);
            ProductReport_NameTextbox.Text = requiredProduct.Name;
            ProductReport_ManuDate.Value = requiredProduct.Manufacture_Date;
            ProductReport_ExpirDurTextbox.Text = requiredProduct.Expiration_Duration.ToString();
        }
    }

}
