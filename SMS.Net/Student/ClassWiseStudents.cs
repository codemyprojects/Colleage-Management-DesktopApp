using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Student
{
    public partial class ClassWiseStudents : Form
    {
        public static int aid;
        public static int cid;
        public ClassWiseStudents()
        {
            InitializeComponent();
        }

        private void ClassWiseStudents_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.DisplayMember = "AcademicYear";
            comboBox1.ValueMember = "AcademicYearId";
            comboBox1.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  T1.StudentCode AS Code,T1.StudentName AS [Student Name],T1.TemporaryAddress as [Temporary Address],T1.PermanentAddress as [Permanent Address],T4.FatherName AS [Father],T4.MotherName  AS [Mother],T4.HomeNumber as [Phone],T4.MobileNumber as [Mobile] FROM student.StudentInfo T1 INNER JOIN student.ClassInfo T2 ON T1.ClassId=T2.ClassId INNER JOIN student.AcademicYearInfo T3 ON T1.AcademicYearId=T3.AcademicYearId INNER JOIN student.GuardiansInfo T4 ON T1.StudentId=T4.StudentId WHERE T3.AcademicYearId='" + aid + "' AND T2.ClassId='" + cid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                
                dataGridView1.DataSource = dt;
                textBox1.Text = Convert.ToString(dt.Rows.Count);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                aid = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                cid = Convert.ToInt32(ClassComboBox.SelectedValue);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
