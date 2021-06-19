namespace SMS.Net.FeeStructure
{
    partial class ClassWiseFeeDetail
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
            this.ShowButton = new System.Windows.Forms.Button();
            this.dataGridViewFeeDetails = new System.Windows.Forms.DataGridView();
            this.FeeStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ClassComboBox = new System.Windows.Forms.Label();
            this.AcademicYearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ShowButton);
            this.groupBox1.Controls.Add(this.dataGridViewFeeDetails);
            this.groupBox1.Controls.Add(this.FeeStatusComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.ClassComboBox);
            this.groupBox1.Controls.Add(this.AcademicYearComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Wise Fees";
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(385, 97);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(81, 24);
            this.ShowButton.TabIndex = 18;
            this.ShowButton.Text = "&Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // dataGridViewFeeDetails
            // 
            this.dataGridViewFeeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeeDetails.Location = new System.Drawing.Point(17, 136);
            this.dataGridViewFeeDetails.Name = "dataGridViewFeeDetails";
            this.dataGridViewFeeDetails.Size = new System.Drawing.Size(675, 268);
            this.dataGridViewFeeDetails.TabIndex = 17;
            // 
            // FeeStatusComboBox
            // 
            this.FeeStatusComboBox.FormattingEnabled = true;
            this.FeeStatusComboBox.Location = new System.Drawing.Point(140, 96);
            this.FeeStatusComboBox.Name = "FeeStatusComboBox";
            this.FeeStatusComboBox.Size = new System.Drawing.Size(234, 24);
            this.FeeStatusComboBox.TabIndex = 16;
            this.FeeStatusComboBox.SelectionChangeCommitted += new System.EventHandler(this.FeeStatusComboBox_SelectionChangeCommitted_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "FeeStatus";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(140, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 24);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.AutoSize = true;
            this.ClassComboBox.Location = new System.Drawing.Point(14, 68);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(42, 16);
            this.ClassComboBox.TabIndex = 13;
            this.ClassComboBox.Text = "Class";
            // 
            // AcademicYearComboBox
            // 
            this.AcademicYearComboBox.FormattingEnabled = true;
            this.AcademicYearComboBox.Location = new System.Drawing.Point(140, 32);
            this.AcademicYearComboBox.Name = "AcademicYearComboBox";
            this.AcademicYearComboBox.Size = new System.Drawing.Size(234, 24);
            this.AcademicYearComboBox.TabIndex = 12;
            this.AcademicYearComboBox.SelectedIndexChanged += new System.EventHandler(this.AcademicYearComboBox_SelectedIndexChanged);
            this.AcademicYearComboBox.SelectionChangeCommitted += new System.EventHandler(this.AcademicYearComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Academic Year";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 24);
            this.button1.TabIndex = 19;
            this.button1.Text = "&Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassWiseFeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 453);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClassWiseFeeDetail";
            this.Text = "ClassWiseFeeDetail";
            this.Load += new System.EventHandler(this.ClassWiseFeeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox FeeStatusComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ClassComboBox;
        private System.Windows.Forms.ComboBox AcademicYearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewFeeDetails;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Button button1;
    }
}