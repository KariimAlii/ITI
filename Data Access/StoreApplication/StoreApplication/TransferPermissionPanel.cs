using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Transfer Permission Panel
    public partial class StoreAppForm : Form
    {
        public void loadTransferPermission()
        {
            TP_FromStoreCombobox_Add.Items.Clear();
            TP_FromStoreCombobox_Update.Items.Clear();
            TP_ToStoreCombobox_Add.Items.Clear();
            TP_ToStoreCombobox_Update.Items.Clear();
            TP_SupplierId_Combobox_Add.Items.Clear();
            TP_SupplierId_Combobox_Update.Items.Clear();
            TP_ProductId_Combobox_Add.Items.Clear();
            TP_ProductId_Combobox_Update.Items.Clear();

            List<Transfer_Permission> transferPermissions = new List<Transfer_Permission>();
            var query = context.Transfer_Permissions.Select(c => c);

            foreach (var trPermission in query)
            {
                transferPermissions.Add(trPermission);
            }
            TP_DataGridView.DataSource = transferPermissions;

            var query2 = context.Stores.Select(s => s);
            foreach (var store in query2)
            {
                TP_FromStoreCombobox_Add.Items.Add(store.ID.ToString());
                TP_ToStoreCombobox_Add.Items.Add(store.ID.ToString());

                TP_FromStoreCombobox_Update.Items.Add(store.ID.ToString());
                TP_ToStoreCombobox_Update.Items.Add(store.ID.ToString());
            }

            var query3 = context.Products.Select(p => p);
            foreach (var product in query3)
            {
                TP_ProductId_Combobox_Add.Items.Add(product.ID.ToString());
                TP_ProductId_Combobox_Update.Items.Add(product.ID.ToString());
            }

            var query4 = context.Suppliers.Select(s => s);
            foreach (var supplier in query4)
            {
                TP_SupplierId_Combobox_Add.Items.Add(supplier.ID.ToString());
                TP_SupplierId_Combobox_Update.Items.Add(supplier.ID.ToString());
            }

        }
        private void TP_AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                #region Add New Transfer Permission
                Transfer_Permission newTransferPermission = new Transfer_Permission()
                {
                    ID = int.Parse(TP_Id_Add.Text),
                    FromStore_ID = int.Parse(TP_FromStoreCombobox_Add.SelectedItem.ToString()),
                    ToStore_ID = int.Parse(TP_ToStoreCombobox_Add.SelectedItem.ToString()),
                    Supplier_ID = int.Parse(TP_SupplierId_Combobox_Add.SelectedItem.ToString()),
                    Product_ID = int.Parse(TP_ProductId_Combobox_Add.SelectedItem.ToString()),
                    Date = TP_Date_Add.Value,
                    Manufacture_Date = TP_ManuDate_Add.Value,
                    Expiration_Duration = int.Parse(TP_ExpirDurTextbox_Add.Text),
                };
                context.Transfer_Permissions.Add(newTransferPermission);
                #endregion

                #region change Product Data
                var productId = int.Parse(TP_ProductId_Combobox_Add.SelectedItem.ToString());
                var requiredProduct = context.Products.Find(productId);

                var fromStoreId = int.Parse(TP_FromStoreCombobox_Add.SelectedItem.ToString());
                var fromStore = context.Stores.Find(fromStoreId);

                var toStoreId = int.Parse(TP_ToStoreCombobox_Add.SelectedItem.ToString());
                var toStore = context.Stores.Find(toStoreId);

                if (requiredProduct != null)
                {
                    requiredProduct.Stores.Remove(fromStore);
                    requiredProduct.Stores.Add(toStore);
                }
                #endregion
                context.SaveChanges();
                loadTransferPermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }
        }

        private void TP_UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(TP_DataGridView.SelectedCells[0].RowIndex.ToString());
                var transferPermissionId = TP_DataGridView[0, rowIndex].Value;
                var selectedTransferPermission = context.Transfer_Permissions.Find(transferPermissionId);

                selectedTransferPermission.FromStore_ID = int.Parse(TP_FromStoreCombobox_Update.SelectedItem.ToString());
                selectedTransferPermission.ToStore_ID = int.Parse(TP_ToStoreCombobox_Update.SelectedItem.ToString());
                selectedTransferPermission.Supplier_ID = int.Parse(TP_SupplierId_Combobox_Update.SelectedItem.ToString());
                selectedTransferPermission.Product_ID = int.Parse(TP_ProductId_Combobox_Update.SelectedItem.ToString());
                selectedTransferPermission.Date = SP_Date_Update.Value;
                selectedTransferPermission.Manufacture_Date = SP_ManuDate_Update.Value;
                selectedTransferPermission.Expiration_Duration = int.Parse(SP_ExpirDur_Textbox_Update.Text);

                context.SaveChanges();
                loadTransferPermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }
        }
        private void TP_DeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(TP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var transferPermissionId = TP_DataGridView[0, rowIndex].Value;
            var selectedTransferPermission = context.Transfer_Permissions.Find(transferPermissionId);

            context.Transfer_Permissions.Remove(selectedTransferPermission);
            context.SaveChanges();
            loadTransferPermission();
        }

        private void TP_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(TP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var transferPermissionId = TP_DataGridView[0, rowIndex].Value;
            var selectedTransferPermission = context.Transfer_Permissions.Find(transferPermissionId);

            TP_FromStoreCombobox_Update.SelectedItem = selectedTransferPermission.FromStore_ID;
            TP_ToStoreCombobox_Update.SelectedItem = selectedTransferPermission.ToStore_ID;
            TP_SupplierId_Combobox_Update.SelectedItem = selectedTransferPermission.Supplier_ID;
            TP_ProductId_Combobox_Update.SelectedItem = selectedTransferPermission.Product_ID;
            SP_Date_Update.Value = selectedTransferPermission.Date;
            SP_ManuDate_Update.Value = selectedTransferPermission.Manufacture_Date;
            SP_ExpirDur_Textbox_Update.Text = selectedTransferPermission.Expiration_Duration.ToString();
        }

        private void TP_ProductId_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = context.Products.Find(int.Parse(TP_ProductId_Combobox_Add.SelectedItem.ToString()));
            TP_ManuDate_Add.Value = product.Manufacture_Date;
            TP_ExpirDurTextbox_Add.Text = product.Expiration_Duration.ToString();
        }
    }
}
