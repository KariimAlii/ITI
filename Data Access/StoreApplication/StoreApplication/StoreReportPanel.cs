using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Store Report Panel
    public partial class StoreAppForm : Form
    {
        private void StoreReportPanelBtn_Click(object sender, EventArgs e)
        {
            StoreReport_IdCombobox.Items.Clear();
            StoreReportPanel.BringToFront();
            var query = context.Stores.Select(s => s);
            foreach (var store in query)
            {
                StoreReport_IdCombobox.Items.Add(store.ID.ToString());
            }
        }
        public void loadStoreReport(int requiredStoreId)
        {
            List<Product> products = new List<Product>();
            var query = context.SupplyPermissions.Select(s => s).Where(s => s.Store_ID == requiredStoreId);
            foreach (var s in query)
            {
                products.Add(s.Product);
            }
            StoreReport_DataGridView.DataSource = products;
        }


        private void StoreReport_IdCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int requiredStoreId = int.Parse(StoreReport_IdCombobox.SelectedItem.ToString());
            var requiredStore = context.Stores.Find(requiredStoreId);
            StoreReport_NameTextbox.Text = requiredStore.Name;
            StoreReport_AddressTextbox.Text = requiredStore.Address;
            StoreReport_ManagerNameTextbox.Text = requiredStore.Manager_Name;
            loadStoreReport(requiredStoreId);
        }
    }

}
