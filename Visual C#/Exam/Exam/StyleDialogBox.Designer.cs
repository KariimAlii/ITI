namespace Exam
{
    partial class StyleDialogBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ColorTab = new System.Windows.Forms.TabControl();
            this.ColorPage = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.Thickness = new System.Windows.Forms.TabPage();
            this.Thick5 = new System.Windows.Forms.RadioButton();
            this.Thick4 = new System.Windows.Forms.RadioButton();
            this.Thick3 = new System.Windows.Forms.RadioButton();
            this.Thick2 = new System.Windows.Forms.RadioButton();
            this.Thick1 = new System.Windows.Forms.RadioButton();
            this.FontThickness = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorTab.SuspendLayout();
            this.ColorPage.SuspendLayout();
            this.Thickness.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.OkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.OkBtn.Location = new System.Drawing.Point(233, 314);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(89, 42);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Red;
            this.CancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelBtn.Location = new System.Drawing.Point(452, 314);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(102, 42);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ColorTab
            // 
            this.ColorTab.Controls.Add(this.ColorPage);
            this.ColorTab.Controls.Add(this.Thickness);
            this.ColorTab.Location = new System.Drawing.Point(175, 41);
            this.ColorTab.Name = "ColorTab";
            this.ColorTab.SelectedIndex = 0;
            this.ColorTab.Size = new System.Drawing.Size(422, 235);
            this.ColorTab.TabIndex = 4;
            // 
            // ColorPage
            // 
            this.ColorPage.Controls.Add(this.button3);
            this.ColorPage.Location = new System.Drawing.Point(4, 25);
            this.ColorPage.Name = "ColorPage";
            this.ColorPage.Padding = new System.Windows.Forms.Padding(3);
            this.ColorPage.Size = new System.Drawing.Size(414, 206);
            this.ColorPage.TabIndex = 0;
            this.ColorPage.Text = "Color";
            this.ColorPage.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(115, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 59);
            this.button3.TabIndex = 1;
            this.button3.Text = "Choose Color";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Thickness
            // 
            this.Thickness.Controls.Add(this.Thick5);
            this.Thickness.Controls.Add(this.Thick4);
            this.Thickness.Controls.Add(this.Thick3);
            this.Thickness.Controls.Add(this.Thick2);
            this.Thickness.Controls.Add(this.Thick1);
            this.Thickness.Controls.Add(this.FontThickness);
            this.Thickness.Location = new System.Drawing.Point(4, 25);
            this.Thickness.Name = "Thickness";
            this.Thickness.Padding = new System.Windows.Forms.Padding(3);
            this.Thickness.Size = new System.Drawing.Size(414, 206);
            this.Thickness.TabIndex = 1;
            this.Thickness.Text = "ThicknessPage";
            this.Thickness.UseVisualStyleBackColor = true;
            // 
            // Thick5
            // 
            this.Thick5.AutoSize = true;
            this.Thick5.Location = new System.Drawing.Point(301, 163);
            this.Thick5.Name = "Thick5";
            this.Thick5.Size = new System.Drawing.Size(98, 20);
            this.Thick5.TabIndex = 13;
            this.Thick5.TabStop = true;
            this.Thick5.Text = "Bold Strong";
            this.Thick5.UseVisualStyleBackColor = true;
            this.Thick5.CheckedChanged += new System.EventHandler(this.Thick5_CheckedChanged);
            // 
            // Thick4
            // 
            this.Thick4.AutoSize = true;
            this.Thick4.Location = new System.Drawing.Point(301, 127);
            this.Thick4.Name = "Thick4";
            this.Thick4.Size = new System.Drawing.Size(67, 20);
            this.Thick4.TabIndex = 12;
            this.Thick4.TabStop = true;
            this.Thick4.Text = "Strong";
            this.Thick4.UseVisualStyleBackColor = true;
            this.Thick4.CheckedChanged += new System.EventHandler(this.Thick4_CheckedChanged);
            // 
            // Thick3
            // 
            this.Thick3.AutoSize = true;
            this.Thick3.Location = new System.Drawing.Point(301, 88);
            this.Thick3.Name = "Thick3";
            this.Thick3.Size = new System.Drawing.Size(68, 20);
            this.Thick3.TabIndex = 11;
            this.Thick3.TabStop = true;
            this.Thick3.Text = "Bolder";
            this.Thick3.UseVisualStyleBackColor = true;
            this.Thick3.CheckedChanged += new System.EventHandler(this.Thick3_CheckedChanged);
            // 
            // Thick2
            // 
            this.Thick2.AutoSize = true;
            this.Thick2.Location = new System.Drawing.Point(301, 62);
            this.Thick2.Name = "Thick2";
            this.Thick2.Size = new System.Drawing.Size(56, 20);
            this.Thick2.TabIndex = 10;
            this.Thick2.TabStop = true;
            this.Thick2.Text = "Bold";
            this.Thick2.UseVisualStyleBackColor = true;
            this.Thick2.CheckedChanged += new System.EventHandler(this.Thick2_CheckedChanged);
            // 
            // Thick1
            // 
            this.Thick1.AutoSize = true;
            this.Thick1.Location = new System.Drawing.Point(301, 36);
            this.Thick1.Name = "Thick1";
            this.Thick1.Size = new System.Drawing.Size(72, 20);
            this.Thick1.TabIndex = 9;
            this.Thick1.TabStop = true;
            this.Thick1.Text = "Normal";
            this.Thick1.UseVisualStyleBackColor = true;
            this.Thick1.CheckedChanged += new System.EventHandler(this.Thick1_CheckedChanged);
            // 
            // FontThickness
            // 
            this.FontThickness.AutoSize = true;
            this.FontThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontThickness.Location = new System.Drawing.Point(71, 31);
            this.FontThickness.Name = "FontThickness";
            this.FontThickness.Size = new System.Drawing.Size(160, 25);
            this.FontThickness.TabIndex = 8;
            this.FontThickness.Text = "Font Thickness";
            // 
            // StyleDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColorTab);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Name = "StyleDialogBox";
            this.Text = "StyleDialogBox";
            this.ColorTab.ResumeLayout(false);
            this.ColorPage.ResumeLayout(false);
            this.Thickness.ResumeLayout(false);
            this.Thickness.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TabControl ColorTab;
        private System.Windows.Forms.TabPage ColorPage;
        private System.Windows.Forms.TabPage Thickness;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton Thick3;
        private System.Windows.Forms.RadioButton Thick2;
        private System.Windows.Forms.RadioButton Thick1;
        private System.Windows.Forms.Label FontThickness;
        private System.Windows.Forms.RadioButton Thick5;
        private System.Windows.Forms.RadioButton Thick4;
    }
}