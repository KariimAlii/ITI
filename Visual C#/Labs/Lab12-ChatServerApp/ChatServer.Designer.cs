namespace Lab12_ChatServerApp
{
    partial class ChatServer
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
            this.ListenBtn = new System.Windows.Forms.Button();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.NewMessageBox = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ListenBtn
            // 
            this.ListenBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.ListenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListenBtn.Location = new System.Drawing.Point(666, 24);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(113, 37);
            this.ListenBtn.TabIndex = 0;
            this.ListenBtn.Text = "Start";
            this.ListenBtn.UseVisualStyleBackColor = false;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionLabel.Location = new System.Drawing.Point(22, 418);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(69, 20);
            this.ConnectionLabel.TabIndex = 1;
            this.ConnectionLabel.Text = "Status:";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.IndianRed;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExitBtn.Location = new System.Drawing.Point(666, 67);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(113, 41);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.SendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SendBtn.Location = new System.Drawing.Point(331, 356);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(113, 37);
            this.SendBtn.TabIndex = 4;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // NewMessageBox
            // 
            this.NewMessageBox.Location = new System.Drawing.Point(145, 314);
            this.NewMessageBox.Name = "NewMessageBox";
            this.NewMessageBox.Size = new System.Drawing.Size(476, 22);
            this.NewMessageBox.TabIndex = 6;
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 16;
            this.ChatBox.Location = new System.Drawing.Point(145, 39);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(476, 260);
            this.ChatBox.TabIndex = 7;
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(97, 416);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(200, 24);
            this.StatusBox.TabIndex = 8;
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.NewMessageBox);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.ListenBtn);
            this.Name = "ChatServer";
            this.Text = "ChatServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox NewMessageBox;
        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.TextBox StatusBox;
    }
}

