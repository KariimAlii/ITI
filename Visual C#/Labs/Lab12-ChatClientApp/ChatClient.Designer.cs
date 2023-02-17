namespace Lab12_ChatClientApp
{
    partial class ChatClient
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
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ReceiveBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.NewMessageBox = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConnectBtn.Location = new System.Drawing.Point(619, 51);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(138, 37);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ReceiveBtn
            // 
            this.ReceiveBtn.BackColor = System.Drawing.Color.Gold;
            this.ReceiveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReceiveBtn.Location = new System.Drawing.Point(399, 361);
            this.ReceiveBtn.Name = "ReceiveBtn";
            this.ReceiveBtn.Size = new System.Drawing.Size(113, 41);
            this.ReceiveBtn.TabIndex = 10;
            this.ReceiveBtn.Text = "Receive";
            this.ReceiveBtn.UseVisualStyleBackColor = false;
            this.ReceiveBtn.Click += new System.EventHandler(this.ReceiveBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.SendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SendBtn.Location = new System.Drawing.Point(165, 361);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(113, 37);
            this.SendBtn.TabIndex = 9;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.IndianRed;
            this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisconnectBtn.Location = new System.Drawing.Point(619, 118);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(138, 41);
            this.DisconnectBtn.TabIndex = 7;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // NewMessageBox
            // 
            this.NewMessageBox.Location = new System.Drawing.Point(98, 317);
            this.NewMessageBox.Name = "NewMessageBox";
            this.NewMessageBox.Size = new System.Drawing.Size(476, 22);
            this.NewMessageBox.TabIndex = 11;
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 16;
            this.ChatBox.Location = new System.Drawing.Point(98, 34);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(476, 260);
            this.ChatBox.TabIndex = 12;
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(87, 419);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(200, 24);
            this.StatusBox.TabIndex = 14;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionLabel.Location = new System.Drawing.Point(12, 421);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(69, 20);
            this.ConnectionLabel.TabIndex = 13;
            this.ConnectionLabel.Text = "Status:";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.NewMessageBox);
            this.Controls.Add(this.ReceiveBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Name = "ChatClient";
            this.Text = "ChatClient";
            this.Load += new System.EventHandler(this.ChatClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button ReceiveBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.TextBox NewMessageBox;
        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Label ConnectionLabel;
    }
}

