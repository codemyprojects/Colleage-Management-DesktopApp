namespace SMS.Net.FeeStructure
{
    partial class ViewFeeStructure
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FeeCodeComboBox = new System.Windows.Forms.ComboBox();
            this.FeeDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FeeDescriptionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FeeAmountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FeeNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.FeeCodeComboBox);
            this.groupBox1.Controls.Add(this.FeeDescriptionRichTextBox);
            this.groupBox1.Controls.Add(this.FeeDescriptionLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.EditButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.FeeAmountTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FeeNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ClassComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 460);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Fee Structure";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(684, 170);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // FeeCodeComboBox
            // 
            this.FeeCodeComboBox.FormattingEnabled = true;
            this.FeeCodeComboBox.Location = new System.Drawing.Point(147, 26);
            this.FeeCodeComboBox.Name = "FeeCodeComboBox";
            this.FeeCodeComboBox.Size = new System.Drawing.Size(216, 24);
            this.FeeCodeComboBox.TabIndex = 14;
            // 
            // FeeDescriptionRichTextBox
            // 
            this.FeeDescriptionRichTextBox.Location = new System.Drawing.Point(145, 140);
            this.FeeDescriptionRichTextBox.Name = "FeeDescriptionRichTextBox";
            this.FeeDescriptionRichTextBox.Size = new System.Drawing.Size(219, 48);
            this.FeeDescriptionRichTextBox.TabIndex = 13;
            this.FeeDescriptionRichTextBox.Text = "";
            // 
            // FeeDescriptionLabel
            // 
            this.FeeDescriptionLabel.AutoSize = true;
            this.FeeDescriptionLabel.Location = new System.Drawing.Point(30, 160);
            this.FeeDescriptionLabel.Name = "FeeDescriptionLabel";
            this.FeeDescriptionLabel.Size = new System.Drawing.Size(103, 16);
            this.FeeDescriptionLabel.TabIndex = 12;
            this.FeeDescriptionLabel.Text = "Fee Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fee Code";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(236, 208);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(61, 34);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(303, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(169, 208);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(61, 34);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "&Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "(e.g Transportation,Tution)";
            // 
            // FeeAmountTextBox
            // 
            this.FeeAmountTextBox.Location = new System.Drawing.Point(145, 113);
            this.FeeAmountTextBox.Name = "FeeAmountTextBox";
            this.FeeAmountTextBox.Size = new System.Drawing.Size(219, 22);
            this.FeeAmountTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fee Amount(Rs)";
            // 
            // FeeNameTextBox
            // 
            this.FeeNameTextBox.Location = new System.Drawing.Point(146, 85);
            this.FeeNameTextBox.Name = "FeeNameTextBox";
            this.FeeNameTextBox.Size = new System.Drawing.Size(218, 22);
            this.FeeNameTextBox.TabIndex = 3;
            this.FeeNameTextBox.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fee Name";
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(145, 56);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(219, 24);
            this.ClassComboBox.TabIndex = 1;
            this.ClassComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassComboBox_SelectedIndexChanged);
            this.ClassComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClassComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class ";
            // 
            // ViewFeeStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 500);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewFeeStructure";
            this.Text = "ViewFeeStructure";
            this.Load += new System.EventHandler(this.ViewFeeStructure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox FeeDescriptionRichTextBox;
        private System.Windows.Forms.Label FeeDescriptionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FeeAmountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FeeNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FeeCodeComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}