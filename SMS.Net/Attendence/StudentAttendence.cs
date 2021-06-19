using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Attendence
{
    public partial class StudentAttendence : Form
    {
        public StudentAttendence()
        {
            InitializeComponent();
        }

        private void StudentAttendence_Load(object sender, EventArgs e)
        {
            BindclassComboBox();
            BindSectionComboBox();
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        private void BindclassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DataSource = dt;
         
        }
        private void BindSectionComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spSectionInfo", null, true);
            SectionComboBox.DisplayMember = "SectionName";
            SectionComboBox.ValueMember = "SectionId";
            SectionComboBox.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NewAttendenceButton_Click(object sender, EventArgs e)
        {

        }
  }
}
