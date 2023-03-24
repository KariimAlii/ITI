namespace ConnectedModel
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
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EmpNameTextbox = new System.Windows.Forms.TextBox();
            this.EmpIdTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.DepUpdateBtn = new System.Windows.Forms.Button();
            this.DepDeleteBtn = new System.Windows.Forms.Button();
            this.DepAddBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmpUpdateBtn = new System.Windows.Forms.Button();
            this.EmpDeleteBtn = new System.Windows.Forms.Button();
            this.EmpAddBtn = new System.Windows.Forms.Button();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeptBox
            // 
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(378, 63);
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(311, 24);
            this.DeptBox.TabIndex = 0;
            this.DeptBox.SelectedIndexChanged += new System.EventHandler(this.DeptBox_SelectedIndexChanged);
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
            this.panel1.Location = new System.Drawing.Point(211, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 424);
            this.panel1.TabIndex = 1;
            // 
            // EmpNameTextbox
            // 
            this.EmpNameTextbox.Location = new System.Drawing.Point(256, 257);
            this.EmpNameTextbox.Name = "EmpNameTextbox";
            this.EmpNameTextbox.Size = new System.Drawing.Size(328, 22);
            this.EmpNameTextbox.TabIndex = 11;
            // 
            // EmpIdTextbox
            // 
            this.EmpIdTextbox.Location = new System.Drawing.Point(256, 206);
            this.EmpIdTextbox.Name = "EmpIdTextbox";
            this.EmpIdTextbox.Size = new System.Drawing.Size(328, 22);
            this.EmpIdTextbox.TabIndex = 10;
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
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(167, 213);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(18, 16);
            this.IdLabel.TabIndex = 8;
            this.IdLabel.Text = "Id";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Employee";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.EmpUpdateBtn);
            this.panel2.Controls.Add(this.EmpDeleteBtn);
            this.panel2.Controls.Add(this.EmpAddBtn);
            this.panel2.Location = new System.Drawing.Point(211, 520);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 372);
            this.panel2.TabIndex = 3;
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
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=.;Initial Catalog=DataAccess;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.Connection = this.sqlConnection1;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(82, 914);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(94, 41);
            this.ConnectBtn.TabIndex = 11;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Location = new System.Drawing.Point(1255, 921);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(112, 41);
            this.DisconnectBtn.TabIndex = 12;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(500, 932);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(296, 30);
            this.StatusBox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 1055);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox EmpNameTextbox;
        private System.Windows.Forms.TextBox EmpIdTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Button DepUpdateBtn;
        private System.Windows.Forms.Button DepDeleteBtn;
        private System.Windows.Forms.Button DepAddBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button EmpUpdateBtn;
        private System.Windows.Forms.Button EmpDeleteBtn;
        private System.Windows.Forms.Button EmpAddBtn;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox StatusBox;
    }
}

