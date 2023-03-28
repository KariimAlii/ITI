using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Transfer Report Panel
    public partial class StoreAppForm : Form
    {
        public void loadTransferReport(int productId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Transfer_Permission> transferPermissions = new List<Transfer_Permission>();
                var query = context.Transfer_Permissions
                            .Select(t => t)
                            .Where(t => t.Product_ID == productId &&
                                        t.Date >= startDate &&
                                        t.Date <= endDate
                            );
                foreach (var trPermission in query)
                {
                    transferPermissions.Add(trPermission);
                }
                TransferReport_DataGridView.DataSource = transferPermissions;
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void TransferReport_DisplayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(TransferReport_ProductId_Combobox.SelectedItem.ToString());
                DateTime startDate = TransferReport_FromDate.Value;
                DateTime endDate = TransferReport_ToDate.Value;
                loadTransferReport(productId, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }
        private void TransferReportPanelBtn_Click(object sender, EventArgs e)
        {
            TransferReport_ProductId_Combobox.Items.Clear();
            TransferReportPanel.BringToFront();
            var query = context.Products.Select(p => p);
            foreach (var product in query)
            {
                TransferReport_ProductId_Combobox.Items.Add(product.ID.ToString());
            }
        }
        private void TransferReport_ProductId_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int requiredProductId = int.Parse(TransferReport_ProductId_Combobox.SelectedItem.ToString());
            Product requiredProduct = context.Products.Find(requiredProductId);
            TransferReport_ProductName_Textbox.Text = requiredProduct.Name;
        }
    }
}
