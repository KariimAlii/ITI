namespace XML_Parser_Validator
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
            this.ReadBtn = new System.Windows.Forms.Button();
            this.ElementsList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.ValidationBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(520, 107);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(210, 73);
            this.ReadBtn.TabIndex = 0;
            this.ReadBtn.Text = "Read XML File";
            this.ReadBtn.UseVisualStyleBackColor = false;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // ElementsList
            // 
            this.ElementsList.FormattingEnabled = true;
            this.ElementsList.ItemHeight = 16;
            this.ElementsList.Location = new System.Drawing.Point(248, 232);
            this.ElementsList.Name = "ElementsList";
            this.ElementsList.Size = new System.Drawing.Size(1055, 740);
            this.ElementsList.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(986, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 73);
            this.button1.TabIndex = 2;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ValidationLabel.Location = new System.Drawing.Point(242, 988);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(152, 32);
            this.ValidationLabel.TabIndex = 3;
            this.ValidationLabel.Text = "Validation";
            // 
            // ValidationBox
            // 
            this.ValidationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationBox.Location = new System.Drawing.Point(400, 993);
            this.ValidationBox.Name = "ValidationBox";
            this.ValidationBox.ReadOnly = true;
            this.ValidationBox.Size = new System.Drawing.Size(903, 27);
            this.ValidationBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 1055);
            this.Controls.Add(this.ValidationBox);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ElementsList);
            this.Controls.Add(this.ReadBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.ListBox ElementsList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ValidationLabel;
        private System.Windows.Forms.TextBox ValidationBox;
    }
}

