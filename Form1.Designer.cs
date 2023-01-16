namespace ChatMessageApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ServerPortTextbox = new System.Windows.Forms.TextBox();
            this.HostServerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.JoinServerTextbox = new System.Windows.Forms.TextBox();
            this.JoinServerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerIPTextbox = new System.Windows.Forms.TextBox();
            this.ChatTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeTextbox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // ServerPortTextbox
            // 
            this.ServerPortTextbox.Location = new System.Drawing.Point(12, 46);
            this.ServerPortTextbox.Name = "ServerPortTextbox";
            this.ServerPortTextbox.Size = new System.Drawing.Size(138, 27);
            this.ServerPortTextbox.TabIndex = 1;
            this.ServerPortTextbox.Text = "9000";
            // 
            // HostServerButton
            // 
            this.HostServerButton.Location = new System.Drawing.Point(26, 79);
            this.HostServerButton.Name = "HostServerButton";
            this.HostServerButton.Size = new System.Drawing.Size(111, 29);
            this.HostServerButton.TabIndex = 2;
            this.HostServerButton.Text = "Host Server";
            this.HostServerButton.UseVisualStyleBackColor = true;
            this.HostServerButton.Click += new System.EventHandler(this.HostServerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Join Server";
            // 
            // JoinServerTextbox
            // 
            this.JoinServerTextbox.Location = new System.Drawing.Point(419, 46);
            this.JoinServerTextbox.Name = "JoinServerTextbox";
            this.JoinServerTextbox.Size = new System.Drawing.Size(125, 27);
            this.JoinServerTextbox.TabIndex = 4;
            // 
            // JoinServerButton
            // 
            this.JoinServerButton.Location = new System.Drawing.Point(419, 79);
            this.JoinServerButton.Name = "JoinServerButton";
            this.JoinServerButton.Size = new System.Drawing.Size(94, 29);
            this.JoinServerButton.TabIndex = 5;
            this.JoinServerButton.Text = "Join Server";
            this.JoinServerButton.UseVisualStyleBackColor = true;
            this.JoinServerButton.Click += new System.EventHandler(this.JoinServerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(593, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server IP";
            // 
            // ServerIPTextbox
            // 
            this.ServerIPTextbox.Location = new System.Drawing.Point(584, 46);
            this.ServerIPTextbox.Name = "ServerIPTextbox";
            this.ServerIPTextbox.Size = new System.Drawing.Size(170, 27);
            this.ServerIPTextbox.TabIndex = 7;
            this.ServerIPTextbox.Text = "127.0.0.1";
            // 
            // ChatTextbox
            // 
            this.ChatTextbox.Location = new System.Drawing.Point(12, 129);
            this.ChatTextbox.Multiline = true;
            this.ChatTextbox.Name = "ChatTextbox";
            this.ChatTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatTextbox.Size = new System.Drawing.Size(799, 306);
            this.ChatTextbox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chat";
            // 
            // TypeTextbox
            // 
            this.TypeTextbox.Location = new System.Drawing.Point(63, 453);
            this.TypeTextbox.Name = "TypeTextbox";
            this.TypeTextbox.Size = new System.Drawing.Size(531, 27);
            this.TypeTextbox.TabIndex = 10;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(646, 453);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(94, 29);
            this.SendButton.TabIndex = 11;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 538);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.TypeTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChatTextbox);
            this.Controls.Add(this.ServerIPTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.JoinServerButton);
            this.Controls.Add(this.JoinServerTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HostServerButton);
            this.Controls.Add(this.ServerPortTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerPortTextbox;
        private System.Windows.Forms.Button HostServerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox JoinServerTextbox;
        private System.Windows.Forms.Button JoinServerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerIPTextbox;
        private System.Windows.Forms.TextBox ChatTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TypeTextbox;
        private System.Windows.Forms.Button SendButton;
    }
}
