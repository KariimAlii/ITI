using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApplication
{

    public partial class StoreAppForm : Form
    {
        StoreAppEntities1 context = new StoreAppEntities1();
        public StoreAppForm()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.StorePanel.Location = new System.Drawing.Point(426, 107);
            loadStores();
            loadProducts();
        }

        private void StorePanelBtn_Click(object sender, EventArgs e)
        {
            StorePanel.BringToFront();
            loadStores();
        }

        private void ProductPanelBtn_Click(object sender, EventArgs e)
        {
            ProductPanel.BringToFront();
            loadProducts();
        }

        private void SupplierPanelBtn_Click(object sender, EventArgs e)
        {
            SupplierPanel.BringToFront();
            loadSuppliers();
        }

        private void CustomerPanelButton_Click(object sender, EventArgs e)
        {
            CustomerPanel.BringToFront();
            loadCustomers();
        }


        private void SupplyPermissionPanelBtn_Click(object sender, EventArgs e)
        {
            SupplyPermissionPanel.BringToFront();
            loadSupplyPermission();
        }

        private void ReleasePermissionPanelBtn_Click(object sender, EventArgs e)
        {
            ReleasePermissionPanel.BringToFront();
            loadReleasePermission();
        }

        private void TransferPermissionPanelBtn_Click(object sender, EventArgs e)
        {
            TransferPermissionPanel.BringToFront();
            loadTransferPermission();
        }


    }
}
