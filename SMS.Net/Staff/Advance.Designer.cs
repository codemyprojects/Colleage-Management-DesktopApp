namespace SMS.Net.Staff
{
    partial class Advance
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CLoseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sMSDataSet7 = new SMS.Net.SMSDataSet7();
            this.advanceInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.advanceInfoTableAdapter = new SMS.Net.SMSDataSet7TableAdapters.AdvanceInfoTableAdapter();
            this.advanceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advanceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advanceInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.advanceIdDataGridViewTextBoxColumn,
            this.advanceNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.advanceInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(456, 122);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.CLoseButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 55);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(280, 13);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(78, 31);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // CLoseButton
            // 
            this.CLoseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLoseButton.Location = new System.Drawing.Point(368, 13);
            this.CLoseButton.Name = "CLoseButton";
            this.CLoseButton.Size = new System.Drawing.Size(74, 31);
            this.CLoseButton.TabIndex = 4;
            this.CLoseButton.Text = "&Exit";
            this.CLoseButton.UseVisualStyleBackColor = true;
            this.CLoseButton.Click += new System.EventHandler(this.CLoseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(103, 13);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(68, 31);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Advance Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sMSDataSet7
            // 
            this.sMSDataSet7.DataSetName = "SMSDataSet7";
            this.sMSDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // advanceInfoBindingSource
            // 
            this.advanceInfoBindingSource.DataMember = "AdvanceInfo";
            this.advanceInfoBindingSource.DataSource = this.sMSDataSet7;
            // 
            // advanceInfoTableAdapter
            // 
            this.advanceInfoTableAdapter.ClearBeforeFill = true;
            // 
            // advanceIdDataGridViewTextBoxColumn
            // 
            this.advanceIdDataGridViewTextBoxColumn.DataPropertyName = "AdvanceId";
            this.advanceIdDataGridViewTextBoxColumn.HeaderText = "AdvanceId";
            this.advanceIdDataGridViewTextBoxColumn.Name = "advanceIdDataGridViewTextBoxColumn";
            this.advanceIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // advanceNameDataGridViewTextBoxColumn
            // 
            this.advanceNameDataGridViewTextBoxColumn.DataPropertyName = "AdvanceName";
            this.advanceNameDataGridViewTextBoxColumn.HeaderText = "AdvanceName";
            this.advanceNameDataGridViewTextBoxColumn.Name = "advanceNameDataGridViewTextBoxColumn";
            // 
            // Advance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(481, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Advance";
            this.Text = "Advance";
            this.Load += new System.EventHandler(this.Advance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advanceInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button CLoseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private SMSDataSet7 sMSDataSet7;
        private System.Windows.Forms.BindingSource advanceInfoBindingSource;
        private SMSDataSet7TableAdapters.AdvanceInfoTableAdapter advanceInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn advanceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn advanceNameDataGridViewTextBoxColumn;
    }
}