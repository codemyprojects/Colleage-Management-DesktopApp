namespace SMS.Net.FeeStructure.Common
{
    partial class ReligionInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReligionTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sMSDataSet8 = new SMS.Net.SMSDataSet8();
            this.religionInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.religionInfoTableAdapter = new SMS.Net.SMSDataSet8TableAdapters.ReligionInfoTableAdapter();
            this.religionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.religionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.religionInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ReligionTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Religion Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Religion Name";
            // 
            // ReligionTextBox
            // 
            this.ReligionTextBox.Location = new System.Drawing.Point(119, 25);
            this.ReligionTextBox.Name = "ReligionTextBox";
            this.ReligionTextBox.Size = new System.Drawing.Size(246, 20);
            this.ReligionTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(321, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 32);
            this.button3.TabIndex = 4;
            this.button3.Text = "&Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(448, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "&Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.religionIdDataGridViewTextBoxColumn,
            this.religionNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.religionInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(22, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(558, 190);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // sMSDataSet8
            // 
            this.sMSDataSet8.DataSetName = "SMSDataSet8";
            this.sMSDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // religionInfoBindingSource
            // 
            this.religionInfoBindingSource.DataMember = "ReligionInfo";
            this.religionInfoBindingSource.DataSource = this.sMSDataSet8;
            // 
            // religionInfoTableAdapter
            // 
            this.religionInfoTableAdapter.ClearBeforeFill = true;
            // 
            // religionIdDataGridViewTextBoxColumn
            // 
            this.religionIdDataGridViewTextBoxColumn.DataPropertyName = "ReligionId";
            this.religionIdDataGridViewTextBoxColumn.HeaderText = "ReligionId";
            this.religionIdDataGridViewTextBoxColumn.Name = "religionIdDataGridViewTextBoxColumn";
            this.religionIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // religionNameDataGridViewTextBoxColumn
            // 
            this.religionNameDataGridViewTextBoxColumn.DataPropertyName = "ReligionName";
            this.religionNameDataGridViewTextBoxColumn.HeaderText = "ReligionName";
            this.religionNameDataGridViewTextBoxColumn.Name = "religionNameDataGridViewTextBoxColumn";
            // 
            // ReligionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReligionInfo";
            this.Text = "ReligionInfo";
            this.Load += new System.EventHandler(this.ReligionInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.religionInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ReligionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SMSDataSet8 sMSDataSet8;
        private System.Windows.Forms.BindingSource religionInfoBindingSource;
        private SMSDataSet8TableAdapters.ReligionInfoTableAdapter religionInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn religionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn religionNameDataGridViewTextBoxColumn;
    }
}