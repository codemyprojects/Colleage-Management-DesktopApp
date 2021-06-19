namespace SMS.Net.FeeStructure
{
    partial class StudentFeePayment
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PayButtton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DueAmountTextBox = new System.Windows.Forms.TextBox();
            this.PaidAmountTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalFeeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentNameComboBox = new System.Windows.Forms.ComboBox();
            this.AcademicYearComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.RollNo = new System.Windows.Forms.TextBox();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EndComboBox = new System.Windows.Forms.ComboBox();
            this.StartComboBox = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 617);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Payment";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.PayButtton);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.DueAmountTextBox);
            this.panel3.Controls.Add(this.PaidAmountTextBox);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.TotalFeeTextBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(4, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 197);
            this.panel3.TabIndex = 39;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(381, 127);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(186, 43);
            this.richTextBox1.TabIndex = 49;
            this.richTextBox1.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "Narration";
            // 
            // PayButtton
            // 
            this.PayButtton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PayButtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayButtton.Location = new System.Drawing.Point(573, 126);
            this.PayButtton.Name = "PayButtton";
            this.PayButtton.Size = new System.Drawing.Size(73, 42);
            this.PayButtton.TabIndex = 47;
            this.PayButtton.Text = "&Pay";
            this.PayButtton.UseVisualStyleBackColor = false;
            this.PayButtton.Click += new System.EventHandler(this.PayButtton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(381, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 22);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "Date";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 44;
            this.label7.Text = "Due Amount";
            // 
            // DueAmountTextBox
            // 
            this.DueAmountTextBox.Location = new System.Drawing.Point(382, 99);
            this.DueAmountTextBox.Name = "DueAmountTextBox";
            this.DueAmountTextBox.Size = new System.Drawing.Size(185, 22);
            this.DueAmountTextBox.TabIndex = 43;
            // 
            // PaidAmountTextBox
            // 
            this.PaidAmountTextBox.Location = new System.Drawing.Point(382, 73);
            this.PaidAmountTextBox.Name = "PaidAmountTextBox";
            this.PaidAmountTextBox.Size = new System.Drawing.Size(185, 22);
            this.PaidAmountTextBox.TabIndex = 42;
            this.PaidAmountTextBox.TextChanged += new System.EventHandler(this.PaidAmountTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Paid Amount";
            // 
            // TotalFeeTextBox
            // 
            this.TotalFeeTextBox.Location = new System.Drawing.Point(382, 47);
            this.TotalFeeTextBox.Name = "TotalFeeTextBox";
            this.TotalFeeTextBox.Size = new System.Drawing.Size(185, 22);
            this.TotalFeeTextBox.TabIndex = 40;
            this.TotalFeeTextBox.TextChanged += new System.EventHandler(this.TotalFeeTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total Fee";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(706, 300);
            this.dataGridView1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.StudentNameComboBox);
            this.panel2.Controls.Add(this.AcademicYearComboBox);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.RollNo);
            this.panel2.Controls.Add(this.ClassComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.SectionComboBox);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Location = new System.Drawing.Point(6, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 73);
            this.panel2.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Roll No.";
            // 
            // StudentNameComboBox
            // 
            this.StudentNameComboBox.FormattingEnabled = true;
            this.StudentNameComboBox.Location = new System.Drawing.Point(440, 37);
            this.StudentNameComboBox.Name = "StudentNameComboBox";
            this.StudentNameComboBox.Size = new System.Drawing.Size(178, 24);
            this.StudentNameComboBox.TabIndex = 37;
            this.StudentNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.StudentNameComboBox_SelectionChangeCommitted);
            // 
            // AcademicYearComboBox
            // 
            this.AcademicYearComboBox.FormattingEnabled = true;
            this.AcademicYearComboBox.Location = new System.Drawing.Point(4, 37);
            this.AcademicYearComboBox.Name = "AcademicYearComboBox";
            this.AcademicYearComboBox.Size = new System.Drawing.Size(143, 24);
            this.AcademicYearComboBox.TabIndex = 36;
            this.AcademicYearComboBox.SelectionChangeCommitted += new System.EventHandler(this.AcademicYearComboBox_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 35;
            this.label15.Text = "Year";
            // 
            // RollNo
            // 
            this.RollNo.Location = new System.Drawing.Point(624, 39);
            this.RollNo.Name = "RollNo";
            this.RollNo.Size = new System.Drawing.Size(79, 22);
            this.RollNo.TabIndex = 34;
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(227, 38);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(94, 24);
            this.ClassComboBox.TabIndex = 33;
            this.ClassComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClassComboBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Section";
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Location = new System.Drawing.Point(364, 37);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(70, 24);
            this.SectionComboBox.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(256, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 16);
            this.label29.TabIndex = 30;
            this.label29.Text = "Class";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(65, 632);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 42);
            this.panel1.TabIndex = 31;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(408, 56);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(57, 29);
            this.AddButton.TabIndex = 31;
            this.AddButton.Text = "&Ok";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.EndComboBox);
            this.groupBox2.Controls.Add(this.StartComboBox);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(8, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 76);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // EndComboBox
            // 
            this.EndComboBox.FormattingEnabled = true;
            this.EndComboBox.Location = new System.Drawing.Point(254, 42);
            this.EndComboBox.Name = "EndComboBox";
            this.EndComboBox.Size = new System.Drawing.Size(106, 21);
            this.EndComboBox.TabIndex = 3;
            // 
            // StartComboBox
            // 
            this.StartComboBox.FormattingEnabled = true;
            this.StartComboBox.Location = new System.Drawing.Point(98, 42);
            this.StartComboBox.Name = "StartComboBox";
            this.StartComboBox.Size = new System.Drawing.Size(106, 21);
            this.StartComboBox.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Multiple ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // StudentFeePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 666);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentFeePayment";
            this.Text = "StudentFeePayment";
            this.Load += new System.EventHandler(this.StudentFeePayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StudentNameComboBox;
        private System.Windows.Forms.ComboBox AcademicYearComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox RollNo;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DueAmountTextBox;
        private System.Windows.Forms.TextBox PaidAmountTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalFeeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button PayButtton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EndComboBox;
        private System.Windows.Forms.ComboBox StartComboBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label9;
    }
}