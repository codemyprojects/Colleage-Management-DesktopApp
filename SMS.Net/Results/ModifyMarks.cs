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
    public partial class ModifyMarks : Form
    {
        public int SId;
        public int cid;
        public int SubjId;
        public int opm = 0;
        public int otm = 0;
        public int om;
        public DataTable dtable;
        public DataRow r;
        public ModifyMarks()
        {
            InitializeComponent();
        }

        private void ModifyMarks_Load(object sender, EventArgs e)
        {
            BindDataGrid();
            BindBatch();
            BindExamInfo();
            BindSectionComboBox();
            BindClassComboBox();
            BindSubjectNameComboBox();
            BindStudent();
            SaveButton.Enabled = false;
        }
        private void BindStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StudentNameComboBox.DisplayMember = "StudentName";
            StudentNameComboBox.ValueMember = "StudentId";
            StudentNameComboBox.DataSource = dt;

        }
        private void BindDataGrid()
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText = "select ResultId,FullMarks,PassMarks,TheoryFM,TheoryPM,ObtainedTheoryMarks ,PracticalFM,PracticalPM,ObtainedPracticalMarks,ObtainedMarks,Result,ExamDate,ClassId,Section,AcademicYearId,StudentId,SubjectId,ExamId from student.ResultInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;

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
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DataSource = dt;
        }
        private void BindSectionComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.SectionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            SectionComboBox.DisplayMember = "SectionName";
            SectionComboBox.ValueMember = "SectionId";
            SectionComboBox.DataSource = dt;
        }
        private void BindSubjectNameComboBox()
        {
            SqlCommand scmd = new SqlCommand();
            scmd.CommandText = "select * from dbo.SubjectsInfo";
            DataTable sub = DataBaseLayer.DbOperations.GetDataTable(scmd);
            SubjectNameComboBox.DisplayMember = "SubjectName";
            SubjectNameComboBox.ValueMember = "SubjectId";
            SubjectNameComboBox.DataSource = sub;

        }
        private void BindSubjectNameComboBox(int cid)
        {
            SqlCommand scmd = new SqlCommand();
            scmd.CommandText = "select * from dbo.SubjectsInfo where ClassId='"+cid+"'";
            DataTable sub = DataBaseLayer.DbOperations.GetDataTable(scmd);
            SubjectNameComboBox.DisplayMember = "SubjectName";
            SubjectNameComboBox.ValueMember = "SubjectId";
            SubjectNameComboBox.DataSource = sub;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableReadOnly(true);
            EditButton.Enabled = true;
            SId =Convert.ToInt32(dataGridView1[15, e.RowIndex].Value);
            SubjId = Convert.ToInt32(dataGridView1[16, e.RowIndex].Value);
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="SELECT * FROM student.ResultInfo WHERE StudentId='"+SId+"'";
           // MessageBox.Show(SubjId.ToString());
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach(DataRow drow in dt.Rows)//outer foreach looop
            {
                dtable = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
                foreach (DataRow r in dtable.Rows)//inner foreach loop
                {
                    if (r["AcademicYearId"].ToString() == drow["AcademicYearId"].ToString())
                    {
                        AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindStringExact(r["AcademicYear"].ToString());
                    }
                }
                
                SqlCommand d = new SqlCommand();
                d.CommandText = "SELECT * FROM student.StudentInfo";
                DataTable st = DataBaseLayer.DbOperations.GetDataTable(d);
                foreach(DataRow r in st.Rows)
                {
                    if(r["StudentId"].ToString()==drow["StudentId"].ToString())
                    {
                        StudentNameComboBox.SelectedIndex = StudentNameComboBox.FindString(r["StudentName"].ToString());

                    }
                }
               
                SqlCommand c = new SqlCommand();
                cmd.CommandText = "select * from student.ExaminationInfo";
                DataTable t = DataBaseLayer.DbOperations.GetDataTable(cmd);
                foreach(DataRow r in t.Rows)
                {
                    if(r["ExamId"].ToString()==drow["ExamId"].ToString())
                    {
                        ExamTypeComboBox.SelectedIndex = ExamTypeComboBox.FindString(r["ExamType"].ToString());
                    }
                }
                DataTable ct = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
                foreach (DataRow r in ct.Rows)
                {
                    if (r["ClassId"].ToString() == drow["ClassId"].ToString())
                    {
                        ClassComboBox.SelectedIndex = ClassComboBox.FindString(r["Class"].ToString());
                    }
                }
                SqlCommand si = new SqlCommand();
                cmd.CommandText = "select * from student.SectionInfo";
                DataTable set = DataBaseLayer.DbOperations.GetDataTable(cmd);
                foreach (DataRow r in set.Rows)
                {
                    if (r["SectionId"].ToString() == drow["Section"].ToString())
                    {
                        SectionComboBox.SelectedIndex = SectionComboBox.FindString(r["SectionName"].ToString()); 
                    }
                }
                SqlCommand scmd = new SqlCommand();
                scmd.CommandText = "select * from dbo.SubjectsInfo";
                DataTable sub = DataBaseLayer.DbOperations.GetDataTable(scmd);
                foreach (DataRow r in sub.Rows)
                {
                    if (r["SubjectId"].ToString() == drow["SubjectId"].ToString())
                    {
                        SubjectNameComboBox.SelectedIndex = SubjectNameComboBox.FindString(r["SubjectName"].ToString());
                    }
                }
               // AcademicYearComboBox.DisplayMember = "AcademicYear";
                //AcademicYearComboBox.ValueMember = "AcademicYear";
                FullMarksTextBox.Text = drow["FullMarks"].ToString();
                PassMarksTextBox.Text = drow["PassMarks"].ToString();
                TheoryFullMarksTextBox.Text = drow["TheoryFM"].ToString();
                TheoryPMarksTextBox.Text = drow["TheoryPM"].ToString();
                ObtainedTheoryMarks.Text = drow["ObtainedTheoryMarks"].ToString();
                PracticalFullMarksTextBox.Text = drow["PracticalFM"].ToString();
                PracticalPM.Text = drow["PracticalPM"].ToString();
                PracticalObtainedMarksTextBox.Text = drow["ObtainedPracticalMarks"].ToString();
                ObtainedMarks.Text = drow["ObtainedMarks"].ToString();
                ResultTextBox.Text = drow["Result"].ToString();
            }
        }
        private void EnableReadOnly(bool b)
        {
            FullMarksTextBox.ReadOnly = b;
            PassMarksTextBox.ReadOnly = b;
            TheoryFullMarksTextBox.ReadOnly = b;
            TheoryPMarksTextBox.ReadOnly = b;
            PracticalFullMarksTextBox.ReadOnly = b;
            PracticalPM.ReadOnly = b;
            ObtainedTheoryMarks.ReadOnly = b;
            PracticalObtainedMarksTextBox.ReadOnly = b;
            ObtainedMarks.ReadOnly = b;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ObtainedTheoryMarks.ReadOnly = false;
            PracticalObtainedMarksTextBox.ReadOnly = false;
            ObtainedMarks.ReadOnly = false;
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
        }

        private void ObtainedTheoryMarks_TextChanged(object sender, EventArgs e)
        {   
                if(ObtainedTheoryMarks.Text!=string.Empty)
                otm = Convert.ToInt32(ObtainedTheoryMarks.Text.Trim());
                ObtainedMarks.Text = Convert.ToString(otm + opm);
        }

        private void PracticalObtainedMarksTextBox_TextChanged(object sender, EventArgs e)
        {       
                if(PracticalObtainedMarksTextBox.Text!=string.Empty)
                opm = Convert.ToInt32(PracticalObtainedMarksTextBox.Text.Trim());
                ObtainedMarks.Text = Convert.ToString(otm + opm);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


      

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM student.ResultInfo WHERE SubjectId='" + SubjId + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Marks Deleted Succuessfully");
                    BindDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Delete Operation Terminated","Delete Cancelled!!");
            }
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExamTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AcademicYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void groupBox2_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(SubjId.ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE student.ResultInfo SET ObtainedTheoryMarks='" + ObtainedTheoryMarks.Text.Trim() + "',ObtainedPracticalMarks='" + PracticalObtainedMarksTextBox.Text.Trim() + "',ObtainedMarks='" + ObtainedMarks.Text.Trim() + "' WHERE SubjectId='" + SubjId + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Marks Updated Successfully!!");
                BindDataGrid();
                //AcademicYearComboBox.Text = "";
                //ExamTypeComboBox.Text = "";
                //ClassComboBox.Text = "";
                SectionComboBox.Text = "";
                dateTimePicker1.Text = "";
                StudentNameComboBox.Text = "";
                RollNo.Text = string.Empty;
                SubjectNameComboBox.Text = "";
                FullMarksTextBox.Text = string.Empty;
                PassMarksTextBox.Text = string.Empty;
                TheoryFullMarksTextBox.Text = string.Empty;
                TheoryPMarksTextBox.Text = string.Empty;
                ObtainedTheoryMarks.Text = string.Empty;
                ResultTextBox.Text = string.Empty;
                ObtainedMarks.Text = string.Empty;
                PracticalFullMarksTextBox.Text = string.Empty;
                PracticalPM.Text = string.Empty;
                PracticalObtainedMarksTextBox.Text = string.Empty;

            }
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                cid = Convert.ToInt32(ClassComboBox.SelectedValue);
                BindSubjectNameComboBox(cid);
            }
        }
        
    }
}
