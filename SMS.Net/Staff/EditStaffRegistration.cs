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

namespace SMS.Net.Staff
{
    public partial class EditStaffRegistration : Form
    {
        static int did;
        public static int religionId;
        public static int jobStatusId;
        public static int positionId;
        public static string department;
        public EditStaffRegistration()
        {
            InitializeComponent();
         
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BindPosition()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PositionInfo";
            postComboBox.DisplayMember = "PositionName";
            postComboBox.ValueMember = "PositionId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            postComboBox.DataSource = dt;
        }
        private void BindDepartmentComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spDepartmentDisplay", null, true);
            DepartmentCombox.DisplayMember = "Department";
            DepartmentCombox.ValueMember = "DepartmentId";
            DepartmentCombox.DataSource = dt;
        }
        private void Bindstatus()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.JobStatusInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DisplayMember = "JobStatus";
            comboBox2.ValueMember = "JobStatusId";
            comboBox2.DataSource = dt;

        }
        private void ReligionInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("common.spReligionInfo", null, true);
            ReligionComboBox.Items.Clear();
            ReligionComboBox.ValueMember = "ReligionId";
            ReligionComboBox.DisplayMember = "ReligionName";
            ReligionComboBox.DataSource = dt;
        }
     
        private void CloseButton_Click(object sender, EventArgs e)
        {

        
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(StaffCodeTextBox.Text.Trim() + SalaryTextBox.Text.Trim());
            Common.Staff.Staffs staff = new Common.Staff.Staffs();
            Common.Staff.Department department = new Common.Staff.Department();
            //department.DepartmentId = 
            

            ///////////////////////////////////////////////////////////////////////////////////
            department.DepartmentId=did;
            staff.StaffCode=StaffCodeTextBox.Text.Trim();
            staff.StaffName = FirstNameTextBox.Text.Trim();
            if (radioButton1.Checked == true)
            {
                staff.StaffGender = "Male";
            }
            if (radioButton2.Checked == true)
            {
                staff.StaffGender = "Female";
            }
          
            staff.StaffMobile=MobileTextBox.Text.Trim();
            staff.StaffContact=StaffContactTextBox.Text.Trim();
            staff.StaffEmail=EmailTextBox.Text.Trim();
            staff.StaffAddress=AddressTextBox.Text.Trim();
            //staff.StaffPhoto=textBox1.Text.Trim();
            //staff.ImageData=ReadFile(textBox1.Text.Trim());
            if (textBox1.Text == string.Empty || textBox1.Text == null || textBox1.Text == "")
            {

                staff.StaffPhoto = "No image";
                textBox1.Text = "\\SMS\\nimage.jpg";
                staff.ImageData = DataBaseLayer.DbOperations.ReadFile(textBox1.Text.Trim());
            }
            else
            {
                staff.StaffPhoto = textBox1.Text;
                staff.ImageData = DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
            }




            staff.StaffNationality=NationalityTextBox.Text.Trim();
            staff.StaffAge=AgeTextBox.Text.Trim();
            staff.Religion = religionId;
            staff.Caste=casteTextBox.Text.Trim();
            if(MarriedCheckBox.Checked)
            {
                staff.MaritalStatus = "Married";
            }
            if(UnmarriedCheckBox.Checked)
            {
                staff.MaritalStatus = "Unmarried";
            }
           
           
	        staff.StaffQualification=QualificationTextBox.Text.Trim();
            staff.StaffPost =positionId;//PostTextBox.Text.Trim();
            staff.StaffEnrollMentDate=EnrollDateTextBox.Text;
            staff.StaffSalary=Convert.ToDouble(SalaryTextBox.Text.Trim());
            staff.StaffContractTerminationDate=ContractTerminationTextBox.Text;
            staff.JobStatus = jobStatusId;
            if(radioButton4.Checked)
            {   
                NoOfYearTextBox.Enabled=false;
                RemarkTextBox.Enabled=false;
                PreviousEmployeerTextBox.Enabled=false;
                staff.PreviousExperience = true;
                staff.NoOfYea=NoOfYearTextBox.Text.Trim();
                staff.Remarks=RemarkTextBox.Text.Trim();
                staff.PreviousEmployer=PreviousEmployeerTextBox.Text.Trim();
            }
            if(radioButton3.Checked)
            {
                NoOfYearTextBox.Enabled=true;
                RemarkTextBox.Enabled=true;
                PreviousEmployeerTextBox.Enabled=true;
                staff.PreviousExperience = false;
                staff.NoOfYea = NoOfYearTextBox.Text.Trim();
                staff.Remarks = RemarkTextBox.Text.Trim();
                staff.PreviousEmployer = PreviousEmployeerTextBox.Text.Trim();
            }

            if(TeachingCheckBox.Checked)
            {
                staff.StaffType = "Teaching";
            }
            if(NonTeachingCheckBox.Checked)
            {
                staff.StaffType = "Non-Teaching";
            }
           
            staff.Subject1=Subject1TextBox.Text;
            staff.Subject2=Subject1TextBox.Text;
            staff.Subject3=Subject3TextBox.Text;
            staff.Subject4=Subject4TextBox.Text;

            
            
            /////////////////////////////////////////////////////////////////////////////////////
            //staff.StaffCode = StaffContactTextBox.Text.Trim();

            int x=  BusinessLayer.Staff.StaffDataAccess.UpadateStaffRegistration(staff, department);
            if(x==1)
            {
                MessageBox.Show("Student Registration Updated Sucessfully!!", "Update Success");
                ClearControls();
                this.Close();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //DepartmentCombox.SelectedIndex = DepartmentCombox.FindString(department);
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            EnableDisableControls(true);
            PreviousEmployeerTextBox.Enabled = true;
            DepartmentCombox.Enabled = true;
        }

        private void EditStaffRegistration_Load(object sender, EventArgs e)
        {
       
            Bindstatus();
            BindPosition();
            ReligionInfo();
            BindDepartmentComboBox();
            DepartmentCombox.Enabled = false;
            PreviousEmployeerTextBox.Enabled = false;
            StaffCodeTextBox.Text= Staff.StaffGeneralInfo.staffCode;
            Common.Staff.Staffs staff = new Common.Staff.Staffs();
            staff.StaffCode = StaffCodeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(staff.StaffCode))
            {
                MessageBox.Show("Staff Code Please!!");
            }
            else
            {
                DataTable dt = BusinessLayer.Staff.StaffDataAccess.GetStaffByCode(staff);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("No Records Please!!");
                    EnableDisableControls(false);
                }
                else
                {
                    SqlDataReader sdr = BusinessLayer.Staff.StaffDataAccess.GetByCode(staff);
                    FirstNameTextBox.Text = sdr["StaffName"].ToString();
                    //department = sdr["Department"].ToString();
                    DepartmentCombox.SelectedIndex = DepartmentCombox.FindString(sdr["Department"].ToString());
                    if(sdr["StaffGender"].ToString()=="Male")
                    {
                        radioButton1.Checked = true;
                    }
                    if(sdr["StaffGender"].ToString()=="Female")
                    {
                        radioButton2.Checked = true;
                    }
                    StaffContactTextBox.Text = sdr["StaffContact"].ToString();
                    MobileTextBox.Text = sdr["StaffMobile"].ToString();
                    EmailTextBox.Text = sdr["StaffEmail"].ToString();
                    AddressTextBox.Text = sdr["StaffAddress"].ToString();
                  



                    //pictureBox1.Image = new Bitmap(sdr["StaffPhoto"].ToString());
                    ///modified method for displaying image
                    byte[] imageData = (byte[])sdr["ImageData"];

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

         
                    NationalityTextBox.Text = sdr["StaffNationality"].ToString();
                    SalaryTextBox.Text = sdr["StaffSalary"].ToString();
                    //PostTextBox.Text = sdr["StaffPost"].ToString();
                    if(sdr["MaritalStatus"].ToString()=="Married")
                    {
                        MarriedCheckBox.Checked = true;
                    }
                    if(sdr["MaritalStatus"].ToString()=="Unmarried")
                    {
                        UnmarriedCheckBox.Checked = true;
                    }
                   
                    QualificationTextBox.Text = sdr["StaffQualification"].ToString();
                    AgeTextBox.Text = sdr["StaffAge"].ToString();
                  
                    if(sdr["PreviousExperience"].ToString()=="false")
                    {
                        radioButton4.Checked=true;
                        PreviousEmployeerTextBox.Text = "false";
                        NoOfYearTextBox.Text = sdr["NoOfYear"].ToString();
                        RemarkTextBox.Text = sdr["Remarks"].ToString();
                        PreviousEmployeerTextBox.Text = sdr["PreviousEmployer"].ToString();
                    }
                    if (sdr["PreviousExperience"].ToString()=="true")
                    {
                        radioButton3.Checked = true;
                        PreviousEmployeerTextBox.Text = "true";
                        NoOfYearTextBox.Text = sdr["NoOfYear"].ToString();
                        RemarkTextBox.Text = sdr["Remarks"].ToString();
                        PreviousEmployeerTextBox.Text = sdr["PreviousEmployer"].ToString();
                    }
                   
                    if(sdr["StaffType"].ToString()=="Teaching")
                    {
                        TeachingCheckBox.Checked = true;
                    }
                    if(sdr["StaffType"].ToString()=="Non-Teaching")
                    {
                        NonTeachingCheckBox.Checked = true;
                    }
                    Subject1TextBox.Text = sdr["Subject1"].ToString();
                    Subject2TextBox.Text = sdr["Subject2"].ToString();
                    Subject3TextBox.Text = sdr["Subject3"].ToString();
                    Subject4TextBox.Text = sdr["Subject4"].ToString();
                    StaffCodeTextBox.Enabled = false;
                    EnableDisableControls(true);
                    SaveButton.Enabled = true;
                    EditButton.Enabled = false;
                }

            }
          
            StaffCodeTextBox.Enabled = false;
            EditButton.Enabled = true;
            SaveButton.Enabled = false;
            EnableDisableControls(false);
        }
        private void EnableDisableControls(bool b)
        {
            //StaffCodeTextBox.Enabled = b;
            FirstNameTextBox.Enabled = b;
            StaffContactTextBox.Enabled = b;
            MobileTextBox.Enabled = b;
            NationalityTextBox.Enabled = b;
            AddressTextBox.Enabled = b;
            EmailTextBox.Enabled = b;
            ReligionComboBox.Enabled = b;
            casteTextBox.Enabled = b;
            AgeTextBox.Enabled = b;
            QualificationTextBox.Enabled = b;
            postComboBox.Enabled = b;
          //  PostTextBox.Enabled = b;
            EnrollDateTextBox.Enabled = b;
            SalaryTextBox.Enabled = b;
            ContractTerminationTextBox.Enabled = b;
            NoOfYearTextBox.Enabled = b;
            RemarkTextBox.Enabled = b;
            Subject1TextBox.Enabled = b;
            Subject2TextBox.Enabled = b;
            Subject3TextBox.Enabled = b;
            Subject4TextBox.Enabled = b;
        }
        private void ClearControls()
        {
            //StaffCodeTextBox.Enabled = b;
            FirstNameTextBox.Text = string.Empty;
            StaffContactTextBox.Text = string.Empty;
            MobileTextBox.Text = string.Empty;
            NationalityTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            //ReligionComboBox.Enabled = b;
            //casteTextBox.Enabled = b;
            AgeTextBox.Text = string.Empty;
            QualificationTextBox.Text=string.Empty;
            //postComboBox
            //  PostTextBox.Enabled = b;
            EnrollDateTextBox.Text = string.Empty;
            SalaryTextBox.Text = string.Empty;
            ContractTerminationTextBox.Text = string.Empty;
            NoOfYearTextBox.Text = string.Empty;
            RemarkTextBox.Text = string.Empty;
            Subject1TextBox.Text = string.Empty;
            Subject2TextBox.Text = string.Empty;
            Subject3TextBox.Text=string.Empty;
            Subject4TextBox.Text = string.Empty;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlres = dlg.ShowDialog();
            if (dlres != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;
                textBox1.Text = dlg.FileName;
                ////MessageBox.Show(txtImagePath.ToString());
            }
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void DepartmentCombox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DepartmentCombox.SelectedValue!=null)
            {
                did =Convert.ToInt32(DepartmentCombox.SelectedValue);
            }
        }

        private void ReligionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ReligionComboBox.SelectedValue!=null)
            {
                religionId = Convert.ToInt32(ReligionComboBox.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                jobStatusId = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }

        private void postComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(postComboBox.SelectedValue!=null)
            {
                positionId = Convert.ToInt32(postComboBox.SelectedValue);
            }
        }
    }
}
