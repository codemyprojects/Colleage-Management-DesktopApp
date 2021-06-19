namespace SMS.Net.Class
{
    partial class EditClass
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CodeComboBox = new System.Windows.Forms.ComboBox();
            this.b = new System.Windows.Forms.Label();
            this.ScheduleComboBox = new System.Windows.Forms.ComboBox();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Subject3TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Subject2TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Subject1TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.ClassTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.CodeComboBox);
            this.groupBox1.Controls.Add(this.b);
            this.groupBox1.Controls.Add(this.ScheduleComboBox);
            this.groupBox1.Controls.Add(this.SectionComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.EditButton);
            this.groupBox1.Controls.Add(this.ClassTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 496);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Class Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(270, 177);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(62, 29);
            this.DeleteButton.TabIndex = 40;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(757, 268);
            this.dataGridView1.TabIndex = 39;
            // 
            // CodeComboBox
            // 
            this.CodeComboBox.FormattingEnabled = true;
            this.CodeComboBox.Location = new System.Drawing.Point(203, 27);
            this.CodeComboBox.Name = "CodeComboBox";
            this.CodeComboBox.Size = new System.Drawing.Size(199, 24);
            this.CodeComboBox.TabIndex = 38;
            this.CodeComboBox.SelectionChangeCommitted += new System.EventHandler(this.CodeComboBox_SelectionChangeCommitted);
            // 
            // b
            // 
            this.b.AutoSize = true;
            this.b.BackColor = System.Drawing.Color.Olive;
            this.b.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b.Location = new System.Drawing.Point(477, 26);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(62, 18);
            this.b.TabIndex = 36;
            this.b.Text = "Subects";
            // 
            // ScheduleComboBox
            // 
            this.ScheduleComboBox.FormattingEnabled = true;
            this.ScheduleComboBox.Items.AddRange(new object[] {
            "Morning\t",
            "Day"});
            this.ScheduleComboBox.Location = new System.Drawing.Point(201, 124);
            this.ScheduleComboBox.Name = "ScheduleComboBox";
            this.ScheduleComboBox.Size = new System.Drawing.Size(201, 24);
            this.ScheduleComboBox.TabIndex = 37;
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Items.AddRange(new object[] {
            "A",
            "B"});
            this.SectionComboBox.Location = new System.Drawing.Point(202, 89);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(201, 24);
            this.SectionComboBox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Class Scedule";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Section";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Olive;
            this.panel1.Controls.Add(this.Subject3TextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Subject2TextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Subject1TextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(417, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 126);
            this.panel1.TabIndex = 35;
            // 
            // Subject3TextBox
            // 
            this.Subject3TextBox.Location = new System.Drawing.Point(94, 93);
            this.Subject3TextBox.Name = "Subject3TextBox";
            this.Subject3TextBox.Size = new System.Drawing.Size(127, 22);
            this.Subject3TextBox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Subject3";
            // 
            // Subject2TextBox
            // 
            this.Subject2TextBox.Location = new System.Drawing.Point(93, 64);
            this.Subject2TextBox.Name = "Subject2TextBox";
            this.Subject2TextBox.Size = new System.Drawing.Size(127, 22);
            this.Subject2TextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Subject2";
            // 
            // Subject1TextBox
            // 
            this.Subject1TextBox.Location = new System.Drawing.Point(93, 38);
            this.Subject1TextBox.Name = "Subject1TextBox";
            this.Subject1TextBox.Size = new System.Drawing.Size(125, 22);
            this.Subject1TextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Subject1";
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(343, 177);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(59, 30);
            this.CancelButton.TabIndex = 31;
            this.CancelButton.Text = "&Close";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(196, 176);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(62, 30);
            this.SaveButton.TabIndex = 30;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(143, 176);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(52, 31);
            this.EditButton.TabIndex = 29;
            this.EditButton.Text = "&Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ClassTextBox
            // 
            this.ClassTextBox.Location = new System.Drawing.Point(203, 58);
            this.ClassTextBox.Name = "ClassTextBox";
            this.ClassTextBox.Size = new System.Drawing.Size(200, 22);
            this.ClassTextBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Class ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Class Code";
            // 
            // EditClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 510);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditClass";
            this.Text = "EditClass";
            this.Load += new System.EventHandler(this.EditClass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.ComboBox ScheduleComboBox;
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Subject3TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Subject2TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Subject1TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TextBox ClassTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CodeComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DeleteButton;

    }
}