using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Results
{
    public partial class ClasswiseResult : Form
    {
        public  int cid;
        public  int sid;
        public int aid;
        public int eid;
        public ClasswiseResult()
        {
            InitializeComponent();
        }

        private void ClasswiseResult_Load(object sender, EventArgs e)
        {
            BindClassComboBox();
            BindBatch();
            BindExamInfo();
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.DataSource = dt;
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                cid = Convert.ToInt32(ClassComboBox.SelectedValue);
                //BindGrid(cid);
            }
        }
        private void BindGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T4.StudentName,T2.AcademicYear, T3.Class,T1.ExamDate ,T3.ClassId,T5.ExamType,T1.TotalMarks,T1.Result,t1.Percentage, T1.Division,T1.Remarks FROM student.MarksheetInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN student.StudentInfo T4 ON T1.StudentId=T4.StudentId INNER JOIN student.ExaminationInfo T5 ON T1.ExamId=T5.ExamId WHERE T1.AcademicYearId='"+aid+"' AND T3.ClassId='"+cid+"' AND T1.ExamId='"+eid+"' ORDER BY Percentage DESC";
            DataTable td = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(td.Rows.Count>=0)
            {
                dataGridView1.DataSource = td;
            }
           else
            {
                MessageBox.Show("No Records Please!!");
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
    
        private void BindExamInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.ExaminationInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            ExamTypeComboBox.DisplayMember = "ExamType";
            ExamTypeComboBox.ValueMember = "ExamId";
            ExamTypeComboBox.DataSource = dt;
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid =Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void ExamTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ExamTypeComboBox.SelectedValue!=null)
            {
                eid = Convert.ToInt32(ExamTypeComboBox.SelectedValue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGrid();
            ClassComboBox.Text = "";
            ExamTypeComboBox.Text = "";
            ClassComboBox.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
