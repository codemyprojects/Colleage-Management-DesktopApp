using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Student
{
    public partial class UpdateStudent : Form
    {
        public static Int64 Id;
        public static string imgpath;
        public static byte[] img;
        public static int yid;
        public static int cid;
        public static int pcid;
        public static int rid;
        public static int did;
        
        public UpdateStudent()
        {
            InitializeComponent();
            //dataGridView1.Visible = false;
        }

        private void PassClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if (dt.Rows.Count > 0)
            {
                //combobox1.Items.Clear();
                ClassCommboBox.ValueMember = "ClassId";
                ClassCommboBox.DisplayMember = "Class";
                ClassCommboBox.DataSource = dt;
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.ValueMember = "AcademicYearId";
            comboBox1.DisplayMember = "AcademicYear";
          
            //comboBox1.ValueMember = "AcademicYearId";
            comboBox1.DataSource = dt;
        }
        private void AcademicYearsInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.AcademicYearInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>0)
            {
                comboBox1.ValueMember = "AcademicYear";//Id";
                comboBox1.DisplayMember = "AcademicYear";
                comboBox1.DataSource = dt;
            }
            //comboBox1.DisplayMember = "AcademicYear";
            //comboBox1.ValueMember = "AcademicYearId";
            
        }

        private void PreviousPassedYear()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
                comboBox2.ValueMember = "ClassId";
                comboBox2.DisplayMember = "Class";
                comboBox2.DataSource = dt;
            
        }
        private void BindDivisionComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spDivisionInfo", null, true);
            if (dt.Rows.Count > 0)
            {
                DivisionComboBox.Items.Clear();
                DivisionComboBox.ValueMember = "DivisionId";
                DivisionComboBox.DisplayMember = "Division";
                DivisionComboBox.DataSource = dt;
            }
        }
        private void ReligionInfo()
        {


            //SqlDataReader dr = DataBaseLayer.DbOperations.GetDataReader("spReligionInfo", null, true);
            //while (dr.Read())
            //{
            //    ReligionComboBox.Items.Add(dr["ReligionName"].ToString());
            //    ReligionComboBox.DisplayMember = dr["ReligionName"].ToString();
            //    ReligionComboBox.ValueMember = dr["ReligionId"].ToString();

            //}
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("common.spReligionInfo", null, true);
           // ReligionComboBox.Items.Clear();
            ReligionComboBox.ValueMember = "ReligionId";
            ReligionComboBox.DisplayMember = "ReligionName";
            ReligionComboBox.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        //    Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
        //    student.StudentCode = StudentCodeTextBox.Text.Trim();
        //    Common.Class.Class c = new Common.Class.Class();
        //    c.ClassId = Convert.ToInt32(ClassCommboBox.SelectedValue.ToString());
        //    DataTable dt = BusinessLayer.Students.GetStudentsByCodeClassId(student,c);
        //    dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (ClassCommboBox.SelectedValue != null)
            //{
            //    // MessageBox.Show(ClassComboBox.SelectedValue.ToString());
            //    Common.Class.Class c = new Common.Class.Class();
            //    c.ClassId = Convert.ToInt32(ClassCommboBox.SelectedValue.ToString());

            //}
        }

        private void ClassComboBox(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            PassClassInfo();
            SaveButton.Enabled = false;
            BtnBrowse.Enabled = false;
            EnableDisableControls(false);
            BindGridStudentsGridView();
            textBox1.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            PassClassInfo();
            //BindBatch();
            PassClassInfo();
            ReligionInfo();
            BindDivisionComboBox();
            AcademicYearsInfo();
        }
        private void BindGridStudentsGridView()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spStudents",null,true);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CodeTextBox.Text = Convert.ToString(dataGridView1[0, e.RowIndex].Value);
          
        }
        private void ShowStudents()
        {
            //StudentNameTextBox.Text=
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Click(object sender, EventArgs e)
        {   
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (CodeTextBox.Text == string.Empty || CodeTextBox.Text == "" || CodeTextBox.Text == null)
            {
                MessageBox.Show("Student code is required", "Read the message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EnableDisableControls(true);
                SaveButton.Enabled = true;
                BtnBrowse.Enabled = true;
                EditButton.Enabled = false;
            }
           
         
        }
        private void EnableDisableControls(bool b)
        {
                //CodeTextBox.ReadOnly = true;
               // CodeTextBox.Enabled = b;
                StudentNameTextBox.Enabled = b;
                MaleRadioButton.Enabled = b;
                FemaleRadioButton.Enabled = b;
                ClassCommboBox.Enabled = b;
            // dateTimePicker1.Value = (DateTime)
                DoBTextBox.Enabled = b;
                comboBox1.Enabled = b;
                comboBox2.Enabled = b;
                DivisionComboBox.Enabled = b;
                ReligionComboBox.Enabled = b;
                StudentNationalityTextBox.Enabled = b;
                SchoolNameRichTextBox.Enabled = b;
                TemporaryAddressTextBox.Enabled = b;
                PermanentAddressTextBox.Enabled = b;
                FatherNameTextBox.Enabled = b;
                FatherOccupationTextBox.Enabled = b;
                MotherNameTextBox.Enabled = b;
                MotherOccupationTextBox.Enabled = b;
                MobileNumberTextBox.Enabled = b;
                HomeNumberTextBox.Enabled = b;
               
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete this item?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res==DialogResult.Yes)
            {
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentId",Id)
            };
                int x = DataBaseLayer.DbOperations.ExecProc("[student].[spDeleteStudentByCode]", param, true);
                if (x > 1)
                {
                    //MessageBox.Show("Record Deleted Successfylly!!");
                    BindGridStudentsGridView();
                }
            }
         
         
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Common.Student.StudentsEnroll s = new Common.Student.StudentsEnroll();
            Common.Student.GuardiansInfo g=new Common.Student.GuardiansInfo();
            s.StudentCode=CodeTextBox.Text.Trim();
            s.ClassId = cid;
            s.StudentName=StudentNameTextBox.Text.Trim();
            if(MaleRadioButton.Checked==true)
                s.StudentGender="Male";
            if (FemaleRadioButton.Checked == true)
                s.StudentGender = "Female";
            s.StudentDoB=Convert.ToDateTime(DoBTextBox.Text.Trim());
            s.ReligionId = rid;
            s.StudentNationality=StudentNationalityTextBox.Text.Trim();
           // s.StudentPhoto="";
            s.PermanentAddress=PermanentAddressTextBox.Text.Trim();
            s.TemporaryAddress=TemporaryAddressTextBox.Text.Trim();
            s.PreviousSchoolName=SchoolNameRichTextBox.Text.Trim();
            s.PassedClass = pcid;
            ///s.StudentPassedYear =
            s.DivisionId = did;
            //Read Image Bytes into a byte array
            if(textBox1.Text !="" || textBox1.Text!=string.Empty)
            {
                s.PictureName = textBox1.Text;
                s.Picture = DataBaseLayer.DbOperations.ReadFile(s.PictureName);
            }
       
            if (textBox1.Text == "" || textBox1.Text==string.Empty)
            {
                s.PictureName = imgpath;
                s.Picture = img;
            }
          

            s.StudentId = Convert.ToInt32(Id);
            g.FatherName=FatherNameTextBox.Text.Trim();
            g.FatherOccupation=FatherOccupationTextBox.Text.Trim();
            g.MotherName=MotherNameTextBox.Text.Trim();
            g.MotherOccupation=MotherOccupationTextBox.Text.Trim();
            g.HomeNumber=HomeNumberTextBox.Text.Trim();
            g.MobileNumber=MobileNumberTextBox.Text.Trim();
            int success = BusinessLayer.Students.UpdateStudent(s,g);
            if(success>1)
            {
                MessageBox.Show("Updated Successfully!!");
               
                StudentNameTextBox.Text = string.Empty;
                StudentNationalityTextBox.Text = string.Empty;
                PermanentAddressTextBox.Text = string.Empty;
                TemporaryAddressTextBox.Text = string.Empty;
                SchoolNameRichTextBox.Text = string.Empty;
                FatherNameTextBox.Text = string.Empty;
                FatherOccupationTextBox.Text = string.Empty;
                MotherNameTextBox.Text = string.Empty;
                MotherOccupationTextBox.Text = string.Empty; 
                HomeNumberTextBox.Text = string.Empty;
                MobileNumberTextBox.Text = string.Empty;
                comboBox2.SelectedIndex = comboBox2.FindString("Select One");
                //PassedClassTextBox.Text = string.Empty;
               //PassedYear.Text = string.Empty;
                comboBox1.SelectedIndex = comboBox1.FindString("Select One");
               // DivisionTextBox.Text = string.Empty;
                DivisionComboBox.SelectedIndex = DivisionComboBox.FindString("Select One");
               // ReligionTextBox.Text = string.Empty;
                ReligionComboBox.SelectedIndex = ReligionComboBox.FindString("Select One");
                DoBTextBox.Text = string.Empty;
                BtnBrowse.Text = string.Empty;
                BindGridStudentsGridView();
            }
        }

        private void ReligionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            //open.Title = "Choose Image";
            //// image filters
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    // display image in picture box
            //    pictureBox1.Image = new Bitmap(open.FileName);

            //    // image file path
            //    Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
            //   // textBox1.Text = open.FileName;
            //    // student.StudentPhoto = open.FileName;
            //    student.StudentId =Convert.ToInt32(Id);
            //    student.PictureName = open.FileName;
            //    BusinessLayer.Students.UpdatePicture(student);
            //    //MessageBox.Show(student.StudentPhoto);
            //}
            textBox1.Enabled = true;
            textBox1.Visible = true;
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlres = dlg.ShowDialog();
            if (dlres != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;
                textBox1.Text = dlg.FileName;
                ////MessageBox.Show(txtImagePath.ToString());
            }

        }
        //byte[] ReadFile(string sPath)
        //{
        //    //Initialize byte array with a null value initially.
        //    byte[] data = null;

        //    //Use FileInfo object to get file size.
        //    FileInfo fInfo = new FileInfo(sPath);
        //    long numBytes = fInfo.Length;

        //    //Open FileStream to read file
        //    FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

        //    //Use BinaryReader to read file stream into byte array.
        //    BinaryReader br = new BinaryReader(fStream);

        //    //When you use BinaryReader, you need to supply number of bytes to read from file.
        //    //In this case we want to read entire file. So supplying total number of bytes.
        //    data = br.ReadBytes((int)numBytes);
        //    return data;
        //}

        private void ShowButton_Click(object sender, EventArgs e)
        {
            

            if (CodeTextBox.Text == string.Empty || CodeTextBox.Text == "" || CodeTextBox.Text == null)
            {
                MessageBox.Show("Student code is required", "Read the message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show(dataGridView1[0, e.RowIndex].Value.ToString());
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
                Common.Student.StudentsEnroll s = new Common.Student.StudentsEnroll();
                /////// s.StudentCode = (string)dataGridView1[1, e.RowIndex].Value;
                //Id = (Int64)dataGridView1[0, e.RowIndex].Value;
                //CodeTextBox.Text = Convert.ToUInt32(dataGridView1[].Value);
                s.StudentCode = CodeTextBox.Text.Trim();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM student.StudentInfo t1 inner join student.GuardiansInfo t2 on t1.StudentId=t2.StudentId INNER join student.DivisionInfo t3 on t1.DivisionId=t3.DivisionId INNER join student.ClassInfo t4 on t1.ClassId=t4.ClassId FULL join common.ReligionInfo t5 on t1.ReligionId=t5.ReligionId FULL join common.PictureInfo t7 on t1.StudentId=t7.StudentId INNER JOIN student.AcademicYearInfo T8 ON T8.AcademicYearId=t1.AcademicYearId  WHERE StudentCode='"+CodeTextBox.Text.Trim()+"'";
               // cmd.CommandText = "SELECT * FROM [student].[StudentInfo] t1 INNER JOIN student.AcademicYearInfo T2 ON t1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON t1.ClassId=T3.ClassId INNER JOIN student.DivisionInfo T4 ON t1.DivisionId=T4.DivisionId INNER JOIN common.ReligionInfo T5 ON t1.ReligionId=T5.ReligionId WHERE   t1.StudentCode='" + CodeTextBox.Text.Trim() + "'";
                //cmd.CommandText = "select * from student.StudentInfo t1 inner join student.GuardiansInfo t2 on t1.StudentId=t2.StudentId full join student.DivisionInfo t3 on t1.DivisionId=t3.DivisionId full join student.ClassInfo t4 on t1.ClassId=t4.ClassId full join common.ReligionInfo t5 on t1.ReligionId=t5.ReligionId full join common.PictureInfo t7 on t1.StudentId=t7.StudentId full join student.AcademicYearInfo t8 on t8.AcademicYearId=t8.AcademicYearId where t1.StudentCode='" + CodeTextBox.Text.Trim() + "' AND t8.AcademicYear='2015'";
                //cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN common.ReligionInfo T3 ON T1.ReligionId=T3.ReligionId where StudentCode='" + CodeTextBox.Text.Trim() + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if (dt.Rows.Count != 0)
                {
                    SqlDataReader sdr = BusinessLayer.Students.GetStudentsByCode(s);
                    // CodeTextBox.ReadOnly = true;
                    // CodeTextBox.Text = sdr["StudentCode"].ToString();
                    StudentNameTextBox.Text = sdr["StudentName"].ToString();
                    Id = (Int64)sdr["StudentId"];
                    //if (sdr["PictureName"].ToString() != "" || sdr["PictureName"].ToString() != null)
                    //pictureBox1.Image = new Bitmap(sdr["PictureName"].ToString());
                    if (sdr["StudentGender"].ToString() == "Male" || sdr["StudentGender"].ToString() == "male")
                        MaleRadioButton.Checked = true;
                    if (sdr["StudentGender"].ToString() == "Female" || sdr["StudentGender"].ToString() == "female")
                        FemaleRadioButton.Checked = true;
                    ClassCommboBox.SelectedIndex = ClassCommboBox.FindString(sdr["Class"].ToString());
                    comboBox1.SelectedIndex = comboBox1.FindString(sdr["AcademicYear"].ToString());
                    comboBox2.SelectedIndex = comboBox2.FindString(sdr["Class"].ToString());
                    //comboBox1.SelectedIndex = comboBox1.FindString(sdr["AcademicYear"].ToString());
                    //ClassTextBox.Text = sdr["Class"].ToString();
                    //SectionTextBox.Text = sdr["SectionName"].ToString();
                    // dateTimePicker1.Value = (DateTime)
                    DoBTextBox.Text = sdr["StudentDoB"].ToString();
                //    comboBox1.SelectedIndex = sdr["PassedClass"];

                    //textBox1.Text = sdr["AcademicYear"].ToString();
                    //textBox2.Text = sdr["AcademicYear"].ToString();
                    //comboBox3.SelectedIndex = comboBox3.FindStringExact(sdr["AcademicYear"].ToString());
                    //comboBox2.SelectedIndex = comboBox1.FindString(sdr["AcademicYearId"].ToString());
                   // PassedYear.Text = sdr["PassedYear"].ToString();
                    DivisionComboBox.SelectedIndex = DivisionComboBox.FindString(sdr["Division"].ToString());
                   // DivisionTextBox.Text = sdr["Division"].ToString();
                    ReligionComboBox.SelectedIndex = ReligionComboBox.FindString(sdr["ReligionName"].ToString());
                   // ReligionTextBox.Text = sdr["ReligionName"].ToString();
                    StudentNationalityTextBox.Text = sdr["StudentNationality"].ToString();
                    SchoolNameRichTextBox.Text = sdr["PreviousSchoolName"].ToString();
                    TemporaryAddressTextBox.Text = sdr["TemporaryAddress"].ToString();
                    PermanentAddressTextBox.Text = sdr["PermanentAddress"].ToString();
                    FatherNameTextBox.Text = sdr["FatherName"].ToString();
                    FatherOccupationTextBox.Text = sdr["FatherOccupation"].ToString();
                    MotherNameTextBox.Text = sdr["MotherName"].ToString();
                    MotherOccupationTextBox.Text = sdr["MotherOccupation"].ToString();
                    MobileNumberTextBox.Text = sdr["MobileNumber"].ToString();
                    HomeNumberTextBox.Text = sdr["HomeNumber"].ToString();
                    imgpath = sdr["PictureName"].ToString();

                    ///modified method for displaying image
                    byte[] imageData = (byte[])sdr["Picture"];
                    img = imageData;
                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);

                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                    }

                    //set picture
                    pictureBox1.Image = newImage;

                }
                else
                {

                    MessageBox.Show("No Records Please!!");
                }
            
            }
                        
          
        }

        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                yid = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void ClassCommboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ClassCommboBox.SelectedValue!=null)
            {
                cid = Convert.ToInt32(ClassCommboBox.SelectedValue);
            }
        }

        private void ReligionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ReligionComboBox.SelectedValue!=null)
            {
                rid = Convert.ToInt32(ReligionComboBox.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                pcid = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }

        private void DivisionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DivisionComboBox.SelectedValue!=null)
            {
                did = Convert.ToInt32(DivisionComboBox.SelectedValue);
            }
        }

        private void DoBTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox3.SelectedValue!=null)
            {

            }
        }

        private void comboBox3_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void ClassCommboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t1.StudentCode AS Code,t1.StudentName [Name],t1.StudentGender as [Gender],t1.StudentDoB as [DoB],t2.FatherName AS [Father],t2.MotherName as [Mother],t2.HomeNumber as [Phone],t2.MobileNumber as [Mobile] FROM student.StudentInfo t1 inner join student.GuardiansInfo t2 on t1.StudentId=t2.StudentId INNER JOIN student.AcademicYearInfo T3 ON t1.AcademicYearId=T3.AcademicYearId INNER JOIN student.ClassInfo T4 ON t1.ClassId=T4.ClassId  WHERE t1.StudentName LIKE '" + textBox3.Text.Trim() + "%" + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ClassCommboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}