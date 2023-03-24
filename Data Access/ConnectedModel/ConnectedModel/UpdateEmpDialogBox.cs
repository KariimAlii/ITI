using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConnectedModel
{
    public partial class UpdateEmpDialogBox : Form
    {
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string RequiredUpdate { get; set; }
        public UpdateEmpDialogBox()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            switch (RequiredUpdate)
            {
                case "Name":
                    this.EmpName = this.UpdateTextBox.Text;
                    this.DeptName = "";
                    break;
                case "Department":
                    this.DeptName = this.UpdateTextBox.Text;
                    this.EmpName = "";
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Name":
                    RequiredUpdate = "Name";
                    break;
                case "Department":
                    RequiredUpdate = "Department";
                    break;
            }

        }
    }
}
