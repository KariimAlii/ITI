using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{
    // Customer Panel
    public partial class StoreAppForm : Form
    {
        public void loadCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var query = context.Customers.Select(c => c);
            foreach (var customer in query)
            {
                customers.Add(customer);
            }
            CustomerDataGridView.DataSource = customers;
        }
        private void CustomerAddBtn_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                ID = int.Parse(CustomerIdTextbox_Add.Text),
                Name = CustomerNameTextbox_Add.Text,
                Telephone_Num = CustomerTelNumTextbox_Add.Text,
                Fax = CustomerFaxTextbox_Add.Text,
                Mobile_Num = CustomerMobileNumTextbox_Add.Text,
                Email = CustomerEmailTextbox_Add.Text,
                Website = CustomerWebsiteTextbox_Add.Text,
            };
            context.Customers.Add(newCustomer);
            context.SaveChanges();
            loadCustomers();
        }

        private void CustomerUpdateBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(CustomerDataGridView.SelectedCells[0].RowIndex.ToString());
            var customerId = CustomerDataGridView[0, rowIndex].Value;
            var selectedCustomer = context.Customers.Find(customerId);

            selectedCustomer.Name = CustomerNameTextbox_Update.Text;
            selectedCustomer.Telephone_Num = CustomerTelNumTextbox_Update.Text;
            selectedCustomer.Fax = CustomerFaxTextbox_Update.Text;
            selectedCustomer.Mobile_Num = CustomerMobileNumTextbox_Update.Text;
            selectedCustomer.Email = CustomerEmailTextbox_Update.Text;
            selectedCustomer.Website = CustomerWebsiteTextbox_Update.Text;

            context.SaveChanges();
            loadCustomers();
        }

        private void CustomerDeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(CustomerDataGridView.SelectedCells[0].RowIndex.ToString());
            var customerId = CustomerDataGridView[0, rowIndex].Value;
            var selectedCustomer = context.Customers.Find(customerId);
            context.Customers.Remove(selectedCustomer);
            context.SaveChanges();
            loadCustomers();
        }

        private void CustomerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(CustomerDataGridView.SelectedCells[0].RowIndex.ToString());
            var customerId = CustomerDataGridView[0, rowIndex].Value;
            var selectedCustomer = context.Customers.Find(customerId);

            CustomerNameTextbox_Update.Text = selectedCustomer.Name;
            CustomerTelNumTextbox_Update.Text = selectedCustomer.Telephone_Num;
            CustomerFaxTextbox_Update.Text = selectedCustomer.Fax;
            CustomerMobileNumTextbox_Update.Text = selectedCustomer.Mobile_Num;
            CustomerEmailTextbox_Update.Text = selectedCustomer.Email;
            CustomerWebsiteTextbox_Update.Text = selectedCustomer.Website;
        }
    }
}
