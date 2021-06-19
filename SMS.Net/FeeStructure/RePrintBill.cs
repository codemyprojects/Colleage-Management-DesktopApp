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
    public partial class RePrintBill : Form
    {
        public RePrintBill()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox2.Enabled = true;
                textBox1.Enabled = false;
            }
        }

        private void RePrintBill_Load(object sender, EventArgs e)
        {
            textBox1.Enabled =false;
            textBox2.Enabled = false;
            BindBatch();
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.DisplayMember = "AcademicYear";
            comboBox1.ValueMember = "AcademicYear";
            comboBox1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
