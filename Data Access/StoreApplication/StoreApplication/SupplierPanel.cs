using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Supplier Panel
    public partial class StoreAppForm : Form
    {

        public void loadSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            var query = context.Suppliers.Select(s => s);
            foreach (var supplier in query)
            {
                suppliers.Add(supplier);
            }
            SupplierDataGridView.DataSource = suppliers;
        }
        private void SupplierAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier newSupplier = new Supplier()
                {
                    ID = int.Parse(SupplierIdTextbox_Add.Text),
                    Name = SupplierNameTextbox_Add.Text,
                    Telephone_Num = SupplierTelNumTextbox_Add.Text,
                    Fax = SupplierFaxTextbox_Add.Text,
                    Mobile_Num = SupplierMobileNumTexbox_Add.Text,
                    Email = SupplierEmailTexbox_Add.Text,
                    Website = SupplierWebsiteTexbox_Add.Text,
                };
                context.Suppliers.Add(newSupplier);
                context.SaveChanges();
                loadSuppliers();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void SupplierUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(SupplierDataGridView.SelectedCells[0].RowIndex.ToString());
                var supplierId = SupplierDataGridView[0, rowIndex].Value;
                var selectedSupplier = context.Suppliers.Find(supplierId);

                selectedSupplier.Name = SupplierNameTextbox_Update.Text;
                selectedSupplier.Telephone_Num = SupplierTelNumTextbox_Update.Text;
                selectedSupplier.Fax = SupplierFaxTextbox_Update.Text;
                selectedSupplier.Mobile_Num = SupplierMobileNumTextbox_Update.Text;
                selectedSupplier.Email = SupplierEmailTextbox_Update.Text;
                selectedSupplier.Website = SupplierWebsiteTextbox_Update.Text;

                context.SaveChanges();
                loadSuppliers();
            }
            catch
            {
                MessageBox.Show("Invalid Data!! Try Again!!");
            }

        }

        private void SupplierDeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(SupplierDataGridView.SelectedCells[0].RowIndex.ToString());
            var supplierId = SupplierDataGridView[0, rowIndex].Value;
            var selectedSupplier = context.Suppliers.Find(supplierId);
            context.Suppliers.Remove(selectedSupplier);
            context.SaveChanges();
            loadSuppliers();
        }

        private void SupplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(SupplierDataGridView.SelectedCells[0].RowIndex.ToString());
            var supplierId = SupplierDataGridView[0, rowIndex].Value;
            var selectedSupplier = context.Suppliers.Find(supplierId);

            SupplierNameTextbox_Update.Text = selectedSupplier.Name;
            SupplierTelNumTextbox_Update.Text = selectedSupplier.Telephone_Num;
            SupplierFaxTextbox_Update.Text = selectedSupplier.Fax;
            SupplierMobileNumTextbox_Update.Text = selectedSupplier.Mobile_Num;
            SupplierEmailTextbox_Update.Text = selectedSupplier.Email;
            SupplierWebsiteTextbox_Update.Text = selectedSupplier.Website;
        }

    }

}
