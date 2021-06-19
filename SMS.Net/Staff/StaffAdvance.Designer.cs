namespace SMS.Net.Staff
{
    partial class StaffAdvance
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.StaffNameComboBox = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.adavanceStaffIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advanceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advanceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeAdvanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet1 = new SMS.Net.SMSDataSet1();
            this.employeeAdvanceTableAdapter = new SMS.Net.SMSDataSet1TableAdapters.EmployeeAdvanceTableAdapter();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAdvanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.StaffNameComboBox);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(39, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 188);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(483, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 36);
            this.button3.TabIndex = 16;
            this.button3.Text = "&Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(575, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "&Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "&Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(456, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(198, 21);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // StaffNameComboBox
            // 
            this.StaffNameComboBox.FormattingEnabled = true;
            this.StaffNameComboBox.Location = new System.Drawing.Point(94, 34);
            this.StaffNameComboBox.Name = "StaffNameComboBox";
            this.StaffNameComboBox.Size = new System.Drawing.Size(197, 21);
            this.StaffNameComboBox.TabIndex = 12;
            this.StaffNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.StaffNameComboBox_SelectionChangeCommitted);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(459, 63);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 20);
            this.textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(197, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(197, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Advace Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Basic Salary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Advace Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Post";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(36, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 268);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Records";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adavanceStaffIdDataGridViewTextBoxColumn,
            this.staffIdDataGridViewTextBoxColumn,
            this.advanceIdDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.advanceAmountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.employeeAdvanceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // adavanceStaffIdDataGridViewTextBoxColumn
            // 
            this.adavanceStaffIdDataGridViewTextBoxColumn.DataPropertyName = "AdavanceStaffId";
            this.adavanceStaffIdDataGridViewTextBoxColumn.HeaderText = "AdavanceStaffId";
            this.adavanceStaffIdDataGridViewTextBoxColumn.Name = "adavanceStaffIdDataGridViewTextBoxColumn";
            this.adavanceStaffIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // staffIdDataGridViewTextBoxColumn
            // 
            this.staffIdDataGridViewTextBoxColumn.DataPropertyName = "StaffId";
            this.staffIdDataGridViewTextBoxColumn.HeaderText = "StaffId";
            this.staffIdDataGridViewTextBoxColumn.Name = "staffIdDataGridViewTextBoxColumn";
            // 
            // advanceIdDataGridViewTextBoxColumn
            // 
            this.advanceIdDataGridViewTextBoxColumn.DataPropertyName = "AdvanceId";
            this.advanceIdDataGridViewTextBoxColumn.HeaderText = "AdvanceId";
            this.advanceIdDataGridViewTextBoxColumn.Name = "advanceIdDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // advanceAmountDataGridViewTextBoxColumn
            // 
            this.advanceAmountDataGridViewTextBoxColumn.DataPropertyName = "AdvanceAmount";
            this.advanceAmountDataGridViewTextBoxColumn.HeaderText = "AdvanceAmount";
            this.advanceAmountDataGridViewTextBoxColumn.Name = "advanceAmountDataGridViewTextBoxColumn";
            // 
            // employeeAdvanceBindingSource
            // 
            this.employeeAdvanceBindingSource.DataMember = "EmployeeAdvance";
            this.employeeAdvanceBindingSource.DataSource = this.sMSDataSet1;
            // 
            // sMSDataSet1
            // 
            this.sMSDataSet1.DataSetName = "SMSDataSet1";
            this.sMSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeAdvanceTableAdapter
            // 
            this.employeeAdvanceTableAdapter.ClearBeforeFill = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(385, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 33);
            this.button4.TabIndex = 17;
            this.button4.Text = "&Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // StaffAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "StaffAdvance";
            this.Text = "StaffAdvance";
            this.Load += new System.EventHandler(this.StaffAdvance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAdvanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox StaffNameComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SMSDataSet1 sMSDataSet1;
        private System.Windows.Forms.BindingSource employeeAdvanceBindingSource;
        private SMSDataSet1TableAdapters.EmployeeAdvanceTableAdapter employeeAdvanceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn adavanceStaffIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn advanceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn advanceAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
    }
}