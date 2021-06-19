using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Student
{   
   
    public partial class StudentEnroll : Form
    {
        public static string PictureName;
        public static string pyear;
        public static int ayearId;
        public static int pid;
        public static int pcid;
        public static int cid;
        public static int did;
        public static string school;
        public StudentEnroll()
        {
            InitializeComponent();
        }

        private void StudentEnroll_Load(object sender, EventArgs e)
        {
            SelectOnCheckBox.Checked = false;
            panel2.Enabled = false;
           // MessageBox.Show(Login.RoleCode.ToString());
            SchoolNameTextBox.Focus();
            
            //if (Login.RoleCode.ToString() == "Admin")
            //{
            //    EnableDisableControls(true);
            //   // MessageBox.Show("Hello!!!");
            //}
            //if (Login.RoleCode.ToString() == "Usr")
            //{
            //    EnableDisableControls(false);
            //}
            StudentCodeTextBox.ReadOnly = true;
            //StudentCodeTextBox.Text = GetRandomCode();
            GetCalender();
            ReligionInfo();
            EnrollClassInfo();
           // PassClassInfo();
            BindDivisionComboBox();
            BindBatch();
            PassedYearComboBox.SelectedIndex = PassedYearComboBox.FindString("Select One");
            DivisionComboBox.SelectedIndex = DivisionComboBox.FindString("Select One");
            PassedClassComboBox.SelectedIndex = PassedClassComboBox.FindString("Select One");
            ReligionComboBox.SelectedIndex = ReligionComboBox.FindString("Select One");

        }
        private string GetRandomCode()
        {
            var chars = "0123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return "STU-1"+finalString;

        }
        private void GetCalender()
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Short;
            //dateTimePicker1.Value = DateTime.Today;
            //PassedYearDatePicker.Format = DateTimePickerFormat.Short;
            //PassedYearDatePicker.Value = DateTime.Today;

        }

        private void EnrollClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if(dt.Rows.Count>0)
            {
                ClassComboBox.Items.Clear();
                ClassComboBox.ValueMember = "ClassId";
                ClassComboBox.DisplayMember = "Class";
                ClassComboBox.DataSource = dt;
               

            }
            else
            {
                ClassComboBox.Text = "";
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
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("dbo.spReligionInfo", null, true);
            ReligionComboBox.Items.Clear();
            ReligionComboBox.ValueMember = "ReligionId";
            ReligionComboBox.DisplayMember = "ReligionName";
            ReligionComboBox.DataSource = dt;
        }

        private void PassClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if(dt.Rows.Count>0)
            {
                PassedClassComboBox.Items.Clear();
                PassedClassComboBox.ValueMember = "ClassId";
                PassedClassComboBox.DisplayMember = "Class";
                PassedClassComboBox.DataSource = dt;
            }
        }
        private void BindDivisionComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spDivisionInfo", null, true);
            if(dt.Rows.Count>0)
            {
                DivisionComboBox.Items.Clear();
                DivisionComboBox.ValueMember = "DivisionId";
                DivisionComboBox.DisplayMember = "Division";
                DivisionComboBox.DataSource = dt;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Read Image Bytes into a byte array
            // byte[] imageData = ReadFile(textBox1.Text);

            try
            {
                DateTime idate;
                DateTime passeDate;
                idate = DateTime.Parse(dateTimePicker2.Text);
                //passeDate = PassedYearDatePicker.Value;
                Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
                StudentCodeTextBox.Text = GetRandomCode();
                student.StudentCode =StudentCodeTextBox.Text;
                student.academicYearId = ayearId;
                Common.Class.Class c = new Common.Class.Class();

                c.ClassId =cid;
                student.StudentName =StudentNameTextBox.Text.Trim() ;//SchoolNameTextBox.Text.Trim();
                bool isChecked = MaleRadioButton.Checked;
                if (isChecked)
                    student.StudentGender = MaleRadioButton.Text;
                else
                    student.StudentGender = FemaleRadioButton.Text;

                student.StudentDoB = idate;
                student.ReligionId = int.Parse(ReligionComboBox.SelectedValue.ToString());
                student.StudentNationality = StudentNationalityTextBox.Text.Trim();
                // student.StudentPhoto = "";
                student.PermanentAddress = PermanentAddressTextBox.Text.Trim();
                student.TemporaryAddress = TemporaryAddressTextBox.Text.Trim();
                student.StudentPassedYear = ayearId;
                if(SelectOnCheckBox.Checked==true)
                {
                    student.PreviousSchoolName = SchoolNameTextBox.Text.Trim();
                    student.PassedClass = pcid;
                    student.DivisionId = int.Parse(DivisionComboBox.SelectedValue.ToString());
                }
                else
                {
                    student.PreviousSchoolName ="nopreviousschool";
                    student.PassedClass = 0;
                    student.DivisionId = 0;
                }
               
                if(textBox1.Text==string.Empty|| textBox1.Text==null || textBox1.Text=="")
                {

                    student.PictureName = "No image";
                    textBox1.Text = "\\SMS\\nimage.jpg";
                    student.Picture = DataBaseLayer.DbOperations.ReadFile(textBox1.Text.Trim());
                }
                else
                {
                    student.PictureName = textBox1.Text;
                    student.Picture = DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
                }
           
                //Read Image Bytes into a byte array
       

                Common.Student.GuardiansInfo guardian = new Common.Student.GuardiansInfo();
                guardian.FatherName = FatherNameTextBox.Text.Trim();
                guardian.MotherName = MotherNameTextBox.Text.Trim();
                guardian.FatherOccupation = FatherOccupationTextBox.Text.Trim();
                guardian.MotherOccupation = MotherOccupationTextBox.Text.Trim();
                guardian.PermanentAddress = PermanentAddressTextBox.Text.Trim();
                guardian.TemporaryAddress = TemporaryAddressTextBox.Text.Trim();
                guardian.HomeNumber = HomeNumberTextBox.Text.Trim();
                guardian.MobileNumber = MobileNumberTextBox.Text.Trim();
                //if (HomeNumberTextBox.Text != string.Empty && HomeNumberTextBox.Text.Length == 10)
                //{
                   if (MobileNumberTextBox.Text == string.Empty && MobileNumberTextBox.Text.Length < 10)
                    {
                        MessageBox.Show("At least 10 characters are required");
                    }

                   else
                    {
                        guardian.HomeNumber = HomeNumberTextBox.Text.Trim();
                        guardian.MobileNumber = MobileNumberTextBox.Text.Trim();
                        int x = BusinessLayer.Students.EnrollStudent(student, guardian, c);
                        if (x > 0)
                        {
                            MessageBox.Show("Student Enroll Successfully!!");
                            StudentCodeTextBox.Text = GetRandomCode();
                            StudentNameTextBox.Text = string.Empty;
                            StudentNationalityTextBox.Text = string.Empty;
                            PermanentAddressTextBox.Text = string.Empty;
                            TemporaryAddressTextBox.Text = string.Empty;
                            SchoolNameTextBox.Text = string.Empty;
                            FatherNameTextBox.Text = string.Empty;
                            FatherOccupationTextBox.Text = string.Empty;
                            MotherNameTextBox.Text = string.Empty;
                            MotherOccupationTextBox.Text = string.Empty;
                            HomeNumberTextBox.Text = string.Empty;
                            MobileNumberTextBox.Text = string.Empty;
                            MaleRadioButton.Checked = false;
                            FemaleRadioButton.Checked = false;
                            //ClassComboBox.Text = "";
                            //dateTimePicker2.CustomFormat = null;
                            //dateTimePicker2.Format = DateTimePickerFormat.Long;
                            //dateTimePicker1.CustomFormat = "";
                            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                            PassedYearComboBox.SelectedIndex = PassedYearComboBox.FindString("Select One");
                            DivisionComboBox.SelectedIndex = DivisionComboBox.FindString("Select One");
                            PassedClassComboBox.SelectedIndex = PassedClassComboBox.FindString("Select One");
                            ReligionComboBox.SelectedIndex = ReligionComboBox.FindString("Select One");
                            textBox1.Text = "";
                            pictureBox1.Image = null;
                            
                        }
                        else
                        {
                            MessageBox.Show("Student Enroll Failed!!");
                            //this.Hide();

                            //Student.StudentEnroll SE = new Student.StudentEnroll();
                            //SE.Show();
                        }
                    }
                  
                //}
                //else
                //{
                //    MessageBox.Show("At least 7 characters are required");
                //}

              
              
                //if(PictureName=="" || PictureName==null)
                //{
                //  MessageBox.Show("Please Choose Image");
                //}

            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {


            /////OpenFileDialog open = new OpenFileDialog();
            ///////open.Title = "Choose Image";
            // image filters
            /////////open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ////// //if (open.ShowDialog() == DialogResult.OK)
            ////// //{
            // display image in picture box
            /////////////////  pictureBox1.Image = new Bitmap(open.FileName);

            // image file path
            //  Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
            //   textBox1.Text = open.FileName;
            ///////////////PictureName = open.FileName;
            // student.StudentPhoto = open.FileName;
            // student.PictureName = open.FileName;
            //  BusinessLayer.Students.EnrollStudent(student);
            //MessageBox.Show(student.StudentPhoto);
            // MessageBox.Show(PictureName);
            ////////////////// }
            /*
             * 
             * 
             * 
             * 
             * 
             * modified code for image saving in binary form
              */

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

        public static void InsertImageIntoMSSQLAsBinary()
        {
           // byte[] imgdata = File.ReadAllBytes(imagepath);
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {  
            //MessageBox.Show(ClassComboBox.SelectedItem.ToString());
         
           
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ClassComboBox.SelectedValue != null)
            {
               // MessageBox.Show(ClassComboBox.SelectedValue.ToString());
                //Common.Class.Class c = new Common.Class.Class();
                //c.ClassId = Convert.ToInt32(ClassComboBox.SelectedValue.ToString());
                cid = Convert.ToInt32(ClassComboBox.SelectedValue);
                MessageBox.Show(cid.ToString());
            }
        }

        private void PassedClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
             if(PassedClassComboBox.SelectedValue!=null)
            {
               // MessageBox.Show(PassedClassComboBox.SelectedValue.ToString());
                //Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
                //student.ClassId =Convert.ToInt32(PassedClassComboBox.SelectedValue.ToString());
               // pid = Convert.ToInt32(PassedClassComboBox.SelectedValue);
                pcid = Convert.ToInt32(PassedClassComboBox.SelectedValue);
                MessageBox.Show(pcid.ToString());
            }
        }

        private void ReligionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {   
            if(ReligionComboBox.SelectedValue!=null)
            { 
               // MessageBox.Show(ReligionComboBox.SelectedValue.ToString());
                Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
                student.ReligionId =int.Parse(ReligionComboBox.SelectedValue.ToString());

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            string yourDate = textBox1.Text;
           // string formattedDate = yourDate.ToString("");
        }

        private void DivisionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {   
            if(DivisionComboBox.SelectedValue!=null)
            {
                Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
                student.DivisionId =int.Parse(DivisionComboBox.SelectedValue.ToString());
            }
        }

        private void EnableDisableControls(bool b)
        {
            SchoolNameTextBox.Enabled = b;
            StudentCodeTextBox.Enabled = b;
            StudentNationalityTextBox.Enabled = b;
            ReligionComboBox.Enabled = b;
            PermanentAddressTextBox.Enabled = b;
            TemporaryAddressTextBox.Enabled = b;
            dateTimePicker2.Enabled = b;
            FatherNameTextBox.Enabled = b;
            MotherNameTextBox.Enabled = b;
            FatherOccupationTextBox.Enabled = b;
            MotherOccupationTextBox.Enabled = b;
            HomeNumberTextBox.Enabled = b;
            Photo.Enabled = b;
            MobileNumberTextBox.Enabled = b;
            PassedClassComboBox.Enabled = b;
            ClassComboBox.Enabled = b;
            DivisionComboBox.Enabled = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(PictureName.ToString());
        }

        private void StudentNationalityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentNameTextBox_TabIndexChanged(object sender, EventArgs e)
        {
            StudentNationalityTextBox.Focus();
        }

        private void PassedYearDatePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void PassedYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(PassedYearComboBox.SelectedValue!=null)
            {
              //  pyear = Convert.ToString(PassedYearComboBox.SelectedValue);
                ayearId = Convert.ToInt32(PassedYearComboBox.SelectedValue);
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            PassedYearComboBox.DisplayMember = "AcademicYear";
            PassedYearComboBox.ValueMember = "AcademicYearId";
            PassedYearComboBox.DataSource = dt;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void PassedYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
//if(maskedTextBox1.MaskFull)

        }

         void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(MobileNumberTextBox);
        }

        void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if(!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                //toolTip1.Show("The date you supplied must be valid date in the format mm/;
            }
            else
            {
                DateTime userdate=(DateTime)e.ReturnValue;
                if(userdate<DateTime.Now)
                {
                    toolTip1.ToolTipTitle="Invalid Date";
                    //toolTip1.Show("The date in this field must be greater than today's date");
                    e.Cancel=true;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            //Read Image Bytes into a byte array
            // byte[] imageData = ReadFile(textBox1.Text);

            try
            {
                DateTime idate;
                DateTime passeDate;
                idate = Convert.ToDateTime(dateTimePicker2.Text);
                //passeDate = PassedYearDatePicker.Value;
                Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();

                student.StudentCode = GetRandomCode();

                Common.Class.Class c = new Common.Class.Class();

                c.ClassId = Convert.ToInt32(ClassComboBox.SelectedValue.ToString());

                student.StudentName = SchoolNameTextBox.Text.Trim();
                bool isChecked = MaleRadioButton.Checked;
                if (isChecked)
                    student.StudentGender = MaleRadioButton.Text;
                else
                    student.StudentGender = FemaleRadioButton.Text;

                student.StudentDoB = idate;
                student.ReligionId = int.Parse(ReligionComboBox.SelectedValue.ToString());
                student.StudentNationality = StudentNationalityTextBox.Text.Trim();
                // student.StudentPhoto = "";
                student.PermanentAddress = PermanentAddressTextBox.Text.Trim();
                student.TemporaryAddress = TemporaryAddressTextBox.Text.Trim();
                student.PreviousSchoolName = StudentNameTextBox.Text.Trim();
                student.PassedClass = pcid;
                student.StudentPassedYear = ayearId;//PassedYearDatePicker.Text.Trim();
                student.DivisionId = int.Parse(DivisionComboBox.SelectedValue.ToString());
                student.PictureName = textBox1.Text;
                //Read Image Bytes into a byte array
                student.Picture = DataBaseLayer.DbOperations.ReadFile(textBox1.Text);

                Common.Student.GuardiansInfo guardian = new Common.Student.GuardiansInfo();
                guardian.FatherName = FatherNameTextBox.Text.Trim();
                guardian.MotherName = MobileNumberTextBox.Text.Trim();
                guardian.FatherOccupation = FatherOccupationTextBox.Text.Trim();
                guardian.MotherOccupation = MotherOccupationTextBox.Text.Trim();
                guardian.PermanentAddress = PermanentAddressTextBox.Text.Trim();
                guardian.TemporaryAddress = TemporaryAddressTextBox.Text.Trim();
                guardian.HomeNumber = HomeNumberTextBox.Text.Trim();
                guardian.MobileNumber = MobileNumberTextBox.Text.Trim();
                //if(PictureName=="" || PictureName==null)
                //{
                //  MessageBox.Show("Please Choose Image");
                //}

                int x = BusinessLayer.Students.EnrollStudent(student, guardian, c);
                if (x > 0)
                {
                    MessageBox.Show("Student Enroll Successfully!!");
                    StudentCodeTextBox.Text = GetRandomCode();
                }
                else
                {
                    MessageBox.Show("Student Enroll Unsuccessful!!");
                    //this.Hide();

                    //Student.StudentEnroll SE = new Student.StudentEnroll();
                    //SE.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectOnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectOnCheckBox.Checked == true)
            {
                panel2.Enabled = true;
             
            }
           if(SelectOnCheckBox.Checked==false) 
           {
                panel2.Enabled = false;
                Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
                student.DivisionId = 7;
                pcid = 15;
                //did = 0;
                //pcid = 0;
                //school = "nopreviousschool";
            }
       
           
        }

        private void ReligionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void BtnBrowse_Click(object sender, EventArgs e)
        //{


        //    /////OpenFileDialog open = new OpenFileDialog();
        //    ///////open.Title = "Choose Image";
        //    // image filters
        //    /////////open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
        //    ////// //if (open.ShowDialog() == DialogResult.OK)
        //    ////// //{
        //    // display image in picture box
        //    /////////////////  pictureBox1.Image = new Bitmap(open.FileName);

        //    // image file path
        //    //  Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
        //    //   textBox1.Text = open.FileName;
        //    ///////////////PictureName = open.FileName;
        //    // student.StudentPhoto = open.FileName;
        //    // student.PictureName = open.FileName;
        //    //  BusinessLayer.Students.EnrollStudent(student);
        //    //MessageBox.Show(student.StudentPhoto);
        //    // MessageBox.Show(PictureName);
        //    ////////////////// }
        //    /*
        //     * 
        //     * 
        //     * 
        //     * 
        //     * 
        //     * modified code for image saving in binary form
        //      */

        //    OpenFileDialog dlg = new OpenFileDialog();
        //    DialogResult dlres = dlg.ShowDialog();
        //    if (dlres != DialogResult.Cancel)
        //    {
        //        pictureBox1.ImageLocation = dlg.FileName;
        //        textBox1.Text = dlg.FileName;
        //        ////MessageBox.Show(txtImagePath.ToString());
        //    }
    
        //}

       
    }
}