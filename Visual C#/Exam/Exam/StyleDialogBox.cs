using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class StyleDialogBox : Form
    {
        private Color lineColor;
        private string lineThicnkess;
        public StyleDialogBox()
        {
            InitializeComponent();
            switch (lineThicnkess)
            {
                case "Normal":
                    Thick1.Checked = true;
                    break;
                case "Bold":
                    Thick2.Checked = true;
                    break;
                case "Bolder":
                    Thick3.Checked = true;
                    break;
                case "Strong":
                    Thick4.Checked = true;
                    break;
                case "Bold Strong":
                    Thick5.Checked = true;
                    break;
            }
        }
        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }

        }
        public string LineThickness
        {
            get { return lineThicnkess; }
            set { lineThicnkess = value; }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult color_res = colorDialog1.ShowDialog();
            if (color_res == DialogResult.OK)
            {
                this.LineColor = colorDialog1.Color;
            }
        }

        private void Thick1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            LineThickness = btn.Text;
        }

        private void Thick2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            LineThickness = btn.Text;
        }

        private void Thick3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            LineThickness = btn.Text;
        }

        private void Thick4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            LineThickness = btn.Text;
        }

        private void Thick5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            LineThickness = btn.Text;
        }
    }
}
