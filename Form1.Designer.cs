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
            this.CreateServerTextbox = new System.Windows.Forms.TextBox();
            this.CreateServerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.JoinServerTextbox = new System.Windows.Forms.TextBox();
            this.JoinServerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerIPTextbox = new System.Windows.Forms.TextBox();
            this.ChatTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeTextbox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PasswordButton = new System.Windows.Forms.Button();
            this.UsernameButton = new System.Windows.Forms.Button();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use Port";
            // 
            // CreateServerTextbox
            // 
            this.CreateServerTextbox.Location = new System.Drawing.Point(19, 70);
            this.CreateServerTextbox.Name = "CreateServerTextbox";
            this.CreateServerTextbox.Size = new System.Drawing.Size(138, 30);
            this.CreateServerTextbox.TabIndex = 1;
            this.CreateServerTextbox.Text = "9000";
            // 
            // CreateServerButton
            // 
            this.CreateServerButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateServerButton.Location = new System.Drawing.Point(176, 70);
            this.CreateServerButton.Name = "CreateServerButton";
            this.CreateServerButton.Size = new System.Drawing.Size(131, 30);
            this.CreateServerButton.TabIndex = 2;
            this.CreateServerButton.Text = "Create Server";
            this.CreateServerButton.UseVisualStyleBackColor = true;
            this.CreateServerButton.Click += new System.EventHandler(this.CreateServerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Port";
            // 
            // JoinServerTextbox
            // 
            this.JoinServerTextbox.Location = new System.Drawing.Point(19, 74);
            this.JoinServerTextbox.Name = "JoinServerTextbox";
            this.JoinServerTextbox.Size = new System.Drawing.Size(142, 30);
            this.JoinServerTextbox.TabIndex = 4;
            this.JoinServerTextbox.Text = "9000";
            // 
            // JoinServerButton
            // 
            this.JoinServerButton.Location = new System.Drawing.Point(400, 75);
            this.JoinServerButton.Name = "JoinServerButton";
            this.JoinServerButton.Size = new System.Drawing.Size(115, 29);
            this.JoinServerButton.TabIndex = 5;
            this.JoinServerButton.Text = "Join Server";
            this.JoinServerButton.UseVisualStyleBackColor = true;
            this.JoinServerButton.Click += new System.EventHandler(this.JoinServerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(193, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server IP";
            // 
            // ServerIPTextbox
            // 
            this.ServerIPTextbox.Location = new System.Drawing.Point(193, 74);
            this.ServerIPTextbox.Name = "ServerIPTextbox";
            this.ServerIPTextbox.Size = new System.Drawing.Size(170, 30);
            this.ServerIPTextbox.TabIndex = 7;
            this.ServerIPTextbox.Text = "127.0.0.1";
            // 
            // ChatTextbox
            // 
            this.ChatTextbox.Location = new System.Drawing.Point(21, 29);
            this.ChatTextbox.Multiline = true;
            this.ChatTextbox.Name = "ChatTextbox";
            this.ChatTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatTextbox.Size = new System.Drawing.Size(743, 365);
            this.ChatTextbox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chat";
            // 
            // TypeTextbox
            // 
            this.TypeTextbox.Location = new System.Drawing.Point(88, 417);
            this.TypeTextbox.Name = "TypeTextbox";
            this.TypeTextbox.Size = new System.Drawing.Size(493, 27);
            this.TypeTextbox.TabIndex = 12;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(603, 417);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(142, 41);
            this.SendButton.TabIndex = 11;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 538);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connect";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PasswordButton);
            this.groupBox3.Controls.Add(this.UsernameButton);
            this.groupBox3.Controls.Add(this.PasswordTextbox);
            this.groupBox3.Controls.Add(this.UsernameTextbox);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(409, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 155);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Login";
            // 
            // PasswordButton
            // 
            this.PasswordButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordButton.Location = new System.Drawing.Point(194, 88);
            this.PasswordButton.Name = "PasswordButton";
            this.PasswordButton.Size = new System.Drawing.Size(120, 29);
            this.PasswordButton.TabIndex = 3;
            this.PasswordButton.Text = "Set Password";
            this.PasswordButton.UseVisualStyleBackColor = true;
            this.PasswordButton.Click += new System.EventHandler(this.PasswordButton_Click);
            // 
            // UsernameButton
            // 
            this.UsernameButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameButton.Location = new System.Drawing.Point(194, 43);
            this.UsernameButton.Name = "UsernameButton";
            this.UsernameButton.Size = new System.Drawing.Size(120, 29);
            this.UsernameButton.TabIndex = 2;
            this.UsernameButton.Text = "Set Username";
            this.UsernameButton.UseVisualStyleBackColor = true;
            this.UsernameButton.Click += new System.EventHandler(this.UsernameButton_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.PasswordTextbox.Location = new System.Drawing.Point(12, 87);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(167, 27);
            this.PasswordTextbox.TabIndex = 1;
            this.PasswordTextbox.Text = "Password";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.UsernameTextbox.Location = new System.Drawing.Point(12, 44);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(167, 27);
            this.UsernameTextbox.TabIndex = 0;
            this.UsernameTextbox.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(216, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 54);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chat Message App";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.JoinServerTextbox);
            this.groupBox2.Controls.Add(this.JoinServerButton);
            this.groupBox2.Controls.Add(this.ServerIPTextbox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(40, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 164);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Join Server";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CreateServerButton);
            this.groupBox1.Controls.Add(this.CreateServerTextbox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(40, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 155);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Server";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.ChatTextbox);
            this.tabPage2.Controls.Add(this.SendButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TypeTextbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chatbox";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ChatMessage App";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CreateServerTextbox;
        private System.Windows.Forms.Button CreateServerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox JoinServerTextbox;
        private System.Windows.Forms.Button JoinServerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerIPTextbox;
        private System.Windows.Forms.TextBox ChatTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TypeTextbox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PasswordButton;
        private System.Windows.Forms.Button UsernameButton;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label label5;
    }
}
