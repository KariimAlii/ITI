using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Supply Permission Panel
    public partial class StoreAppForm : Form
    {
        public void loadSupplyPermission()
        {
            SP_StoreID_Combobox_Add.Items.Clear();
            SP_StoreID_Combobox_Update.Items.Clear();
            SP_ProductID_Combobox_Add.Items.Clear();
            SP_ProductID_Combobox_Update.Items.Clear();
            SP_SupplierID_Combobox_Add.Items.Clear();
            SP_SupplierID_Combobox_Update.Items.Clear();

            List<SupplyPermission> supplyPermissions = new List<SupplyPermission>();
            var query = context.SupplyPermissions.Select(c => c);
            foreach (var supPermission in query)
            {
                supplyPermissions.Add(supPermission);
            }
            SP_DataGridView.DataSource = supplyPermissions;

            var query2 = context.Stores.Select(s => s);
            foreach (var store in query2)
            {
                SP_StoreID_Combobox_Add.Items.Add(store.ID.ToString());
                SP_StoreID_Combobox_Update.Items.Add(store.ID.ToString());
            }

            var query3 = context.Products.Select(p => p);
            foreach (var product in query3)
            {
                SP_ProductID_Combobox_Add.Items.Add(product.ID.ToString());
                SP_ProductID_Combobox_Update.Items.Add(product.ID.ToString());
            }

            var query4 = context.Suppliers.Select(s => s);
            foreach (var supplier in query4)
            {
                SP_SupplierID_Combobox_Add.Items.Add(supplier.ID.ToString());
                SP_SupplierID_Combobox_Update.Items.Add(supplier.ID.ToString());
            }

        }
        private void SP_AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SupplyPermission newSupplyPermission = new SupplyPermission()
                {
                    ID = int.Parse(SP_ID_Textbox_Add.Text),
                    Store_ID = int.Parse(SP_StoreID_Combobox_Add.SelectedItem.ToString()),
                    Supplier_ID = int.Parse(SP_SupplierID_Combobox_Add.SelectedItem.ToString()),
                    Product_ID = int.Parse(SP_ProductID_Combobox_Add.SelectedItem.ToString()),
                    Product_Quantity = int.Parse(SP_ProductQu_Textbox_Add.Text),
                    Date = SP_Date_Add.Value,
                    Manufacture_Date = SP_ManuDate_Add.Value,
                    Expiration_Duration = int.Parse(SP_ExpirDur_Textbox_Add.Text),
                };
                context.SupplyPermissions.Add(newSupplyPermission);
                context.SaveChanges();
                loadSupplyPermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }
        }
        private void SP_UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(SP_DataGridView.SelectedCells[0].RowIndex.ToString());
                var supplyPermissionId = SP_DataGridView[0, rowIndex].Value;
                var selectedSupplyPermission = context.SupplyPermissions.Find(supplyPermissionId);

                selectedSupplyPermission.Store_ID = int.Parse(SP_StoreID_Combobox_Update.SelectedItem.ToString());
                selectedSupplyPermission.Supplier_ID = int.Parse(SP_SupplierID_Combobox_Update.SelectedItem.ToString());
                selectedSupplyPermission.Product_ID = int.Parse(SP_ProductID_Combobox_Update.SelectedItem.ToString());
                selectedSupplyPermission.Product_Quantity = int.Parse(SP_ProductQu_Textbox_Update.Text);
                selectedSupplyPermission.Date = SP_Date_Update.Value;
                selectedSupplyPermission.Manufacture_Date = SP_ManuDate_Update.Value;
                selectedSupplyPermission.Expiration_Duration = int.Parse(SP_ExpirDur_Textbox_Update.Text);

                context.SaveChanges();
                loadSupplyPermission();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void SP_DeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(SP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var supplyPermissionId = SP_DataGridView[0, rowIndex].Value;
            var selectedSupplyPermission = context.SupplyPermissions.Find(supplyPermissionId);

            context.SupplyPermissions.Remove(selectedSupplyPermission);
            context.SaveChanges();
            loadSupplyPermission();
        }

        private void SP_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(SP_DataGridView.SelectedCells[0].RowIndex.ToString());
            var supplyPermissionId = SP_DataGridView[0, rowIndex].Value;
            var selectedSupplyPermission = context.SupplyPermissions.Find(supplyPermissionId);


            SP_StoreID_Combobox_Update.SelectedItem = selectedSupplyPermission.Store_ID;
            SP_SupplierID_Combobox_Update.SelectedItem = selectedSupplyPermission.Supplier_ID;
            SP_ProductID_Combobox_Update.SelectedItem = selectedSupplyPermission.Product_ID;
            SP_ProductQu_Textbox_Update.Text = selectedSupplyPermission.Product_Quantity.ToString();
            SP_ManuDate_Update.Value = selectedSupplyPermission.Manufacture_Date;
            SP_ExpirDur_Textbox_Update.Text = selectedSupplyPermission.Expiration_Duration.ToString();
        }
        private void SP_ProductID_Combobox_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = context.Products.Find(int.Parse(SP_ProductID_Combobox_Add.SelectedItem.ToString()));
            SP_ManuDate_Add.Value = product.Manufacture_Date;
            SP_ExpirDur_Textbox_Add.Text = product.Expiration_Duration.ToString();
        }
    }
}
