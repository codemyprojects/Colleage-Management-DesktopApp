namespace SMS.Net.Reports
{
    partial class StudentResultReport
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
            this.ExamTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.AcademicYearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ExamTypeComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.ClassLabel);
            this.groupBox1.Controls.Add(this.AcademicYearComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Student Detail";
            // 
            // ExamTypeComboBox
            // 
            this.ExamTypeComboBox.FormattingEnabled = true;
            this.ExamTypeComboBox.Location = new System.Drawing.Point(191, 80);
            this.ExamTypeComboBox.Name = "ExamTypeComboBox";
            this.ExamTypeComboBox.Size = new System.Drawing.Size(182, 24);
            this.ExamTypeComboBox.TabIndex = 8;
            this.ExamTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.ExamTypeComboBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Exam Type";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(191, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassLabel.Location = new System.Drawing.Point(18, 52);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(42, 16);
            this.ClassLabel.TabIndex = 2;
            this.ClassLabel.Text = "Class";
            // 
            // AcademicYearComboBox
            // 
            this.AcademicYearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcademicYearComboBox.FormattingEnabled = true;
            this.AcademicYearComboBox.Location = new System.Drawing.Point(190, 24);
            this.AcademicYearComboBox.Name = "AcademicYearComboBox";
            this.AcademicYearComboBox.Size = new System.Drawing.Size(183, 24);
            this.AcademicYearComboBox.TabIndex = 1;
            this.AcademicYearComboBox.SelectionChangeCommitted += new System.EventHandler(this.AcademicYearComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Academic Year";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 31);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Show";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StudentResultReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 163);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentResultReport";
            this.Text = "StudentResultReport";
            this.Load += new System.EventHandler(this.StudentResultReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ClassLabel;
        public System.Windows.Forms.ComboBox AcademicYearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ExamTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}