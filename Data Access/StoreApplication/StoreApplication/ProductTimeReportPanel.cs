using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Product-Time Report Panel
    public partial class StoreAppForm : Form
    {
        public void loadProductTimeReport(int requiredStoreId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<SupplyPermission> supplyPermissions = new List<SupplyPermission>();
                var query = context.SupplyPermissions
                            .Select(s => s)
                            .Where(s => s.Store_ID == requiredStoreId &&
                                        s.Date >= startDate &&
                                        s.Date <= endDate
                            );
                foreach (var s in query)
                {
                    supplyPermissions.Add(s);
                }
                ProductTimeReport_DataGridView.DataSource = supplyPermissions;
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void ProductTimeReport_DisplayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int requiredStoreId = int.Parse(ProductTimeReport_StoreIdCombobox.SelectedItem.ToString());
                DateTime startDate = ProductTimeReport_FromDate.Value;
                DateTime endDate = ProductTimeReport_ToDate.Value;
                loadProductTimeReport(requiredStoreId, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void ProductTimeReportBtn_Click(object sender, EventArgs e)
        {
            ProductTimeReport_StoreIdCombobox.Items.Clear();
            ProductTimeReportPanel.BringToFront();
            var query = context.Stores.Select(s => s);
            foreach (var store in query)
            {
                ProductTimeReport_StoreIdCombobox.Items.Add(store.ID.ToString());
            }
        }
    }
}
