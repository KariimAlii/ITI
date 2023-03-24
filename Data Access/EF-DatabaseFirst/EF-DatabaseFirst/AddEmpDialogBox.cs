using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectedModel
{
    public partial class AddEmpDialogBox : Form
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public AddEmpDialogBox()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.EmpId = int.Parse(this.IdTextBox.Text);
            this.EmpName = this.NameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
