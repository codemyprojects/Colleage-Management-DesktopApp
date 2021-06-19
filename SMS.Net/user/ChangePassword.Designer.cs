namespace SMS.Net.user
{
    partial class ChangePassword
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RetypePasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.OldPasswordTextBox = new System.Windows.Forms.TextBox();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.RoleLabel);
            this.groupBox1.Controls.Add(this.RoleComboBox);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 230);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Password";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Khaki;
            this.panel2.Controls.Add(this.UserNameTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.RetypePasswordTextBox);
            this.panel2.Controls.Add(this.NewPasswordTextBox);
            this.panel2.Controls.Add(this.OldPasswordTextBox);
            this.panel2.Location = new System.Drawing.Point(7, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 156);
            this.panel2.TabIndex = 16;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(188, 13);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(242, 22);
            this.UserNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Retype New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // RetypePasswordTextBox
            // 
            this.RetypePasswordTextBox.Location = new System.Drawing.Point(188, 117);
            this.RetypePasswordTextBox.Name = "RetypePasswordTextBox";
            this.RetypePasswordTextBox.PasswordChar = '*';
            this.RetypePasswordTextBox.Size = new System.Drawing.Size(242, 22);
            this.RetypePasswordTextBox.TabIndex = 3;
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.Location = new System.Drawing.Point(188, 85);
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.PasswordChar = '*';
            this.NewPasswordTextBox.Size = new System.Drawing.Size(242, 22);
            this.NewPasswordTextBox.TabIndex = 2;
            this.NewPasswordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewPasswordTextBox_MouseClick);
            // 
            // OldPasswordTextBox
            // 
            this.OldPasswordTextBox.Location = new System.Drawing.Point(188, 51);
            this.OldPasswordTextBox.Name = "OldPasswordTextBox";
            this.OldPasswordTextBox.PasswordChar = '*';
            this.OldPasswordTextBox.Size = new System.Drawing.Size(242, 22);
            this.OldPasswordTextBox.TabIndex = 1;
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(10, 26);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(98, 16);
            this.RoleLabel.TabIndex = 5;
            this.RoleLabel.Text = "Choose Role";
            this.RoleLabel.Visible = false;
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Location = new System.Drawing.Point(118, 20);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(242, 24);
            this.RoleComboBox.TabIndex = 2;
            this.RoleComboBox.Visible = false;
            this.RoleComboBox.SelectedIndexChanged += new System.EventHandler(this.RoleComboBox_SelectedIndexChanged);
            this.RoleComboBox.SelectionChangeCommitted += new System.EventHandler(this.RoleComboBox_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.ChangeButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Location = new System.Drawing.Point(7, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 42);
            this.panel1.TabIndex = 12;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(399, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(58, 26);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "&Exit";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(250, 9);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(69, 25);
            this.ChangeButton.TabIndex = 11;
            this.ChangeButton.Text = "&Change";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(325, 9);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(68, 26);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 243);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox RetypePasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.TextBox NewPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OldPasswordTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Panel panel2;
    }
}