using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Release Permission Panel
    public partial class StoreAppForm : Form
    {
        public void loadReleasePermission()
        {
            RP_StoreIdCombobox_Add.Items.Clear();
            RP_StoreIDCombobox_Update.Items.Clear();
            RP_ProductIdCombobox_Add.Items.Clear();
            RP_ProductIdCombobox_Update.Items.Clear();
            RP_SupplierIdCombobox_Add.Items.Clear();
            RP_SupplierIdCombobox_Update.Items.Clear();

            List<ReleasePermission> releasePermissions = new List<ReleasePermission>();

            var query = context.ReleasePermissions.Select(c => c);
            foreach (var relPermission in query)
            {
                releasePermissions.Add(relPermission);
            }
            RP_DataGridView.DataSource = releasePermissions;

            var query2 = context.Stores.Select(s => s);
            foreach (var store in query2)
            {
                RP_StoreIdCombobox_Add.Items.Add(store.ID.ToString());
                RP_StoreIDCombobox_Update.Items.Add(store.ID.ToString());
            }

            var query3 = context.Products.Select(p => p);
            foreach (var product in query3)
            {
                RP_ProductIdCombobox_Add.Items.Add(product.ID.ToString());
                RP_ProductIdCombobox_Update.Items.Add(product.ID.ToString());
            }

            var query4 = context.Suppliers.Select(s => s);
            foreach (var supplier in query4)
            {
                RP_SupplierIdCombobox_Add.Items.Add(supplier.ID.ToString());
                RP_SupplierIdCombobox_Update.Items.Add(supplier.ID.ToString());
            }
        }
        private void RP_AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ReleasePermission newReleasePermission = new ReleasePermission()
                {
                    ID = int.Parse(RP_Id_Add.Text),
                    Store_ID = int.Parse(RP_StoreIdCombobox_Add.SelectedItem.ToString()),
                    Supplier_ID = int.Parse(RP_SupplierIdCombobox_Add.SelectedItem.ToString()),
                    Product_ID = int.Parse(RP_ProductIdCombobox_Add.SelectedItem.ToString()),
                    Product_Quantity = int.Parse(RP_ProductQu_Add.Text),
                    Date = RP_Date_Add.Value,
                };
                context.ReleasePermissions.Add(newReleasePermission);
                context.SaveChanges();
                loadReleasePermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }
        }

        private void RP_UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(RP_DataGridView.SelectedCells[0].RowIndex.ToString());
                var releasePermissionId = RP_DataGridView[0, rowIndex].Value;
                var selectedReleasePermission = context.ReleasePermissions.Find(releasePermissionId);

                selectedReleasePermission.Store_ID = int.Parse(RP_StoreIDCombobox_Update.SelectedItem.ToString());
                selectedReleasePermission.Supplier_ID = int.Parse(RP_SupplierIdCombobox_Update.SelectedItem.ToString());
                selectedReleasePermission.Product_ID = int.Parse(RP_ProductIdCombobox_Update.SelectedItem.ToString());
                selectedReleasePermission.Product_Quantity = int.Parse(RP_ProductQu_Update.Text);
                selectedReleasePermission.Date = RP_Date_Update.Value;

                context.SaveChanges();
                loadSupplyPermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }
        }

        private void RP_DeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(RP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var releasePermissionId = RP_DataGridView[0, rowIndex].Value;
            var selectedReleasePermission = context.ReleasePermissions.Find(releasePermissionId);

            context.ReleasePermissions.Remove(selectedReleasePermission);
            context.SaveChanges();
            loadReleasePermission();
        }

        private void RP_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(RP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var releasePermissionId = RP_DataGridView[0, rowIndex].Value;
            var selectedReleasePermission = context.ReleasePermissions.Find(releasePermissionId);

            RP_StoreIDCombobox_Update.SelectedItem = selectedReleasePermission.Store_ID;
            RP_SupplierIdCombobox_Update.SelectedItem = selectedReleasePermission.Supplier_ID;
            RP_ProductIdCombobox_Update.SelectedItem = selectedReleasePermission.Product_ID;
            RP_ProductQu_Update.Text = selectedReleasePermission.Product_Quantity.ToString();
            RP_Date_Update.Value = selectedReleasePermission.Date;
        }


    }
}
