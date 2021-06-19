using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Results
{
    public partial class MarksEntry : Form
    {
        public  int CId;
        public int cid;
        public int aid;
        public  int opm=0;
        public  int otm=0;
        public  int om;
        public  bool a;
        public  bool b;
        public  string d;
        //public int etid;
        public MarksEntry()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void MarksEntry_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
            BindSectionComboBox();
            BindExamInfo();
            //BindStudent();
        }
        private void EnableDisableControls(bool b)
        {
            AcademicYearComboBox.Enabled = b;
            ExamTypeComboBox.Enabled = b;
            //ExamDateComboBox.Enabled = b;
            ClassComboBox.Enabled = b;
            SectionComboBox.Enabled = b;
            StudentNameComboBox.Enabled = b;
            RollNo.Enabled = b;
            SubjectNameComboBox.Enabled = b;
            FullMarksTextBox.Enabled = b;
            PassMarksTextBox.Enabled = b;
            TheoryPMarksTextBox.Enabled = b;
        }

        private void FullMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TheoryMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PracticalFullMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TheoryFullMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void TheoryFullMarksTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                Common.Student.StudentsEnroll se = new Common.Student.StudentsEnroll();
                se.ClassId =Convert.ToInt32(ClassComboBox.SelectedValue.ToString());
                BindSubjectNameComboBox(se.ClassId);
                
                PracticalObtainedMarksTextBox.Enabled = true;
                cid = se.ClassId;

                BindComboBox(aid, cid);
                //MessageBox.Show(se.ClassId.ToString());
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DataSource = dt;
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
        private void BindSectionComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.SectionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            SectionComboBox.DisplayMember = "SectionName";
            SectionComboBox.ValueMember = "SectionId";
            SectionComboBox.DataSource = dt;
        }
        private void BindStudent()
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM student.StudentInfo";
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //StudentNameComboBox.DisplayMember = "StudentName";
            //StudentNameComboBox.ValueMember = "StudentId";
            //StudentNameComboBox.DataSource = dt;

        }
        private void BindComboBox(int aid, int cid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId where T1.AcademicYearId='" + aid + "' AND T1.ClassId='" + cid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StudentNameComboBox.DisplayMember = "StudentName";
            StudentNameComboBox.ValueMember = "StudentId";
            StudentNameComboBox.DataSource = dt;
        }
        private void BindSubjectNameComboBox(int Id)
        {
              SqlParameter[] param = new SqlParameter[]
           {
            new SqlParameter("@ClassId",Id)
           };
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spDisplaySubjectById", param, true);
            SubjectNameComboBox.DisplayMember ="SubjectName" ;
            SubjectNameComboBox.ValueMember = "SubjectId";
            SubjectNameComboBox.DataSource = dt;

        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SubjectNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(SubjectNameComboBox.SelectedValue!=null)
            {
                int subjectId = Convert.ToInt32(SubjectNameComboBox.SelectedValue.ToString());
                BindSubjectsInfo(subjectId);
            }
        }
        private void BindSubjectsInfo(int sid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SubjectId",sid)
            };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[student].[spDisplaySubectsBySid]", param, true);
            sdr.Read();
            EnableReadOnly(false);
            FullMarksTextBox.Text = sdr["FullMarks"].ToString();
            PassMarksTextBox.Text = sdr["PassMarks"].ToString();
            if (sdr["TheoryFM"].ToString() == string.Empty || sdr["TheoryFM"].ToString() == ""||sdr["TheoryFM"].ToString() ==null)
                TheoryFullMarksTextBox.Text = sdr["FullMarks"].ToString();
            else
                TheoryFullMarksTextBox.Text = sdr["TheoryFM"].ToString();
            if( sdr["TheoryPM"].ToString()==string.Empty  || sdr["TheoryPM"].ToString()==""|| sdr["TheoryPM"].ToString()==null)
                TheoryPMarksTextBox.Text = sdr["PassMarks"].ToString();
            else
                TheoryPMarksTextBox.Text = sdr["TheoryPM"].ToString();
            if(TheoryFullMarksTextBox.Text==FullMarksTextBox.Text && TheoryPMarksTextBox.Text==PassMarksTextBox.Text)
            {
                PracticalObtainedMarksTextBox.Enabled = false;
                //PracticalFullMarksTextBox.Text = string.Empty;
                //PracticalPM.Text = string.Empty;
            }
            else
            {
                PracticalFullMarksTextBox.Text = sdr["PracticalFM"].ToString();
                PracticalPM.Text = sdr["PracticalPM"].ToString();
            }
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            otm = Convert.ToInt32(ObtainedTheoryMarks.Text.Trim());
            ObtainedMarks.Text = Convert.ToString(otm+opm);
            
        }

        private void PracticalObtainedMarksTextBox_TextChanged(object sender, EventArgs e)
        {
            if(PracticalObtainedMarksTextBox.Text!=null)
            opm =Convert.ToInt32(PracticalObtainedMarksTextBox.Text.Trim());
            ObtainedMarks.Text =Convert.ToString(otm+opm);
        }
        private void EnableReadOnly(bool b)
        {
            FullMarksTextBox.Enabled = b;
            PassMarksTextBox.Enabled = b;
            TheoryFullMarksTextBox.Enabled = b;
            TheoryPMarksTextBox.Enabled = b;
            PracticalFullMarksTextBox.Enabled = b;
            PracticalPM.Enabled = b;
            ObtainedMarks.Enabled = b;
        }

        private void AcademicYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ObtainedMarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void ObtainedTheoryMarks_Leave(object sender, EventArgs e)
        {

            try
            {
                if (int.Parse(ObtainedTheoryMarks.Text.Trim()) >= (int.Parse(TheoryPMarksTextBox.Text.Trim())))
                {
                    a = true;
                }

                if ((int.Parse(ObtainedTheoryMarks.Text.Trim()) < (int.Parse(TheoryPMarksTextBox.Text.Trim()))))
                {
                    a = false;
                }
           

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                    }

        private void PracticalObtainedMarksTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((int.Parse(PracticalObtainedMarksTextBox.Text.Trim()) >= (int.Parse(PracticalPM.Text.Trim()))))
                {
                    b = true;
                }
                if ((int.Parse(PracticalObtainedMarksTextBox.Text.Trim()) < (int.Parse(PracticalPM.Text.Trim()))))
                {
                    b = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
          
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected bool check(bool a,bool b)//fucntion definition
        {
            if((a==true) && (b==true) )
            {
                return true;
            }
            if(a!=b)
            {
                return false;
            }
            return false;
        }

        private void ResultTextBox_Click(object sender, EventArgs e)
        {
           
            if(FullMarksTextBox.Text==TheoryFullMarksTextBox.Text && PassMarksTextBox.Text==TheoryPMarksTextBox.Text)
            {
                if(Convert.ToInt32(ObtainedTheoryMarks.Text)>=Convert.ToInt32(TheoryPMarksTextBox.Text))
                {
                    ResultTextBox.Text = "Pass";
                }
                else
                {
                    ResultTextBox.Text = "Fail";
                }
            }
            else
            {
                bool c = check(a, b);//function call
                if (c)
                {
                    ResultTextBox.Text = "Pass";
                }
                if (!c)
                {
                    ResultTextBox.Text = "Fail";
                }
            }
            
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
            //    Common.Result.Results r = new Common.Result.Results();
            //    r.AcademicYearId = Convert.ToInt32(AcademicYearComboBox.SelectedValue.ToString());
            //    MessageBox.Show(r.AcademicYearId.ToString());
                aid =Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void StudentNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StudentNameComboBox.SelectedValue!=null)
            {

            }
        }

        private void ExamTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ExamTypeComboBox.SelectedValue!=null)
            {

            }
        }

        private void SectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(SectionComboBox.SelectedValue!=null)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Result.Results r = new Common.Result.Results();
                if (AcademicYearComboBox.SelectedValue != null)
                {
                    r.AcademicYearId = int.Parse(AcademicYearComboBox.SelectedValue.ToString());
                    //MessageBox.Show(r.AcademicYearId.ToString());
                }
                if (ExamTypeComboBox.SelectedValue != null)
                r.ExamId = Convert.ToInt32(ExamTypeComboBox.SelectedValue.ToString());
                r.ExamDate = dateTimePicker1.Text.ToString();
                r.ClassId = Convert.ToInt32(ClassComboBox.SelectedValue.ToString());
                if (SectionComboBox.SelectedValue != null)
                    r.Section = SectionComboBox.SelectedValue.ToString();
                if (SubjectNameComboBox.SelectedValue != null)
                    r.SubjectId = Convert.ToInt32(SubjectNameComboBox.SelectedValue.ToString());
                //if (StudentNameComboBox.SelectedValue!=string.Empty)
                //  {
                if (StudentNameComboBox.SelectedValue != null)
                    r.StudentId = Convert.ToInt32(StudentNameComboBox.SelectedValue.ToString()); //int.Parse(RollNo.Text.Trim());
                r.FullMarks = int.Parse(FullMarksTextBox.Text.Trim());
                r.PassMarks = int.Parse(PassMarksTextBox.Text.Trim());
                r.TheoryFullMarks = int.Parse(TheoryFullMarksTextBox.Text.Trim());
                r.TheoryPassMarks = int.Parse(TheoryPMarksTextBox.Text.Trim());
                r.ObtainedTheoryMarks =int.Parse(ObtainedTheoryMarks.Text.Trim());
                if (PracticalFullMarksTextBox.Text.Trim()==string.Empty)
                {
                    r.PracticalFullMarks = 0;
                    PracticalObtainedMarksTextBox.Enabled = false;

                }
                else
                {
                    r.PracticalFullMarks = int.Parse(PracticalFullMarksTextBox.Text.Trim());
                }
                
                if (PracticalPM.Text.Trim()==string.Empty)
                {
                    r.PracticalPassMarks = 0;
                }
                else
                {
                    r.PracticalPassMarks = int.Parse(PracticalPM.Text.Trim());
                }
                
                if (PracticalObtainedMarksTextBox.Text.Trim()==string.Empty)
                {
                    r.PracticalMarks = 0;
                }
                else
                {
                    r.PracticalMarks = int.Parse(PracticalObtainedMarksTextBox.Text.Trim());
                }
                
                r.ObtainedMarks = int.Parse(ObtainedMarks.Text.Trim());
                r.Result = ResultTextBox.Text.Trim();
                int x = BusinessLayer.Results.Result.ResutltEntry(r);
                if (x == 1)
                {
                    MessageBox.Show("Marks Entered Successfull!");
                    //AcademicYearComboBox.Text = "";
                    //ExamTypeComboBox.Text = "";
                    //ClassComboBox.Text = "";
                    SectionComboBox.Text="";
                    dateTimePicker1.Text="";
                    StudentNameComboBox.Text="";
                    RollNo.Text=string.Empty;
                    SubjectNameComboBox.Text="";
                    FullMarksTextBox.Text = string.Empty;
                    PassMarksTextBox.Text = string.Empty;
                    TheoryFullMarksTextBox.Text = string.Empty;
                    TheoryPMarksTextBox.Text = string.Empty;
                    ObtainedTheoryMarks.Text = string.Empty;
                    PracticalFullMarksTextBox.Text = string.Empty;
                    PracticalPM.Text = string.Empty;
                    PracticalObtainedMarksTextBox.Text = string.Empty;
                    ObtainedMarks.Text = string.Empty;
                    ResultTextBox.Text = string.Empty;
                }
                //}


                //else
                //{
                //    MessageBox.Show("Roll No is Required!!");
                //}


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    d = Convert.ToString(dateTimePicker1.Text.Trim());
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubjectNameComboBox_TextChanged(object sender, EventArgs e)
        {
            int subjectId = Convert.ToInt32(SubjectNameComboBox.SelectedValue.ToString());
            BindSubjectsInfo(subjectId);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void StudentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
