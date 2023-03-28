using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Store Panel
    public partial class StoreAppForm : Form
    {
        public void loadStores()
        {
            List<Store> stores = new List<Store>();
            var query = context.Stores.Select(s => s);
            foreach (var store in query)
            {
                stores.Add(store);
            }
            StoreDataGridView.DataSource = stores;
        }

        private void StoreAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Store newStore = new Store()
                {
                    ID = int.Parse(StoreIdTextbox_Add.Text),
                    Name = StoreNameTextbox_Add.Text,
                    Address = AddressTextBox_Add.Text,
                    Manager_Name = ManagerNameTextBox_Add.Text
                };
                context.Stores.Add(newStore);
                context.SaveChanges();
                loadStores();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }



        private void StoreUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(StoreDataGridView.SelectedCells[0].RowIndex.ToString());
                var storeId = StoreDataGridView[0, rowIndex].Value;
                var selectedStore = context.Stores.Find(storeId);
                selectedStore.Name = StoreNameTextBox_Update.Text;
                selectedStore.Address = AddressTextBox_Update.Text;
                selectedStore.Manager_Name = ManagerNameTextBox_Update.Text;
                context.SaveChanges();
                loadStores();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void StoreDeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(StoreDataGridView.SelectedCells[0].RowIndex.ToString());
            var storeId = StoreDataGridView[0, rowIndex].Value;
            var selectedStore = context.Stores.Find(storeId);
            context.Stores.Remove(selectedStore);
            context.SaveChanges();
            loadStores();
        }
        private void StoreDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(StoreDataGridView.SelectedCells[0].RowIndex.ToString());
            var storeId = StoreDataGridView[0, rowIndex].Value;
            var selectedStore = context.Stores.Find(storeId);
            StoreNameTextBox_Update.Text = selectedStore.Name;
            ManagerNameTextBox_Update.Text = selectedStore.Manager_Name;
        }
    }
}
