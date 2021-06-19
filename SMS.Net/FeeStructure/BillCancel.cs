using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.FeeStructure
{
    public partial class BillCancel : Form
    {
        public BillCancel()
        {
            InitializeComponent();
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox1.ValueMember = "ClassId";
            comboBox1.DisplayMember = "Class";
            comboBox1.DataSource = dt;
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            BatchComboBox.DisplayMember = "AcademicYear";
            BatchComboBox.ValueMember = "AcademicYear";
            BatchComboBox.DataSource = dt;
        }
        private void BindMonthComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            comboBox2.ValueMember = "MonthId";
            comboBox2.DisplayMember = "MonthName";
            comboBox2.DataSource = dt;
        }

        private void BillCancel_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
            BindMonthComboBox();
            textBox2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                textBox2.Enabled = true;
                textBox1.Enabled = false;
            }
        }
      
    }
}
