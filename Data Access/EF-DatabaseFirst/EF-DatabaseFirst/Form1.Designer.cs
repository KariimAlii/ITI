namespace EF_DatabaseFirst
{
    partial class Form1
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
            this.DepAddBtn = new System.Windows.Forms.Button();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.DepDeleteBtn = new System.Windows.Forms.Button();
            this.DepUpdateBtn = new System.Windows.Forms.Button();
            this.IdLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmpIdTextbox = new System.Windows.Forms.TextBox();
            this.EmpNameTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.EmpAddBtn = new System.Windows.Forms.Button();
            this.EmpDeleteBtn = new System.Windows.Forms.Button();
            this.EmpUpdateBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DepAddBtn
            // 
            this.DepAddBtn.Location = new System.Drawing.Point(906, 205);
            this.DepAddBtn.Name = "DepAddBtn";
            this.DepAddBtn.Size = new System.Drawing.Size(75, 23);
            this.DepAddBtn.TabIndex = 5;
            this.DepAddBtn.Text = "Add";
            this.DepAddBtn.UseVisualStyleBackColor = true;
            this.DepAddBtn.Click += new System.EventHandler(this.DepAddBtn_Click);
            // 
            // DeptBox
            // 
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(378, 63);
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(311, 24);
            this.DeptBox.TabIndex = 0;
            // 
            // DepDeleteBtn
            // 
            this.DepDeleteBtn.Location = new System.Drawing.Point(906, 329);
            this.DepDeleteBtn.Name = "DepDeleteBtn";
            this.DepDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DepDeleteBtn.TabIndex = 7;
            this.DepDeleteBtn.Text = "Delete";
            this.DepDeleteBtn.UseVisualStyleBackColor = true;
            this.DepDeleteBtn.Click += new System.EventHandler(this.DepDeleteBtn_Click);
            // 
            // DepUpdateBtn
            // 
            this.DepUpdateBtn.Location = new System.Drawing.Point(906, 268);
            this.DepUpdateBtn.Name = "DepUpdateBtn";
            this.DepUpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.DepUpdateBtn.TabIndex = 6;
            this.DepUpdateBtn.Text = "Update";
            this.DepUpdateBtn.UseVisualStyleBackColor = true;
            this.DepUpdateBtn.Click += new System.EventHandler(this.DepUpdateBtn_Click);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(167, 213);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(18, 16);
            this.IdLabel.TabIndex = 8;
            this.IdLabel.Text = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // EmpIdTextbox
            // 
            this.EmpIdTextbox.Location = new System.Drawing.Point(256, 206);
            this.EmpIdTextbox.Name = "EmpIdTextbox";
            this.EmpIdTextbox.Size = new System.Drawing.Size(328, 22);
            this.EmpIdTextbox.TabIndex = 10;
            // 
            // EmpNameTextbox
            // 
            this.EmpNameTextbox.Location = new System.Drawing.Point(256, 257);
            this.EmpNameTextbox.Name = "EmpNameTextbox";
            this.EmpNameTextbox.Size = new System.Drawing.Size(328, 22);
            this.EmpNameTextbox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.EmpNameTextbox);
            this.panel1.Controls.Add(this.EmpIdTextbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.IdLabel);
            this.panel1.Controls.Add(this.DepUpdateBtn);
            this.panel1.Controls.Add(this.DepDeleteBtn);
            this.panel1.Controls.Add(this.DeptBox);
            this.panel1.Controls.Add(this.DepAddBtn);
            this.panel1.Location = new System.Drawing.Point(449, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 424);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(567, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Department";
            // 
            // EmpAddBtn
            // 
            this.EmpAddBtn.Location = new System.Drawing.Point(906, 116);
            this.EmpAddBtn.Name = "EmpAddBtn";
            this.EmpAddBtn.Size = new System.Drawing.Size(75, 23);
            this.EmpAddBtn.TabIndex = 8;
            this.EmpAddBtn.Text = "Add";
            this.EmpAddBtn.UseVisualStyleBackColor = true;
            this.EmpAddBtn.Click += new System.EventHandler(this.EmpAddBtn_Click);
            // 
            // EmpDeleteBtn
            // 
            this.EmpDeleteBtn.Location = new System.Drawing.Point(906, 256);
            this.EmpDeleteBtn.Name = "EmpDeleteBtn";
            this.EmpDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.EmpDeleteBtn.TabIndex = 10;
            this.EmpDeleteBtn.Text = "Delete";
            this.EmpDeleteBtn.UseVisualStyleBackColor = true;
            this.EmpDeleteBtn.Click += new System.EventHandler(this.EmpDeleteBtn_Click);
            // 
            // EmpUpdateBtn
            // 
            this.EmpUpdateBtn.Location = new System.Drawing.Point(906, 179);
            this.EmpUpdateBtn.Name = "EmpUpdateBtn";
            this.EmpUpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.EmpUpdateBtn.TabIndex = 9;
            this.EmpUpdateBtn.Text = "Update";
            this.EmpUpdateBtn.UseVisualStyleBackColor = true;
            this.EmpUpdateBtn.Click += new System.EventHandler(this.EmpUpdateBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(847, 333);
            this.dataGridView1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.EmpUpdateBtn);
            this.panel2.Controls.Add(this.EmpDeleteBtn);
            this.panel2.Controls.Add(this.EmpAddBtn);
            this.panel2.Location = new System.Drawing.Point(449, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 372);
            this.panel2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Employee";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DepAddBtn;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Button DepDeleteBtn;
        private System.Windows.Forms.Button DepUpdateBtn;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmpIdTextbox;
        private System.Windows.Forms.TextBox EmpNameTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EmpAddBtn;
        private System.Windows.Forms.Button EmpDeleteBtn;
        private System.Windows.Forms.Button EmpUpdateBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}

