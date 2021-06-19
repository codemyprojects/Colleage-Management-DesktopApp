namespace SMS.Net.Class
{
    partial class ClassAdd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.classIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet = new SMS.Net.SMSDataSet();
            this.DeleteButtion = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.ClassTextBox = new System.Windows.Forms.TextBox();
            this.ClassCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.classInfoTableAdapter = new SMS.Net.SMSDataSetTableAdapters.ClassInfoTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.DeleteButtion);
            this.groupBox1.Controls.Add(this.UpdateButton);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.AddNewButton);
            this.groupBox1.Controls.Add(this.ClassTextBox);
            this.groupBox1.Controls.Add(this.ClassCodeTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classIdDataGridViewTextBoxColumn,
            this.classDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.classInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(255, 180);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            this.classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            this.classIdDataGridViewTextBoxColumn.HeaderText = "ClassId";
            this.classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            this.classIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            this.classDataGridViewTextBoxColumn.HeaderText = "Class";
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            // 
            // classInfoBindingSource
            // 
            this.classInfoBindingSource.DataMember = "ClassInfo";
            this.classInfoBindingSource.DataSource = this.sMSDataSet;
            // 
            // sMSDataSet
            // 
            this.sMSDataSet.DataSetName = "SMSDataSet";
            this.sMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DeleteButtion
            // 
            this.DeleteButtion.Location = new System.Drawing.Point(300, 135);
            this.DeleteButtion.Name = "DeleteButtion";
            this.DeleteButtion.Size = new System.Drawing.Size(75, 23);
            this.DeleteButtion.TabIndex = 21;
            this.DeleteButtion.Text = "&Delete";
            this.DeleteButtion.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(300, 112);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 20;
            this.UpdateButton.Text = "&Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(300, 159);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 19;
            this.CancelButton.Text = "&Exit";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(300, 62);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddNewButton
            // 
            this.AddNewButton.Location = new System.Drawing.Point(300, 38);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(75, 23);
            this.AddNewButton.TabIndex = 16;
            this.AddNewButton.Text = "&New";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassTextBox
            // 
            this.ClassTextBox.Location = new System.Drawing.Point(100, 66);
            this.ClassTextBox.Name = "ClassTextBox";
            this.ClassTextBox.Size = new System.Drawing.Size(159, 20);
            this.ClassTextBox.TabIndex = 15;
            // 
            // ClassCodeTextBox
            // 
            this.ClassCodeTextBox.Location = new System.Drawing.Point(100, 29);
            this.ClassCodeTextBox.Name = "ClassCodeTextBox";
            this.ClassCodeTextBox.Size = new System.Drawing.Size(159, 20);
            this.ClassCodeTextBox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Class ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Class Code";
            // 
            // classInfoTableAdapter
            // 
            this.classInfoTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "&Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClassAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 340);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClassAdd";
            this.Text = "ClassAdd";
            this.Load += new System.EventHandler(this.ClassAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteButtion;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.TextBox ClassTextBox;
        private System.Windows.Forms.TextBox ClassCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SMSDataSet sMSDataSet;
        private System.Windows.Forms.BindingSource classInfoBindingSource;
        private SMSDataSetTableAdapters.ClassInfoTableAdapter classInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;

    }
}