namespace SMS.Net.Staff
{
    partial class AllowanceDefine
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
            this.AllowanceComboBox = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CLoseButton = new System.Windows.Forms.Button();
            this.DeleteButtton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.AllowanceAmountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.AllowanceComboBox);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.AllowanceAmountTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(648, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allowance Define";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // AllowanceComboBox
            // 
            this.AllowanceComboBox.FormattingEnabled = true;
            this.AllowanceComboBox.Location = new System.Drawing.Point(229, 55);
            this.AllowanceComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.AllowanceComboBox.Name = "AllowanceComboBox";
            this.AllowanceComboBox.Size = new System.Drawing.Size(241, 24);
            this.AllowanceComboBox.TabIndex = 19;
            this.AllowanceComboBox.SelectionChangeCommitted += new System.EventHandler(this.AllowanceComboBox_SelectionChangeCommitted);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(229, 96);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(242, 24);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Post";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.CLoseButton);
            this.panel1.Controls.Add(this.DeleteButtton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.AddNewButton);
            this.panel1.Location = new System.Drawing.Point(11, 219);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 68);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(281, 14);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(80, 38);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // CLoseButton
            // 
            this.CLoseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLoseButton.Location = new System.Drawing.Point(529, 14);
            this.CLoseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CLoseButton.Name = "CLoseButton";
            this.CLoseButton.Size = new System.Drawing.Size(72, 38);
            this.CLoseButton.TabIndex = 4;
            this.CLoseButton.Text = "&Exit";
            this.CLoseButton.UseVisualStyleBackColor = true;
            this.CLoseButton.Click += new System.EventHandler(this.CLoseButton_Click);
            // 
            // DeleteButtton
            // 
            this.DeleteButtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButtton.Location = new System.Drawing.Point(370, 15);
            this.DeleteButtton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButtton.Name = "DeleteButtton";
            this.DeleteButtton.Size = new System.Drawing.Size(75, 38);
            this.DeleteButtton.TabIndex = 3;
            this.DeleteButtton.Text = "Delete";
            this.DeleteButtton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(189, 14);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(84, 38);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(104, 15);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(77, 38);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddNewButton
            // 
            this.AddNewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewButton.Location = new System.Drawing.Point(16, 15);
            this.AddNewButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(80, 38);
            this.AddNewButton.TabIndex = 0;
            this.AddNewButton.Text = "Add New";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // AllowanceAmountTextBox
            // 
            this.AllowanceAmountTextBox.Location = new System.Drawing.Point(229, 140);
            this.AllowanceAmountTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AllowanceAmountTextBox.Name = "AllowanceAmountTextBox";
            this.AllowanceAmountTextBox.Size = new System.Drawing.Size(242, 22);
            this.AllowanceAmountTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Allowance Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allowance Name";
            // 
            // AllowanceDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 322);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllowanceDefine";
            this.Text = "AllowanceDefine";
            this.Load += new System.EventHandler(this.AllowanceDefine_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AllowanceAmountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button UpdateButton;
        //private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CLoseButton;
        private System.Windows.Forms.Button DeleteButtton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.ComboBox AllowanceComboBox;
    }
}