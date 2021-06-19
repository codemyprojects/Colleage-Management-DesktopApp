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
    public partial class BatchFeeDetails : Form
    {
        public BatchFeeDetails()
        {
            InitializeComponent();
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.DisplayMember = "AcademicYear";
            comboBox2.ValueMember = "AcademicYear";
            comboBox1.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox2.ValueMember = "ClassId";
            comboBox2.DisplayMember = "Class";
            comboBox2.DataSource = dt;
        }

        private void BatchFeeDetails_Load(object sender, EventArgs e)
        {
            BindClassComboBox();
            BindBatch();
        }
    }
}
