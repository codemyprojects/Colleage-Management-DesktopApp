namespace SMS.Net.Staff
{
    partial class EmployeeAllowanceDetail
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.AllowanceComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PostTextBox = new System.Windows.Forms.TextBox();
            this.BasicSalaryComboBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Post = new System.Windows.Forms.Label();
            this.StaffNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-1, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 401);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EmployeeAllowanceDetail";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(661, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkKhaki;
            this.groupBox2.Location = new System.Drawing.Point(23, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 178);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allowance Detail";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(695, 158);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.AmountTextBox);
            this.panel2.Controls.Add(this.AllowanceComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(389, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 124);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(172, 50);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(129, 22);
            this.AmountTextBox.TabIndex = 3;
            // 
            // AllowanceComboBox
            // 
            this.AllowanceComboBox.FormattingEnabled = true;
            this.AllowanceComboBox.Location = new System.Drawing.Point(173, 16);
            this.AllowanceComboBox.Name = "AllowanceComboBox";
            this.AllowanceComboBox.Size = new System.Drawing.Size(129, 24);
            this.AllowanceComboBox.TabIndex = 2;
            this.AllowanceComboBox.SelectedIndexChanged += new System.EventHandler(this.AllowanceComboBox_SelectedIndexChanged);
            this.AllowanceComboBox.SelectionChangeCommitted += new System.EventHandler(this.AllowanceComboBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Allowance Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Allowance Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel1.Controls.Add(this.PostTextBox);
            this.panel1.Controls.Add(this.BasicSalaryComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Post);
            this.panel1.Controls.Add(this.StaffNameComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(22, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 121);
            this.panel1.TabIndex = 0;
            // 
            // PostTextBox
            // 
            this.PostTextBox.Location = new System.Drawing.Point(137, 46);
            this.PostTextBox.Name = "PostTextBox";
            this.PostTextBox.Size = new System.Drawing.Size(185, 22);
            this.PostTextBox.TabIndex = 23;
            // 
            // BasicSalaryComboBox
            // 
            this.BasicSalaryComboBox.Location = new System.Drawing.Point(135, 84);
            this.BasicSalaryComboBox.Name = "BasicSalaryComboBox";
            this.BasicSalaryComboBox.Size = new System.Drawing.Size(188, 22);
            this.BasicSalaryComboBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Basic Salary";
            // 
            // Post
            // 
            this.Post.AutoSize = true;
            this.Post.Location = new System.Drawing.Point(26, 52);
            this.Post.Name = "Post";
            this.Post.Size = new System.Drawing.Size(35, 16);
            this.Post.TabIndex = 19;
            this.Post.Text = "Post";
            // 
            // StaffNameComboBox
            // 
            this.StaffNameComboBox.FormattingEnabled = true;
            this.StaffNameComboBox.Location = new System.Drawing.Point(135, 14);
            this.StaffNameComboBox.Name = "StaffNameComboBox";
            this.StaffNameComboBox.Size = new System.Drawing.Size(188, 24);
            this.StaffNameComboBox.TabIndex = 18;
            this.StaffNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.StaffNameComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Staff Name";
            // 
            // EmployeeAllowanceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 401);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeeAllowanceDetail";
            this.Text = "EmployeeAllowanceDetail";
            this.Load += new System.EventHandler(this.EmployeeAllowanceDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.ComboBox AllowanceComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PostTextBox;
        private System.Windows.Forms.TextBox BasicSalaryComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Post;
        private System.Windows.Forms.ComboBox StaffNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}