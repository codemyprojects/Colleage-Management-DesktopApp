namespace SMS.Net.Results
{
    partial class ClasswiseResult
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
            this.label1 = new System.Windows.Forms.Label();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AcademicYearComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ExamTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class";
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.CausesValidation = false;
            this.ClassComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassComboBox.Location = new System.Drawing.Point(157, 74);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(176, 24);
            this.ClassComboBox.TabIndex = 1;
            this.ClassComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClassComboBox_SelectionChangeCommitted);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkKhaki;
            this.dataGridView1.Location = new System.Drawing.Point(6, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 299);
            this.dataGridView1.TabIndex = 2;
            // 
            // AcademicYearComboBox
            // 
            this.AcademicYearComboBox.CausesValidation = false;
            this.AcademicYearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcademicYearComboBox.FormattingEnabled = true;
            this.AcademicYearComboBox.Location = new System.Drawing.Point(160, 12);
            this.AcademicYearComboBox.Name = "AcademicYearComboBox";
            this.AcademicYearComboBox.Size = new System.Drawing.Size(173, 24);
            this.AcademicYearComboBox.TabIndex = 15;
            this.AcademicYearComboBox.SelectionChangeCommitted += new System.EventHandler(this.AcademicYearComboBox_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.CausesValidation = false;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Academic Year";
            // 
            // ExamTypeComboBox
            // 
            this.ExamTypeComboBox.CausesValidation = false;
            this.ExamTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExamTypeComboBox.FormattingEnabled = true;
            this.ExamTypeComboBox.Location = new System.Drawing.Point(160, 43);
            this.ExamTypeComboBox.Name = "ExamTypeComboBox";
            this.ExamTypeComboBox.Size = new System.Drawing.Size(173, 24);
            this.ExamTypeComboBox.TabIndex = 13;
            this.ExamTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.ExamTypeComboBox_SelectionChangeCommitted);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.CausesValidation = false;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(17, 47);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 16);
            this.label30.TabIndex = 12;
            this.label30.Text = "Exam Type";
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(362, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Show Records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "&Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClasswiseResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 424);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AcademicYearComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ExamTypeComboBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.label1);
            this.Name = "ClasswiseResult";
            this.Text = "ClasswiseResult";
            this.Load += new System.EventHandler(this.ClasswiseResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox AcademicYearComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ExamTypeComboBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}